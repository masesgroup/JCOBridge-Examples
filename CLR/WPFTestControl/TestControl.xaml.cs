using System;
using System.Windows;
using System.Windows.Controls;

namespace MASES.CLRTests.WPFTestControl
{
    public class WPFTestControlEventArgs : EventArgs
    {
        public WPFTestControlEventArgs(string content)
        {
            Content = content;
        }

        public string Content { get; private set; }
    }

    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : DockPanel
    {
        public TestControl()
        {
            InitializeComponent();
            cbContent.ItemsSource = new string[] { "One", "Two", "Three", "Four" };
        }

        private void btnSelectFromTextBox_Click(object sender, RoutedEventArgs e)
        {
            FromTextBox?.Invoke(this, new WPFTestControlEventArgs(contentBox.Text));
        }

        private void btnSelectFromComboBox_Click(object sender, RoutedEventArgs e)
        {
            FromComboBox?.Invoke(this, new WPFTestControlEventArgs(cbContent.SelectedItem as string));
        }

        public event EventHandler<WPFTestControlEventArgs> FromTextBox;
        public event EventHandler<WPFTestControlEventArgs> FromComboBox;
    }
}
