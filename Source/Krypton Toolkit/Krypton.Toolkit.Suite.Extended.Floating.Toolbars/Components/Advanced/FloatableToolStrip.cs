﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable CS8602, CS8622
namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    [ToolboxBitmap(typeof(FloatableToolStrip), "ToolboxBitmaps.FloatableToolStrip.bmp")]
    public class FloatableToolStrip : ToolStrip
    {
        #region Variables
        private ToolStripContainerWindow _toolStripContainerWindow;

        private Control? _originalParent = null;

        private bool _aboutToFloat = false, _isFloating = false, _parentChanged = false;

        private List<ToolStripPanelExtended> _toolStripPanelExtendedList = new();

        private string _floatingToolBarWindowText;
        #endregion

        #region Properties
        internal Control? OriginalParent => _originalParent;

        /// <summary>
        /// Gets or sets the tool strip panel extened list.
        /// </summary>
        /// <value>
        /// The tool strip panel extened list.
        /// </value>
        [Editor(typeof(ToolStripPanelCollectionEditor), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ToolStripPanelExtended> ToolStripPanelExtenedList { get => _toolStripPanelExtendedList; set => _toolStripPanelExtendedList = value; }

        /// <summary>
        /// Gets a value indicating whether this instance is floating.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is floating; otherwise, <c>false</c>.
        /// </value>
        public bool IsFloating => _isFloating;

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        public new bool Visible
        {
            get => base.Visible;

            set
            {
                if (_isFloating)
                {
                    _toolStripContainerWindow.Visible = value;
                }
                else
                {
                    base.Visible = value;
                }
            }
        }

        public string FloatingToolBarWindowText { get => _floatingToolBarWindowText; set => _floatingToolBarWindowText = value; }
        #endregion

        #region Constructor
        public FloatableToolStrip()
        {
            FloatingToolBarWindowText = "Tool Bar";
        }
        #endregion

        #region Overrides
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent != null)
            {
                _originalParent = Parent;

                if (_aboutToFloat)
                {
                    _parentChanged = true;
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);

            if (!_isFloating && GripRectangle.Contains(mea.Location))
            {
                _aboutToFloat = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);

            if (_parentChanged)
            {
                _parentChanged = false;

                _aboutToFloat = false;

                return;
            }

            Point p0 = PointToScreen(mea.Location), p1 = _originalParent.PointToClient(p0);

            if (_aboutToFloat && !_originalParent.ClientRectangle.Contains(p1))
            {
                if (_toolStripContainerWindow == null)
                {
                    _toolStripContainerWindow = new ToolStripContainerWindow();

                    _toolStripContainerWindow.NCLBUTTONDBLCLK += _toolStripContainerWindow_NCLBUTTONDBLCLK;

                    _toolStripContainerWindow.LocationChanged += _toolStripContainerWindow_LocationChanged;

                    _toolStripContainerWindow.FormClosing += _toolStripContainerWindow_FormClosing;
                }

                _originalParent.Controls.Remove(this);

                _toolStripContainerWindow.FloatableToolStrip = this;

                _toolStripContainerWindow.Location = p0;

                _toolStripContainerWindow.Show(Parent.Parent);

                _aboutToFloat = false;

                _isFloating = true;
            }
        }
        #endregion

        #region Runtime Methods
        [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void GetCursorPos(out Point point);
        #endregion

        #region Event Handlers
        private void _toolStripContainerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                _toolStripContainerWindow.Visible = false;

                base.OnVisibleChanged(new EventArgs());
            }
        }

        private void _toolStripContainerWindow_LocationChanged(object sender, EventArgs e)
        {
            Point point;

            if (_parentChanged)
            {
                _parentChanged = false;
            }

            GetCursorPos(out point);

            foreach (ToolStripPanelExtended item in _toolStripPanelExtendedList)
            {
                if (item.ActiveRectangle.Contains(item.PointToClient(point)))
                {
                    _toolStripContainerWindow.Controls.Remove(this);

                    item.SuspendLayout();

                    base.Dock = DockStyle.None;

                    base.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                    item.Controls.Add(this);

                    item.ResumeLayout();

                    _toolStripContainerWindow.Hide();

                    _isFloating = false;

                    _parentChanged = false;

                    if (_originalParent.Parent != null)
                    {
                        _originalParent.Parent.Focus();
                    }
                    else
                    {
                        _originalParent.Focus();
                    }

                    return;
                }
            }
        }

        private void _toolStripContainerWindow_NCLBUTTONDBLCLK(object sender, EventArgs e)
        {
            _toolStripContainerWindow.Controls.Remove(this);

            _toolStripContainerWindow.Visible = false;

            _originalParent.SuspendLayout();

            base.Dock = DockStyle.None;

            base.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            _originalParent.Controls.Add(this);

            _originalParent.ResumeLayout();

            _isFloating = false;
        }
        #endregion
    }
}