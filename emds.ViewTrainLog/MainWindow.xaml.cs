using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using emds.TrainLoggers;
using emds.TrainLoggers.Models;

using MindFusion.Diagramming;
using emds.common;
using Encog.Neural.Networks;
using MindFusion.Diagramming.Wpf;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using MindFusion.Diagramming.Wpf.Layout;

using System.Data.Linq;
using TemplXML = MDS.Common.Forms;
using MDS.FillForm.DomainModel.Database;
using MDS.FillForm.DomainModel.Entities;
using Encog.ML.Data;
using System.Xml.Linq;

namespace emds.ViewTrainLog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TrainLogRepository rep;
        private IEnumerable<InitEvent> trains;
        private IEnumerable<Iteration> iterations;
        private IEnumerable<ProcessPair> processPairData;

        private np4load currentXmlNet;
        private BasicNetwork neuralNetIter;
        private List<ShapeNode>[] graphIterations;

        private BasicNetwork neuralNetPair;
        private List<ShapeNode>[] graphPair;
        private List<DiagramLink> graphPairLinkInput;
        private IMLDataSet trainingData;

        private TemplXML.FormTemplate templ;

        public MainWindow()
        {
            neuralNetIter = null;
            neuralNetPair = null;

            rep = new TrainLogRepository(AppConfigHelper.GetCollectionName, AppConfigHelper.GetDBName, AppConfigHelper.GetMongoDBConnectionString);

            InitializeComponent();
        }

        private void cbTrainsLog_Initialized(object sender, EventArgs e)
        {
            trains = rep.GetAllTrainLog();
            cbTrainsLog.ItemsSource = trains;
                        
            //if (trains.Count() > 0)
            //    cbTrainsLog.SelectedIndex = 0;
        }

        private void cbTrainsLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTrainsLog.SelectedItem != null)
            {
                InitEvent ie = cbTrainsLog.SelectedItem as InitEvent;
                //ist<int> ageNum = new List<int>(ie.IterationCount);
                //int[] ageNum2 = new int[ie.IterationCount];
                //Parallel.For(1, ie.IterationCount+1, i => ageNum2[i-1] = i);
                //for (int i = 1; i <= ie.IterationCount; i++)
                //    ageNum.Add(i);
                iterations = rep.GetIteration(ie.Sid).OrderBy(x => x.AgeNumber);
                cbAgeNumber.ItemsSource = iterations;

                currentXmlNet = new np4load(ie.Path);
                neuralNetIter = currentXmlNet.GetNeuralNetwork();
                trainingData = currentXmlNet.GetTrainingData();
                graphIterations = null;
                testD.ClearAll();
                pairDiagram.ClearAll();
            }
        }

        private void cbAgeNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAgeNumber.SelectedItem != null)
            {
                //для того что бы скинуть значения
                neuralNetPair = null;

                InitEvent ie = cbTrainsLog.SelectedItem as InitEvent;
                Iteration iter = cbAgeNumber.SelectedItem as Iteration;
                processPairData = rep.GetProcessPair(ie.Sid, iter.AgeNumber).OrderBy(x => x.Pair);
                cbProcessPair.ItemsSource = processPairData;

                neuralNetIter.DecodeFromArray(iter.WeightBefore);

                if (graphIterations == null)
                    DrawNeuralNet(testD, out graphIterations, neuralNetIter);
                else
                    ReLabelLinks(graphIterations, neuralNetIter);
            }
        }

        int indPair;

        private void cbProcessPair_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProcessPair.SelectedItem != null)
            {
                ProcessPair pp = cbProcessPair.SelectedItem as ProcessPair;

                if (neuralNetPair == null)
                {
                    neuralNetPair = currentXmlNet.GetNeuralNetwork();
                    cbParametrsPair.SelectedIndex = 0; //градиент
                    DrawNeuralNetPair(pairDiagram, out graphPair, neuralNetPair);
                }
                else
                {
                    if (indPair != pp.Pair)
                        ReLabelInput(pp.Pair);
                    DrawPairParametrs();
                }
                indPair = pp.Pair;
            }
        }

        private void DrawNeuralNet(Diagram diagram, out List<ShapeNode>[] nodes, BasicNetwork neuralNet)
        {
            if (diagram.Items.Count > 0)
                diagram.ClearAll();
            //получение шаблона
            InitEvent netInit = cbTrainsLog.SelectedItem as InitEvent;
            //TemplXML.FormTemplate templ;
            using (var db = MDSDB.GetInstance())
            {
                var catT = db.TemplateCategories.First(x => x.Name == netInit.Anketa);
                var tempC = db.FormTemplate.Where(x => x.TemplateCategoryId == catT.Id).OrderByDescending(y => y.Version).First();
                templ = TemplXML.FormTemplate.FromXml(tempC.TemplateMarkup);
            }
            
            double dx = 400;
            double rastNode = 30;
            double startYF = 50;
            double startX = dx + 50; // + (neuralNet.LayerCount - 1) * 300;
            double startY = 50;
            double diam = 30;
            double startYMax = startY;
            nodes = new List<ShapeNode>[neuralNet.LayerCount];
            for (int i = neuralNet.LayerCount - 1 ; i >= 0; i--)
            {
                List<ShapeNode> curN = new List<ShapeNode>();
                for (int j = 0; j < neuralNet.Flat.LayerCounts[i]; j++)
                {
                    ShapeNode tmp = DiagramHelper.CreateNode(diagram, startX, startY, diam, diam, j.ToString());
                    curN.Add(tmp);

                    if (i == neuralNet.LayerCount - 1 && j <neuralNet.InputCount)
                    {
                        ShapeNode q = DiagramHelper.CreateNode(Shapes.Rectangle, diagram, startX - dx, startY, 200, 50, templ.Fields[j].Title);
                        DiagramHelper.CreateLink(diagram, q, tmp);
                    }

                    startY += diam + rastNode;
                }
                nodes[i] = curN;
                startX += dx;
                if (startYMax < startY) startYMax = startY;
                if(i != 0)
                    startY = startYMax / 2 - neuralNet.Flat.LayerCounts[i - 1] * (rastNode + diam) / 2;
            }
            
            string tmpWeigth;
            int countN;
            for (int i = neuralNet.LayerCount - 1; i > 0; i--)
            {
                countN = countN = neuralNet.Flat.LayerCounts[i - 1];
                if (i - 1 == neuralNet.LayerCount - 2 && neuralNet.GetLayerBiasActivation(i - 1) > 0)
                    countN -= 1;
                for (int x = 0; x < neuralNet.Flat.LayerCounts[i]; x++)
                {
                    
                    for (int y = 0; y < countN; y++)
                    {
                        tmpWeigth = neuralNet.GetWeight(neuralNet.LayerCount - i - 1, x, y).ToString("F4");
                        DiagramHelper.CreateLink(diagram, nodes[i][x], nodes[i - 1][y], tmpWeigth);
                    }
                }
            }
        }

        private void DrawNeuralNetPair(Diagram diagram, out List<ShapeNode>[] nodes, BasicNetwork neuralNet)
        {
            if (diagram.Items.Count > 0)
                diagram.ClearAll();
            //получение шаблона
            //InitEvent netInit = cbTrainsLog.SelectedItem as InitEvent;
            //TemplXML.FormTemplate templ;
            //using (var db = MDSDB.GetInstance())
            //{
            //    var catT = db.TemplateCategories.First(x => x.Name == netInit.Anketa);
            //    var tempC = db.FormTemplate.Where(x => x.TemplateCategoryId == catT.Id).OrderByDescending(y => y.Version).First();
            //    templ = TemplXML.FormTemplate.FromXml(tempC.TemplateMarkup);
            //}
            ProcessPair pp = cbProcessPair.SelectedItem as ProcessPair;
            TemplXML.FormData form = ConvertDataArrayToXml(templ, trainingData[pp.Pair].InputArray); 

            double dx = 400;
            double rastNode = 30;
            double startYF = 50;
            double startX = dx + 50; // + (neuralNet.LayerCount - 1) * 300;
            double startY = 50;
            double diam = 30;
            double startYMax = startY;
            nodes = new List<ShapeNode>[neuralNet.LayerCount];
            string label = "null";
            graphPairLinkInput = new List<DiagramLink>(neuralNet.Flat.LayerCounts[neuralNet.LayerCount - 1]);
            for (int i = neuralNet.LayerCount - 1; i >= 0; i--)
            {
                List<ShapeNode> curN = new List<ShapeNode>();
                for (int j = 0; j < neuralNet.Flat.LayerCounts[i]; j++)
                {
                    ShapeNode tmp = DiagramHelper.CreateNode(diagram, startX, startY, diam*2, diam, j.ToString());
                    curN.Add(tmp);

                    if (i == neuralNet.LayerCount - 1 && j < neuralNet.InputCount)
                    {
                        ShapeNode q = DiagramHelper.CreateNode(Shapes.Rectangle, diagram, startX - dx - 200, startY - 10, 200, 50,  form.Values[j].Field.Title);
                        if (form.Values[j] is TemplXML.FormDataValueNumber)
                        {
                            var tmpF = form.Values[j] as TemplXML.FormDataValueNumber;
                            label = string.Format("{0}", tmpF.Value);
                        }
                        else
                        {
                            var tmpF = form.Values[j] as TemplXML.FormDataValueSelect;
                            label = tmpF.Value.Title;
                        }
                        var tmpLink = DiagramHelper.CreateLink(diagram, q, tmp, label);
                                                
                        graphPairLinkInput.Add(tmpLink);
                    }

                    startY += diam + rastNode;
                }
                nodes[i] = curN;
                startX += dx;
                if (startYMax < startY) startYMax = startY;
                if (i != 0)
                    startY = startYMax / 2 - neuralNet.Flat.LayerCounts[i - 1] * (rastNode + diam) / 2;
            }

            string tmpWeigth;
            int countN;
            for (int i = neuralNet.LayerCount - 1; i > 0; i--)
            {
                countN = countN = neuralNet.Flat.LayerCounts[i - 1];
                if (i - 1 == neuralNet.LayerCount - 2 && neuralNet.GetLayerBiasActivation(i - 1) > 0)
                    countN -= 1;
                for (int x = 0; x < neuralNet.Flat.LayerCounts[i]; x++)
                {

                    for (int y = 0; y < countN; y++)
                    {
                        tmpWeigth = neuralNet.GetWeight(neuralNet.LayerCount - i - 1, x, y).ToString("F4");
                        DiagramHelper.CreateLink(diagram, nodes[i][x], nodes[i - 1][y], tmpWeigth);
                    }
                }
            }
        }

        private void ReLabelInput(int ind)
        {
            TemplXML.FormData form = ConvertDataArrayToXml(templ, trainingData[ind].InputArray);
            string label;
            for (int i = 0; i < graphPairLinkInput.Count; i++)
            {
                if (form.Values[i] is TemplXML.FormDataValueNumber)
                {
                    var tmpF = form.Values[i] as TemplXML.FormDataValueNumber;
                    label = string.Format("{0}", tmpF.Value);
                }
                else
                { 
                    var tmpF = form.Values[i] as TemplXML.FormDataValueSelect;
                    label = tmpF.Value.Title;
                }
                graphPairLinkInput[i].Text = label;
            }
        }

        /// <summary>
        /// Новые метки должны быть уже в нейронной сети neuralNet
        /// </summary>
        /// <param name="weidth"></param>
        /// <param name="nodes"></param>
        /// <param name="neuralNet"></param>
        private void ReLabelLinks(List<ShapeNode>[] nodes, BasicNetwork neuralNet)
        {
            string tmpWeigth;
            
            for (int i = neuralNet.LayerCount - 1; i > 0; i--)
            {
                for (int x = 0; x < neuralNet.Flat.LayerCounts[i]; x++)
                {
                    for (int y = 0; y < neuralNet.Flat.LayerCounts[i - 1]; y++)
                    {
                        try
                        {
                            tmpWeigth = neuralNet.GetWeight(neuralNet.LayerCount - i - 1, x, y).ToString("F4");
                            nodes[i][x].OutgoingLinks[y].Text = tmpWeigth;
                        }
                        catch
                        {
                            tmpWeigth = "null";
                        }
                    }
                }
            }
        }

        private void ReLabelNeirons(List<ShapeNode>[] nodes, BasicNetwork neuralNet, double[] labelNeuron)
        {
            string tmp;
            for (int i = 0; i < neuralNet.LayerCount; i++)
            {
                for (int j = 0; j < neuralNet.Flat.LayerCounts[i]; j++)
                {
                    tmp = labelNeuron[neuralNet.Flat.LayerIndex[i] + j].ToString("F3");
                    //graphPair[i][j].Shape = Shapes.Rectangle;

                    graphPair[i][j].Text = tmp;
                    graphPair[i][j].ToolTip = tmp;
                }
            }
        }

        private void DrawPairParametrs()
        {
            if (cbParametrsPair.SelectedIndex != -1 && cbProcessPair.SelectedItem != null)
            {
                ProcessPair curPP = cbProcessPair.SelectedItem as ProcessPair;
                switch (cbParametrsPair.SelectedIndex)
                {
                    case 0:
                        {
                            //граиент набора данных
                            neuralNetPair.DecodeFromArray(curPP.PairGradient);

                            for (int i = 0; i < neuralNetPair.LayerCount; i++)
                            {
                                for (int j = 0; j < neuralNetPair.Flat.LayerCounts[i]; j++)
                                {
                                    graphPair[i][j].Text = j.ToString();
                                    graphPair[i][j].ToolTip = j;
                                }
                            }
                            ReLabelLinks(graphPair, neuralNetPair);
                            break;
                        }
                    case 1:
                        {
                            ReLabelNeirons(graphPair, neuralNetPair, curPP.LayerSums);
                            break;
                        }
                    case 2:
                        {
                            ReLabelNeirons(graphPair, neuralNetPair, curPP.LayerOutput);
                            break;
                        }
                    case 3:
                        {
                            ReLabelNeirons(graphPair, neuralNetPair, curPP.Error);
                            break;
                        }
                    case 4:
                        {
                            ReLabelNeirons(graphPair, neuralNetPair, curPP.PairLayerDelta);
                            break;
                        }
                }
            }
        }

        private void cbParametrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbParametrs.SelectedIndex != -1 && cbAgeNumber.SelectedItem != null)
            {
                Iteration curIt = cbAgeNumber.SelectedItem as Iteration;
                switch (cbParametrs.SelectedIndex)
                {
                    case 0: 
                        {
                            neuralNetIter.DecodeFromArray(curIt.WeightBefore);
                            ReLabelLinks(graphIterations, neuralNetIter);
                            break; 
                        }
                    case 1:
                        {
                            neuralNetIter.DecodeFromArray(curIt.GradientR);
                            ReLabelLinks(graphIterations, neuralNetIter);
                            break;
                        }
                    case 2:
                        {
                            neuralNetIter.DecodeFromArray(curIt.NewWeights);
                            ReLabelLinks(graphIterations, neuralNetIter);
                            break;
                        }
                }
            }
        }

        private TemplXML.FormData ConvertDataArrayToXml(TemplXML.FormTemplate templ, double[] data)
        {
            var res = new TemplXML.FormData(templ);
            //((TemplXML.FormDataValueSelect)res.Values[0]).Value = ((TemplXML.FormDataValueSelect)res.Values[0]).Field.Options.First();

            for (int i = 0; i < data.Length; i++)
            {
                if (templ.Fields[i] is TemplXML.FormFieldSelect)
                {
                    TemplXML.FormDataValueSelect tmp = res.Values[i] as TemplXML.FormDataValueSelect;
                    tmp.Value = tmp.Field.Options.FirstOrDefault(x => x.Value == (int)data[i]);
                }
                else
                {
                    TemplXML.FormDataValueNumber tmp = res.Values[i] as TemplXML.FormDataValueNumber;
                    tmp.Value = data[i];

                }
            }

            return res;
        }

        private void cbParametrsPair_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbParametrsPair.SelectedIndex != -1)
            {
                DrawPairParametrs();
            }
        }

        private void btPlusAgeNumber_Click(object sender, RoutedEventArgs e)
        {
            InitEvent ie = cbTrainsLog.SelectedItem as InitEvent;
            if(cbAgeNumber.SelectedItem != null && cbAgeNumber.SelectedIndex + 1 < ie.IterationCount)
                cbAgeNumber.SelectedIndex += 1;
        }

        private void btMinusAgeNumber_Click(object sender, RoutedEventArgs e)
        {
            if (cbAgeNumber.SelectedItem != null && cbAgeNumber.SelectedIndex > -1)
                cbAgeNumber.SelectedIndex -= 1;
        }

        private void btPlusPairNumber_Click(object sender, RoutedEventArgs e)
        {
            InitEvent ie = cbTrainsLog.SelectedItem as InitEvent;
            if (cbProcessPair.SelectedItem != null && cbProcessPair.SelectedIndex + 1 < ie.TrainDataSize)
                cbProcessPair.SelectedIndex += 1;
        }

        private void btMinusPairNumber_Click(object sender, RoutedEventArgs e)
        {
            if (cbProcessPair.SelectedItem != null && cbProcessPair.SelectedIndex > -1)
                cbProcessPair.SelectedIndex -= 1;
        }

        private void testD_LinkCreating(object sender, LinkValidationEventArgs e)
        {
            e.Cancel = true;
        }

        private void testD_NodeCreating(object sender, NodeValidationEventArgs e)
        {
            e.Cancel = true;
        }


    }
}
