#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 *
 * Original code by: mbsysde99 (https://github.com/mbsysde99)
 */
#endregion


namespace Krypton.Toolkit.Suite.Extended.ComboBox
{
    public class KryptonColorComboBox : KryptonComboBox
    {
        #region Instance Fields

        private IPalette? _palette;

        private List<Color> _colorList = new List<Color>();

        #endregion

        #region Properties

        public static bool EnableColorComboBox { get; set; } = false;

        #endregion

        #region Identity

        public KryptonColorComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            _colorList = GetColorList();

            EnableColorComboBox = true;

            DataSource = _colorList;

            DropDownStyle = ComboBoxStyle.DropDownList;

            DrawMode = DrawMode.OwnerDrawFixed;

            DrawItem += KryptonColorComboBox_DrawItem;
        }
        #endregion

        #region Render

        private void KryptonColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (EnableColorComboBox)
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    Color color = (Color)_colorList[e.Index];
                    Rectangle r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, 2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                    Rectangle r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
                    string txt = this.GetItemText(this.Items[e.Index]);
                    using (var b = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(b, r1);
                        e.Graphics.DrawRectangle(Pens.Black, r1);

                        TextRenderer.DrawText(e.Graphics, txt, this.Font, r2, this.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                    }
                }
            }
        }

        #endregion

        #region Color
        public List<Color> GetColorList()
        {
            List<Color> colorList = new List<Color>();
            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    object? objColor = property.GetValue(null);
                    if (objColor != null)
                    {
                        colorList.Add((Color)objColor);
                    }
                }
            }
            return colorList;
        }
        #endregion

        #region Overrides

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return createParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        #endregion
    }
}