using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace FSMS.Helpers
{
    public class DataGridViewHelper
    {

        public static void DrawActionIcons(
            DataGridViewCellPaintingEventArgs e,
            int hoverRow,
            string hoverIcon)
        {

            e.PaintBackground(e.CellBounds, true);


            Color editColor = Color.FromArgb(0, 150, 136);
            Color deleteColor = Color.Red;


            if (hoverRow == e.RowIndex && hoverIcon == "Edit")
                editColor = Color.DarkCyan;


            if (hoverRow == e.RowIndex && hoverIcon == "Delete")
                deleteColor = Color.DarkRed;



            using (IconPictureBox edit = new IconPictureBox())
            using (IconPictureBox delete = new IconPictureBox())
            {

                edit.IconChar = IconChar.Pen;
                edit.IconColor = editColor;
                edit.BackColor = Color.White;
                edit.IconSize = 20;



                delete.IconChar = IconChar.Trash;
                delete.IconColor = deleteColor;
                delete.BackColor = Color.White;
                delete.IconSize = 20;



                Bitmap bmp1 = new Bitmap(18, 18);
                Bitmap bmp2 = new Bitmap(18, 18);



                edit.DrawToBitmap(
                    bmp1,
                    new Rectangle(0, 0, 18, 18)
                );


                delete.DrawToBitmap(
                    bmp2,
                    new Rectangle(0, 0, 18, 18)
                );



                e.Graphics.DrawImage(
                    bmp1,
                    e.CellBounds.Left + 18,
                    e.CellBounds.Top + 8
                );


                e.Graphics.DrawImage(
                    bmp2,
                    e.CellBounds.Left + 50,
                    e.CellBounds.Top + 8
                );

            }


            e.Handled = true;
        }


    }
}