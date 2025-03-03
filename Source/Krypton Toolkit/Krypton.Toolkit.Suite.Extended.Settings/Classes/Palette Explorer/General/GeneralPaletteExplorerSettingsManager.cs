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

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class GeneralPaletteExplorerSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private GeneralPaletteExplorerSettings _generalPaletteExplorerSettings = new();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [always use prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [always use prompt]; otherwise, <c>false</c>.
        /// </value>
        public bool AlwaysUsePrompt
        {
            get => _alwaysUsePrompt;

            set => _alwaysUsePrompt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [settings modified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modified]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModified
        {
            get => _settingsModified;

            set => _settingsModified = value;
        }
        #endregion

        #region Settings Manipulation
        /// <summary>
        /// Sets the value of AlwaysUsePrompt to value.
        /// </summary>
        /// <param name="value">The value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value)
        {
            AlwaysUsePrompt = value;
        }

        /// <summary>
        /// Returns the value of AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt()
        {
            return AlwaysUsePrompt;
        }

        /// <summary>
        /// Sets the value of SettingsModified to value.
        /// </summary>
        /// <param name="value">The value of SettingsModified.</param>
        public void SetSettingsModified(bool value)
        {
            SettingsModified = value;
        }

        /// <summary>
        /// Returns the value of SettingsModified.
        /// </summary>
        /// <returns>The value of SettingsModified.</returns>
        public bool GetSettingsModified()
        {
            return SettingsModified;
        }
        #endregion

        #region Constructors
        public GeneralPaletteExplorerSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of ShowAdvancedDetails to value.
        /// </summary>
        /// <param name="value">The value of ShowAdvancedDetails.</param>
        public void SetShowAdvancedDetails(bool value)
        {
            _generalPaletteExplorerSettings.ShowAdvancedDetails = value;
        }

        /// <summary>
        /// Returns the value of ShowAdvancedDetails.
        /// </summary>
        /// <returns>The value of ShowAdvancedDetails.</returns>
        public bool GetShowAdvancedDetails()
        {
            return _generalPaletteExplorerSettings.ShowAdvancedDetails;
        }

        /// <summary>
        /// Sets the value of ShowColourPropertiesPane to value.
        /// </summary>
        /// <param name="value">The value of ShowColourPropertiesPane.</param>
        public void SetShowColourPropertiesPane(bool value)
        {
            _generalPaletteExplorerSettings.ShowColourPropertiesPane = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of ShowColourPropertiesPane.
        /// </summary>
        /// <returns>The value of ShowColourPropertiesPane.</returns>
        public bool GetShowColourPropertiesPane()
        {
            return _generalPaletteExplorerSettings.ShowColourPropertiesPane;
        }

        /// <summary>
        /// Sets the value of ShowPalettePropertiesPane to value.
        /// </summary>
        /// <param name="value">The value of ShowPalettePropertiesPane.</param>
        public void SetShowPalettePropertiesPane(bool value)
        {
            _generalPaletteExplorerSettings.ShowPalettePropertiesPane = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of ShowPalettePropertiesPane.
        /// </summary>
        /// <returns>The value of ShowPalettePropertiesPane.</returns>
        public bool GetShowPalettePropertiesPane()
        {
            return _generalPaletteExplorerSettings.ShowPalettePropertiesPane;
        }

        /// <summary>
        /// Sets the value of ShowCircularDisplay to value.
        /// </summary>
        /// <param name="value">The value of ShowCircularDisplay.</param>
        public void SetShowCircularDisplay(bool value)
        {
            _generalPaletteExplorerSettings.ShowCircularDisplay = value;
        }

        /// <summary>
        /// Returns the value of ShowCircularDisplay.
        /// </summary>
        /// <returns>The value of ShowCircularDisplay.</returns>
        public bool GetShowCircularDisplay()
        {
            return _generalPaletteExplorerSettings.ShowCircularDisplay;
        }

        /// <summary>
        /// Sets the value of ShowStandardDisplay to value.
        /// </summary>
        /// <param name="value">The value of ShowStandardDisplay.</param>
        public void SetShowStandardDisplay(bool value)
        {
            _generalPaletteExplorerSettings.ShowStandardDisplay = value;
        }

        /// <summary>
        /// Returns the value of ShowStandardDisplay.
        /// </summary>
        /// <returns>The value of ShowStandardDisplay.</returns>
        public bool GetShowStandardDisplay()
        {
            return _generalPaletteExplorerSettings.ShowStandardDisplay;
        }

        /// <summary>
        /// Sets the value of DefaultColour to colour.
        /// </summary>
        /// <param name="colour">The value of DefaultColour.</param>
        public void SetDefaultColour(Color colour)
        {
            _generalPaletteExplorerSettings.DefaultColour = colour;
        }

        /// <summary>
        /// Returns the value of DefaultColour.
        /// </summary>
        /// <returns>The value of DefaultColour.</returns>
        public Color GetDefaultColour()
        {
            return _generalPaletteExplorerSettings.DefaultColour;
        }

        /// <summary>
        /// Sets the value of DisplayIndex to value.
        /// </summary>
        /// <param name="value">The value of DisplayIndex.</param>
        public void SetDisplayIndex(int value)
        {
            _generalPaletteExplorerSettings.DisplayIndex = value;
        }

        /// <summary>
        /// Returns the value of DisplayIndex.
        /// </summary>
        /// <returns>The value of DisplayIndex.</returns>
        public int GetDisplayIndex()
        {
            return _generalPaletteExplorerSettings.DisplayIndex;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (ExtendedKryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetShowAdvancedDetails(false);

                SetShowColourPropertiesPane(false);

                SetShowPalettePropertiesPane(false);

                SetShowCircularDisplay(false);

                SetShowStandardDisplay(true);

                SetDefaultColour(Color.Transparent);

                SetDisplayIndex(0);

                SaveGeneralPaletteExplorerSettings();

                if (ExtendedKryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the general palette explorer settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveGeneralPaletteExplorerSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (ExtendedKryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _generalPaletteExplorerSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _generalPaletteExplorerSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}