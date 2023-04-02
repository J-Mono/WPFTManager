using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Time_Management_App__POE_
{
    /// <summary>
    /// Interaction logic for ModulesEntered.xaml
    /// </summary>
    public partial class ModulesEntered : Window
    {
        public ModulesEntered()
        {
            InitializeComponent();
            displayUserData();//calling the diplay method for the data grid
        }
        //method that display data on the data grid
        private void displayUserData()
        {
            //creating a new thread for the method
            //A thread is a known as the execution path of the program (tutorialspoint, 2021). 
            //a program is not limited to one thread;
            //it can have multiple threads in order to reduce time consumed for time consuming operations (tutorialspoint, 2021).
            Dispatcher.BeginInvoke(
                new ThreadStart(() => dgvUserData.ItemsSource = Modules.moduleList));// modules data is shared to the datagrid for modules.xml
        }
        //event handler for the back button
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WelcomePage BackToHome = new WelcomePage();//take us back to main window
            BackToHome.ShowDialog();
        }
    }
}
