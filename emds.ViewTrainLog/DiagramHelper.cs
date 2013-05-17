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
            UnSelectNodeLook(node);
            node.Font = new Font("Arial", 12.5, GraphicsUnit.World);
            node.EnabledHandles = AdjustmentHandles.Move;       

            return node;
        }

        public static ShapeNode CreateNode(Shape shape, Diagram diagramNet, double x, double y, double widthNode, double heightNoe, String nameNode = "")
        {
            ShapeNode node = diagramNet.Factory.CreateShapeNode(x, y, widthNode, heightNoe);
            node.ToolTip = nameNode;
            node.Shape = shape;
            node.Text = nameNode;
            UnSelectNodeLook(node);
            node.Font = new Font("Arial", 12.5, GraphicsUnit.World);
            node.EnabledHandles = AdjustmentHandles.Move;

            return node;
        }

        public static DiagramLink CreateLink(Diagram diagramNet, ShapeNode origin, ShapeNode destination, string toolTip = "#")
        {
            DiagramLink link = diagramNet.Factory.CreateDiagramLink(origin, destination);
            link.HeadShape = ArrowHeads.Tetragon;
            link.Brush = new SolidColorBrush(Colors.Green);
            link.Text = toolTip;
            UnSelectLinkLook(link);
            return link;
        }

        public static void SelectNode(ShapeNode node)
        {
            SelectNodeLook(node);
            foreach (var link in node.OutgoingLinks)
            {
                SelectLinkLook(link);
            }
            foreach (var link in node.IncomingLinks)
            {
                SelectLinkLook(link);
            }
        }

        public static void UnSelectNode(ShapeNode node)
        {
            UnSelectNodeLook(node);
            foreach (var link in node.OutgoingLinks)
            {
                UnSelectLinkLook(link);
            }
            foreach (var link in node.IncomingLinks)
            {
                UnSelectLinkLook(link);
            }
        }

        private static void SelectLinkLook(DiagramLink link)
        {
            link.Brush = Brushes.Red;
            link.Stroke = Brushes.Blue;
            link.TextBrush = Brushes.Blue;
            link.FontSize = 16;
            link.FontWeight = FontWeights.Bold;
            link.TextStyle = LinkTextStyle.OverLongestSegment;
            link.ZIndex = 10;
        }

        private static void UnSelectLinkLook(DiagramLink link)
        {
            link.Brush = Brushes.Green;
            link.Stroke = Brushes.Black;
            link.TextBrush = Brushes.Black;
            link.FontSize = 14;
            link.FontWeight = FontWeights.Normal;
            link.TextStyle = LinkTextStyle.Center;
            link.ZIndex = 0;
        }

        private static void SelectNodeLook(ShapeNode node)
        {
            node.Brush = new LinearGradientBrush(Colors.Green, Colors.BurlyWood, 20); // Brushes.Green;
            node.ZIndex = 20;
        }

        private static void UnSelectNodeLook(ShapeNode node)
        {
            node.Brush = new LinearGradientBrush(Colors.Yellow, Colors.BurlyWood, 20);// Brushes.Yellow;
            node.ZIndex = 10;
        }
    }
}
