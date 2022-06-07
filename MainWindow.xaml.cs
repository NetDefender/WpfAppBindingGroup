using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppPerformance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ViewModelMain _vm;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new()
            {
                Child = new ViewModelChild
                {
                    Count = 100
                }
            };
            ValidationMain validation = new ValidationMain(_vm.Validate);
            binding.ValidationRules.Add(validation);
            DataContext = _vm;
            binding.BeginEdit();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            binding.CancelEdit();
        }

        private void Window_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void btoSave_Click(object sender, RoutedEventArgs e)
        {
            if (binding.CommitEdit())
            {
                MessageBox.Show("Updated Succesfully!");
                binding.BeginEdit();
            }
        }

        private void btoReset_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Has Changes ?{binding.IsDirty}");
            binding.CancelEdit();
            binding.BeginEdit();
        }

        private void btoChangeChild_Click(object sender, RoutedEventArgs e)
        {
            //_vm.Child = new ViewModelChild
            //{
            //    Count = -1
            //};
            //_vm.Child.Count = -1;
        }
    }
}