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
using Examples.Properties;

using Krypton.Toolkit.Suite.Extended.Dialogs;
using Krypton.Toolkit.Suite.Extended.Specialised.Dialogs;

namespace Examples
{
    public partial class DialogExamples : KryptonForm
    {
        public DialogExamples()
        {
            InitializeComponent();
        }

        private void kbtnException_Click(object sender, EventArgs e)
        {
            //KryptonExceptionCaptureDialog exceptionCaptureDialog = new KryptonExceptionCaptureDialog();

            //exceptionCaptureDialog.ShowDialog();
        }

        private void kbtnCheckSum_Click(object sender, EventArgs e)
        {
            KryptonPropertiesForm propertiesForm = new KryptonPropertiesForm();

            propertiesForm.ShowDialog();
        }

        private void kbtnRun_Click(object sender, EventArgs e)
        {
            //KryptonRunDialog runDialog = new KryptonRunDialog(RunDialogStartPosition.BottomLeft, true, true, true);

            Krypton.Toolkit.Suite.Extended.Specialised.Dialogs.KryptonRunDialog runDialog =
                new Krypton.Toolkit.Suite.Extended.Specialised.Dialogs.KryptonRunDialog(null, RunDialogIconVisibility.Visible, RunDialogType.Textbox);

            runDialog.ShowDialog();
        }

        private void kbtnSplash_Click(object sender, EventArgs e)
        {
            KryptonSplashDialog splashDialog = new KryptonSplashDialog(true, @"Extended Toolkit Test App", Resources.Stable);

            splashDialog.ShowDialog();
        }

        private void kbtnTextToSpeech_Click(object sender, EventArgs e)
        {
            KryptonTextToSpeechDialog textToSpeechDialog = new KryptonTextToSpeechDialog();

            textToSpeechDialog.ShowDialog();
        }
    }
}
