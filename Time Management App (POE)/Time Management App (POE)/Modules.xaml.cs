using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using ClassLibraryForPoe;

namespace Time_Management_App__POE_
{
    /// <summary>
    /// Interaction logic for Modules.xaml
    /// </summary>
    public partial class Modules : Window
    {
        //creating a new module info object
        public ModuleInfo info = new ModuleInfo();
        //creating a list for module info called module list
        public static List<ModuleInfo> moduleList = new List<ModuleInfo>();

        //row counter for modulelist
        static int row = 0;
        public Modules()
        {
            InitializeComponent();
        }
        //for adding a module
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            //read values into user info from the textboxes
            info.Module_code = Module_code.Text;
            info.Name = Name.Text;
            info.Credit = Credit.Text;
            info.Class_Hours = Class_Hours.Text;
            info.Nr_of_weeks = Convert.ToInt32(Nr_Weeks.Text);
            //add object to the list
            moduleList.Add(info);
            MessageBox.Show("Module info was added");

            //opening an sql connection in order to store Module_Code, Module_Name, Credits, Class_hours_per_week 
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Time_Management;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Modules (Module_Code, Module_Name, Credits, Class_hours_per_week) " +
                "values('" + info.Module_code + "','" + info.Name + "','" + info.Credit + "','" + info.Class_Hours + "')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();//closing connection

            //opening an sql connection in order to store Hours_spent, Study_Hour_required, Remain_hours, Module_Code
            SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=Time_Management;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Insert into Study_Hours (Hours_spent, Study_Hour_required, Remain_hours, Module_Code) " +
                "values('" + info.hoursStudied + "','" + info.study_hours_required + "','" + info.RemainingStudyHours + "','" + info.Module_code + "')", con1);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            con1.Close();//closing connection

            this.Hide();//hiding the page
            ModulesEntered moduleDisplay = new ModulesEntered();//takes us to modules entered page
            moduleDisplay.ShowDialog();//showing the modules entered
        }
        
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            //this methods calculates the self study hours per week
            int Credits = Convert.ToInt32(Credit.Text);
            int Nr_of_weeks = Convert.ToInt32(Nr_Weeks.Text);
            int class_hp = Convert.ToInt32(Class_Hours.Text);

            //calling class library that stores the calculation for 
            //study hours
            CalculateSelfStudy cm = new CalculateSelfStudy();

            info.study_hours_required = cm.calcStudyHours(Credits, Nr_of_weeks, class_hp).ToString();
            MessageBox.Show("Study Hours Required: " + info.study_hours_required);//showing the study hours required
        }

        private void Calculate1_Click(object sender, RoutedEventArgs e)
        {
            //this method calculates the remaining study hours left after
            //study hours has been calculated
            info.hoursStudied = Convert.ToInt32(Hours_Spent.Text);
            info.RemainingStudyHours = Convert.ToInt32(info.study_hours_required) - info.hoursStudied;

            //displaying remaing study hours in a message box
            MessageBox.Show("Remaining Hours: " + info.RemainingStudyHours.ToString());//showiing remaining stud hours
        }
        //The evenet handler for the back button
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WelcomePage BackToHome = new WelcomePage();//takes us back to main window
            BackToHome.ShowDialog();
        }
    }

}
