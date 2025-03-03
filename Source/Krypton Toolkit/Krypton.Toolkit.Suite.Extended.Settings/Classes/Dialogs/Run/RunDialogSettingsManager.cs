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

using Krypton.Toolkit.Suite.Extended.Settings.Run;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class RunDialogSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private RunDialogSettings _runDialogSettings = new();
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

        #region Constructors
        public RunDialogSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the AlwaysUsePrompt to the value of value.
        /// </summary>
        /// <param name="value">The desired value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value) => AlwaysUsePrompt = value;

        /// <summary>
        /// Returns the value of the AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of the AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt() => AlwaysUsePrompt;

        /// <summary>
        /// Sets the SettingsModified to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SettingsModified.</param>
        public void SetSettingsModified(bool value) => SettingsModified = value;

        /// <summary>
        /// Returns the value of the SettingsModified.
        /// </summary>
        /// <returns>The value of the SettingsModified.</returns>
        public bool GetSettingsModified() => SettingsModified;

        /// <summary>
        /// Sets the AlwaysElevateNewTasks.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAlwaysElevateNewTasks(bool value) => _runDialogSettings.AlwaysElevateNewTasks = value;

        /// <summary>
        /// Gets the AlwaysElevateNewTasks.
        /// </summary>
        /// <returns>The value of _runDialogSettings.AlwaysElevateNewTasks.</returns>
        public bool GetAlwaysElevateNewTasks() => _runDialogSettings.AlwaysElevateNewTasks;

        /// <summary>
        /// Sets the AlwaysShowSettingsButton.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAlwaysShowSettingsButton(bool value) => _runDialogSettings.AlwaysShowSettingsButton = value;

        /// <summary>
        /// Gets the AlwaysShowSettingsButton.
        /// </summary>
        /// <returns>The value of _runDialogSettings.AlwaysShowSettingsButton.</returns>
        public bool GetAlwaysShowSettingsButton() => _runDialogSettings.AlwaysShowSettingsButton;

        /// <summary>
        /// Sets the AlwaysShowProcessIcon.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAlwaysShowProcessIcon(bool value) => _runDialogSettings.AlwaysShowProcessIcon = value;

        /// <summary>
        /// Gets the AlwaysShowProcessIcon.
        /// </summary>
        /// <returns>The value of _runDialogSettings.AlwaysShowProcessIcon.</returns>
        public bool GetAlwaysShowProcessIcon() => _runDialogSettings.AlwaysShowProcessIcon;

        /// <summary>
        /// Sets the UseLaunchProcessArguements.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetUseLaunchProcessArguements(bool value) => _runDialogSettings.UseLaunchProcessArguements = value;

        /// <summary>
        /// Gets the UseLaunchProcessArguements.
        /// </summary>
        /// <returns>The value of _runDialogSettings.UseLaunchProcessArguements.</returns>
        public bool GetUseLaunchProcessArguements() => _runDialogSettings.UseLaunchProcessArguements;
        #endregion

        #region Methods
        /// <summary>Resets to defaults.</summary>
        public void ResetToDefaults()
        {
            DialogResult result = ExtendedKryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                SetAlwaysElevateNewTasks(false);

                SetAlwaysShowProcessIcon(true);

                SetAlwaysShowSettingsButton(true);

                SetUseLaunchProcessArguements(false);

                SaveRunDialogSettings(GetAlwaysUsePrompt());

                if (ExtendedKryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the run dialog settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveRunDialogSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (ExtendedKryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _runDialogSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _runDialogSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}