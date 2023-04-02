using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Threading;

namespace Time_Management_App__POE_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creating the varibale to sotre the hash of the user password
        byte[] hashValue;
        public MainWindow()
        {
            InitializeComponent();
        }
        //creating a new registration object
        Registration registration = new Registration();
        //creating  a new welcomepage objetc
        WelcomePage welcome = new WelcomePage();

        //eventhandler for the login button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //if the email text lenght is equal to 0
            if (textBoxEmail.Text.Length == 0)
            {
                //it will request the user to enter an email
                //this is if the user leaves the email block blank
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            //if the is an invalid character in the email
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                //it will ask the user to enter the email
                //in this case the user will have to re-enter the email
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                //creating variables to store email and password
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;

                //Hashing the password from visual studio
                //-----------------------------------------------------------------------
                UnicodeEncoding ue = new UnicodeEncoding();

                //Convert the string into an array of bytes.
                byte[] messageBytes = ue.GetBytes(password);

                //Create a new instance of the SHA256 class to create
                //the hash value.
                //SHA256 is the base class for hash algorithms (Chand, 2020).
                //Hashing is the mapping a binary string to a binary string of a fixed length, called a hash value (Chand, 2020).
                SHA256 shHash = SHA256.Create();

                //Create the hash value from the array of bytes.
                hashValue = shHash.ComputeHash(messageBytes);
                //-------------------------------------------------------------------------


                //Creating a new sql connections
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Time_Management;Integrated Security=True");
                //openign the connection
                con.Open();
                //creating a command
                SqlCommand cmd = new SqlCommand("Select * from Students where Email='" + email + "'  and Password='" + hashValue + "'", con);
                //setting the datatype for the command to a string(text)
                cmd.CommandType = CommandType.Text;
                //Creating a new adapter
                SqlDataAdapter adapter = new SqlDataAdapter();
                //the adapter selects the command
                adapter.SelectCommand = cmd;
                //creating a new data set object
                DataSet dataSet = new DataSet();
                //fillng the adapter 
                adapter.Fill(dataSet);
                //the value in the data set is greater than 0
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["Name"].ToString() + " " + dataSet.Tables[0].Rows[0]["Surname"].ToString();
                    welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                    welcome.Show();//allowing the class to show the result
                    Close();
                }
                else
                {
                    //if there is ana error
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }
                con.Close();//closing the sql connection
            }
        }
        //event handler for the register button
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();//will display the register page
            Close();
        }
    }
}
