﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// Visual display of tooltip information.
    /// </summary>
    public class VisualPopupToolTip : VisualPopup
    {
        #region Instance Fields
        private readonly PaletteTripleMetricRedirect _palette;
        private readonly ViewDrawDocker _drawDocker;
        private readonly ViewDrawContent _drawContent;
        private readonly IContentValues _contentValues;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the VisualPopupTooltip class.
        /// </summary>
        /// <param name="redirector">Redirector for recovering palette values.</param>
        /// <param name="contentValues">Source of content values.</param>
        /// <param name="renderer">Drawing renderer.</param>
        public VisualPopupToolTip(PaletteRedirect redirector,
                                  IContentValues contentValues,
                                  IRenderer renderer)
            : this(redirector, contentValues, renderer,
                   PaletteBackStyle.ControlToolTip,
                   PaletteBorderStyle.ControlToolTip,
                   PaletteContentStyle.LabelToolTip)
        {
        }

        /// <summary>
        /// Initialize a new instance of the VisualPopupTooltip class.
        /// </summary>
        /// <param name="redirector">Redirector for recovering palette values.</param>
        /// <param name="contentValues">Source of content values.</param>
        /// <param name="renderer">Drawing renderer.</param>
        /// <param name="backStyle">Style for the tooltip background.</param>
        /// <param name="borderStyle">Style for the tooltip border.</param>
        /// <param name="contentStyle">Style for the tooltip content.</param>
        public VisualPopupToolTip(PaletteRedirect redirector,
                                  IContentValues contentValues,
                                  IRenderer renderer,
                                  PaletteBackStyle backStyle,
                                  PaletteBorderStyle borderStyle,
                                  PaletteContentStyle contentStyle)
            : base(renderer, true)
        {
            System.Diagnostics.Debug.Assert(contentValues != null);

            // Remember references needed later
            _contentValues = contentValues!;

            // Create the triple redirector needed by view elements
            _palette = new(redirector, backStyle, borderStyle, contentStyle, NeedPaintDelegate);

            // Our view contains background and border with content inside
            _drawDocker = new(_palette.Back, _palette.Border, null);
            _drawContent = new(_palette.Content, _contentValues, VisualOrientation.Top);
            _drawDocker.Add(_drawContent, ViewDockStyle.Fill);

            // Create the view manager instance
            ViewManager = new(this, _drawDocker);
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets a value indicating if the keyboard is passed to this popup.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override bool KeyboardInert => true;

        /// <summary>
        /// Should the mouse move at provided screen point be allowed.
        /// </summary>
        /// <param name="m">Original message.</param>
        /// <param name="pt">Client coordinates point.</param>
        /// <returns>True to allow; otherwise false.</returns>
        public override bool AllowMouseMove(Message m, Point pt)
        {
            // We allow all mouse moves when we are showing
            return true;
        }

        /// <summary>
        /// Use the setting from the Positioning to display the tooltip
        /// </summary>
        /// <param name="target"></param>
        /// <param name="controlMousePosition"></param>
        public void ShowRelativeTo(ViewBase target, Point controlMousePosition)
        {
            PopupPositionValues position;
            if (_contentValues is ToolTipValues toolTipValues)
            {
                position = toolTipValues.ToolTipPosition;
            }
            else
            {
                position = new();
            }
            Point currentCursorHotSpot = CommonHelper.CaptureCursor();

            Rectangle positionPlacementRectangle = position.PlacementRectangle;
            switch (position.PlacementMode)
            {
                case PlacementMode.Absolute:
                case PlacementMode.AbsolutePoint:
                    // The screen, or PlacementRectangle if it is set.
                    // So do nothing !
                    break;
                case PlacementMode.Mouse:
                case PlacementMode.MousePoint:
                    // The bounds of the mouse pointer. PlacementRectangle is ignored
                    positionPlacementRectangle = new(controlMousePosition.X, controlMousePosition.Y, currentCursorHotSpot.X + 2, currentCursorHotSpot.Y + 2);
                    break;
                default:
                    // The screen, or PlacementRectangle if it is set. The PlacementRectangle is relative to the screen.
                    if (positionPlacementRectangle.IsEmpty)
                    {
                        // PlacementTarget or parent.
                        positionPlacementRectangle =
                            position.PlacementTarget?.ClientRectangle ?? target.ClientRectangle;
                        positionPlacementRectangle = (position.PlacementTarget?.OwningControl ?? target.OwningControl).RectangleToScreen(positionPlacementRectangle);
                    }
                    else
                    {
                        positionPlacementRectangle = Screen.GetWorkingArea(controlMousePosition);
                    }
                    break;
            }

            // Get the size the popup would like to be
            Size popupSize = ViewManager.GetPreferredSize(Renderer, Size.Empty);
            Point popupLocation;

            switch (position.PlacementMode)
            {
                case PlacementMode.Absolute:
                case PlacementMode.AbsolutePoint:
                case PlacementMode.MousePoint:
                case PlacementMode.Relative:
                case PlacementMode.RelativePoint:
                    // The top-left corner of the target area.     The top-left corner of the Popup.
                    popupLocation = positionPlacementRectangle.Location;
                    if (positionPlacementRectangle.IntersectsWith(new(controlMousePosition, (Size)currentCursorHotSpot)))
                    {
                        // TODO: SKC: Should really get the HotSpot from the Icon and use that !
                        popupLocation.X = controlMousePosition.X + 4; // Still might "Bounce back" due to offscreen location
                    }
                    break;
                case PlacementMode.Bottom:
                case PlacementMode.Mouse:
                    // The bottom-left corner of the target area.     The top-left corner of the Popup.
                    popupLocation = new(positionPlacementRectangle.Left, positionPlacementRectangle.Bottom);
                    break;
                case PlacementMode.Center:
                    // The center of the target area.     The center of the Popup.
                    popupLocation = positionPlacementRectangle.Location;
                    popupLocation.Offset(popupSize.Width / 2, -popupSize.Height / 2);
                    if (positionPlacementRectangle.IntersectsWith(new(controlMousePosition, (Size)currentCursorHotSpot)))
                    {
                        // TODO: SKC: Should really get the HotSpot from the Icon and use that !
                        popupLocation.X = controlMousePosition.X + 4; // Still might "Bounce back" due to offscreen location
                    }
                    break;
                case PlacementMode.Left:
                    // The top-left corner of the target area.     The top-right corner of the Popup.
                    popupLocation = new(positionPlacementRectangle.Left - popupSize.Width, positionPlacementRectangle.Top);
                    break;
                case PlacementMode.Right:
                    // The top-right corner of the target area.     The top-left corner of the Popup.
                    popupLocation = new(positionPlacementRectangle.Right, positionPlacementRectangle.Top);
                    break;
                case PlacementMode.Top:
                    // The top-left corner of the target area.     The bottom-left corner of the Popup.
                    popupLocation = new(positionPlacementRectangle.Left, positionPlacementRectangle.Top - popupSize.Height);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            // Show it now!
            Show(popupLocation, popupSize);

        }

        /// <summary>
        /// Show the tooltip popup relative to the provided screen position.
        /// </summary>
        /// <param name="controlMousePosition">Screen point of cursor.</param>
        public void ShowCalculatingSize(Point controlMousePosition)
        {
            // Get the size the popup would like to be
            Size popupSize = ViewManager.GetPreferredSize(Renderer, Size.Empty);

            // Find the screen position the popup will be relative to
            Point currentCursorHotSpot = CommonHelper.CaptureCursor();
            controlMousePosition.Offset(currentCursorHotSpot.X + 2, currentCursorHotSpot.Y + 2);
            // Show it now!
            Show(controlMousePosition, popupSize);
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the Layout event.
        /// </summary>
        /// <param name="lEvent">An EventArgs that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs lEvent)
        {
            // Let base class calculate fill rectangle
            base.OnLayout(lEvent);

            // Need a render context for accessing the renderer
            using (RenderContext context = new(this, null, ClientRectangle, Renderer))
            {

                // Grab a path that is the outside edge of the border
                Rectangle borderRect = ClientRectangle;
                GraphicsPath borderPath1 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _palette.Border, VisualOrientation.Top, PaletteState.Normal);
                borderRect.Inflate(-1, -1);
                GraphicsPath borderPath2 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _palette.Border, VisualOrientation.Top, PaletteState.Normal);
                borderRect.Inflate(-1, -1);
                GraphicsPath borderPath3 = Renderer.RenderStandardBorder.GetOutsideBorderPath(context, borderRect, _palette.Border, VisualOrientation.Top, PaletteState.Normal);

                // Update the region of the popup to be the border path
                Region = new(borderPath1);

                // Inform the shadow to use the same paths for drawing the shadow
                DefineShadowPaths(borderPath1, borderPath2, borderPath3);
            }
        }
        #endregion
    }
}