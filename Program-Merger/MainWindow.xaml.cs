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

namespace Program_Merger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left){
                this.DragMove();
            }
                    
        }
        public void btn1_Click(object sender, RoutedEventArgs e){
            Processes.closeProgram();
        }

        public void Add_Click(object sender, RoutedEventArgs e){
            Processes.addProgram();
        }

        public void AddX_Click(object sender, RoutedEventArgs e){
            Processes.addAgain();
        }

        public void Save_Click(object sender, RoutedEventArgs e){
            Processes.saveFile();
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}
