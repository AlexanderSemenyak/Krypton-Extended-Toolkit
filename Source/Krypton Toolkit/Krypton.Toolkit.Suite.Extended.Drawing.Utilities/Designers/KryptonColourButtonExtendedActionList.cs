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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    internal class KryptonColourButtonExtendedActionList : DesignerActionList
    {
        #region Variables
        private readonly KryptonColourButtonExtended _colourButton;

        private readonly IComponentChangeService _service;
        #endregion

        #region Constructor
        public KryptonColourButtonExtendedActionList(KryptonColourButtonExtendedDesigner owner) : base(owner.Component)
        {
            _colourButton = owner.Component as KryptonColourButtonExtended;

            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Properties
        public ButtonStyle ButtonStyle
        {
            get => _colourButton.ButtonStyle;

            set
            {
                if (_colourButton.ButtonStyle != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.ButtonStyle, value);

                    _colourButton.ButtonStyle = value;
                }
            }
        }

        public VisualOrientation ButtonOrientation
        {
            get => _colourButton.ButtonOrientation;

            set
            {
                if (_colourButton.ButtonOrientation != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.ButtonOrientation, value);

                    _colourButton.ButtonOrientation = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the visual drop down position.
        /// </summary>
        public VisualOrientation DropDownPosition
        {
            get => _colourButton.DropDownPosition;

            set
            {
                if (_colourButton.DropDownPosition != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.DropDownPosition, value);
                    _colourButton.DropDownPosition = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the visual drop down orientation.
        /// </summary>
        public VisualOrientation DropDownOrientation
        {
            get => _colourButton.DropDownOrientation;

            set
            {
                if (_colourButton.DropDownOrientation != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.DropDownOrientation, value);
                    _colourButton.DropDownOrientation = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the splitter or drop down functionality.
        /// </summary>
        public bool Splitter
        {
            get => _colourButton.Splitter;

            set
            {
                if (_colourButton.Splitter != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.Splitter, value);
                    _colourButton.Splitter = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        public string Text
        {
            get => _colourButton.Values.Text;

            set
            {
                if (_colourButton.Values.Text != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.Values.Text, value);
                    _colourButton.Values.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the extra button text.
        /// </summary>
        public string ExtraText
        {
            get => _colourButton.Values.ExtraText;

            set
            {
                if (_colourButton.Values.ExtraText != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.Values.ExtraText, value);
                    _colourButton.Values.ExtraText = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button image.
        /// </summary>
        public Image Image
        {
            get => _colourButton.Values.Image;

            set
            {
                if (_colourButton.Values.Image != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.Values.Image, value);
                    _colourButton.Values.Image = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the palette mode.
        /// </summary>
        public PaletteMode PaletteMode
        {
            get => _colourButton.PaletteMode;

            set
            {
                if (_colourButton.PaletteMode != value)
                {
                    _service.OnComponentChanged(_colourButton, null, _colourButton.PaletteMode, value);
                    _colourButton.PaletteMode = value;
                }
            }
        }
        #endregion

        #region Overrides
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create a new collection for holding the single item we want to create
            DesignerActionItemCollection actions = new DesignerActionItemCollection();

            // This can be null when deleting a control instance at design time
            if (_colourButton != null)
            {
                // Add the list of button specific actions
                actions.Add(new DesignerActionHeaderItem("Appearance"));
                actions.Add(new DesignerActionPropertyItem("Splitter", "Splitter", "Appearance", "Splitter of DropDown"));
                actions.Add(new DesignerActionPropertyItem("ButtonStyle", "ButtonStyle", "Appearance", "Button style"));
                actions.Add(new DesignerActionPropertyItem("ButtonOrientation", "ButtonOrientation", "Appearance", "Button orientation"));
                actions.Add(new DesignerActionPropertyItem("DropDownPosition", "DropDownPosition", "Appearance", "DropDown position"));
                actions.Add(new DesignerActionPropertyItem("DropDownOrientation", "DropDownOrientation", "Appearance", "DropDown orientation"));
                actions.Add(new DesignerActionHeaderItem("Values"));
                actions.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Button text"));
                actions.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Button extra text"));
                actions.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Button image"));
                actions.Add(new DesignerActionHeaderItem("Visuals"));
                actions.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
            }

            return actions;
        }
        #endregion
    }
}