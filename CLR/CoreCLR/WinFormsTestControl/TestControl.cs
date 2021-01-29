using System;
using System.Windows.Forms;

namespace MASES.CLRTests.WinFormsTestControl
{
    public partial class TestControl : UserControl
    {
        public TestControl()
        {
            InitializeComponent();
        }

        public event EventHandler<WinFormsTestControlEventArgs> FromTextBox;
        public event EventHandler<WinFormsTestControlEventArgs> FromComboBox;

        private void btnSelectFromComboBox_Click(object sender, EventArgs e)
        {
            FromComboBox?.Invoke(this, new WinFormsTestControlEventArgs(cbContent.SelectedItem as string));
        }

        private void btnSelectFromTextBox_Click(object sender, EventArgs e)
        {
            FromTextBox?.Invoke(this, new WinFormsTestControlEventArgs(contentBox.Text));
        }
    }
}
