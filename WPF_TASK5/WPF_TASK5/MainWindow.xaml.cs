using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_TASK5.ViewModels;

namespace WPF_TASK5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FormViewModel _vm = new FormViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Name: {_vm.Name}, Email: {_vm.Email}, Age: {_vm.Age}", 
                "Data recieved");
        }
    }
}