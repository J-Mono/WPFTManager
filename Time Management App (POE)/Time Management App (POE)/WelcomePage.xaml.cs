using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Window
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
        private void My_Modules_Click(object sender, RoutedEventArgs e)
        {
            //on click the current page will dissapper
            this.Hide();
            //then a new window will be opened so that module information can be displayed
            ModulesEntered moduleDisplay = new ModulesEntered();
            moduleDisplay.ShowDialog();
        }

        //Event handler for the study houre button
        private void Add_Modules_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Modules studiesDisplay = new Modules();//a new module page is opened, on click
            studiesDisplay.ShowDialog();
        }

        private void Log_Out_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow ReturnToLogin = new MainWindow();//a new module page is opened, on click
            ReturnToLogin.ShowDialog();
        }
    }
}
