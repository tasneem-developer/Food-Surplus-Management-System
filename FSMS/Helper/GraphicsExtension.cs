using System.Drawing;
using System.Drawing.Drawing2D;

namespace FSMS.Helpers
{
    public static class GraphicsExtension
    {
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rectangle.X,
                rectangle.Y,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                rectangle.Right - radius,
                rectangle.Y,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                rectangle.Right - radius,
                rectangle.Bottom - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                rectangle.X,
                rectangle.Bottom - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            graphics.FillPath(brush, path);
        }
    }
}