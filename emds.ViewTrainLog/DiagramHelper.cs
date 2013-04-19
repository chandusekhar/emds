using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MindFusion.Diagramming.Wpf;
using System.Windows.Media;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace emds.ViewTrainLog
{
    public static class DiagramHelper
    {
        public static ShapeNode CreateNode(Diagram diagramNet, double x, double y, double widthNode, double heightNoe, String nameNode = "")
        {
            ShapeNode node = diagramNet.Factory.CreateShapeNode(x, y, widthNode, heightNoe);
            node.ToolTip = nameNode;
            node.Shape = Shapes.Ellipse;
            node.Text = nameNode;
            node.ZIndex = 10;
            node.Brush = new LinearGradientBrush(Colors.Yellow, Colors.BurlyWood, 20);
            node.Font = new Font("Arial", 12.5, GraphicsUnit.World);

            return node;
        }
        

        public static ShapeNode CreateNode(Shape shape, Diagram diagramNet, double x, double y, double widthNode, double heightNoe, String nameNode = "")
        {
            ShapeNode node = diagramNet.Factory.CreateShapeNode(x, y, widthNode, heightNoe);
            node.ToolTip = nameNode;
            node.Shape = shape;
            node.Text = nameNode;
            node.ZIndex = 10;
            node.Brush = new LinearGradientBrush(Colors.Yellow, Colors.BurlyWood, 20);
            node.Font = new Font("Arial", 12.5, GraphicsUnit.World);

            return node;
        }

        public static DiagramLink CreateLink(Diagram diagramNet, ShapeNode origin, ShapeNode destination, string toolTip = "#")
        {
            DiagramLink link = diagramNet.Factory.CreateDiagramLink(origin, destination);
            link.HeadShape = ArrowHeads.Tetragon;
            link.Brush = new SolidColorBrush(Colors.Green);
            link.Text = toolTip;
            link.ZIndex = 5;
            return link;
        }
    }
}
