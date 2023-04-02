using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Threading;

namespace Time_Management_App__POE_
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        byte[] hashValue;
        public Registration()
        {
            InitializeComponent();
        }
        //event handler for the login button on this page
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();//on click the page changes to a login page
            login.Show();//this allows the login page to show
            Close();
        }
        //the method is the event handler for the reset button
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();//calling the reset method
        }
        //reset method
        public void Reset()
        {
            //if reset button is clicked the texbox values are set to being blank
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        //if the cancel button is clicked, the page will close
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //The eventhandler for the submit button
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //if there is nothing typed in email and you click submit
            //An if else statement is used to make decisions based on a condition that was set(Thompson, 2021)
            if (textBoxEmail.Text.Length == 0)
            {
                //the page will ask for you enter email
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            //the page also checks for invalid characaters in the email and...
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                //...provides an error message should there be an invalid character
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                //creating variable for the storing the values enetered in the textboxes
                //Variables are containers for storing data (w3schools, 2021)
                string name = textBoxFirstName.Text;
                string surname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                //An if else statement is used to make decisions based on a condition that was set (Thompson, 2021)
                if (passwordBox1.Password.Length == 0)
                {
                    //if there is no password, the page will ask for the password
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                //if the confrim password box is empty
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    //the page will ask for the password
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                //if the passwords on both password boxes do not match
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    //the page will confirm that the passwords do not match
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                //otherwise
                else
                {
                    //if everything is okay...
                    errormessage.Text = "";//no error message

                    //the password will be stored in a hash
                    //----------------------------------------------
                    UnicodeEncoding ue = new UnicodeEncoding();

                    //Convert the string into an array of bytes.
                    byte[] messageBytes = ue.GetBytes(password);

                    //Create a new instance of the SHA256 class to create
                    //the hash value.
                    SHA256 shHash = SHA256.Create();

                    //Create the hash value from the array of bytes.
                    hashValue = shHash.ComputeHash(messageBytes);
                    //------------------------------------------------------

                    //creating a new connection to the database
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Time_Management;Integrated Security=True");
                    con.Open();//opeing the connection
                    //creating a new sql command
                    SqlCommand cmd = new SqlCommand("Insert into Students (Name, Surname, Email, Password) " +
                        "values('" + name + "','" + surname + "','" + email + "','" + hashValue + "')", con);
                    cmd.CommandType = CommandType.Text;//setting the command data type to a string. hence a text
                    cmd.ExecuteNonQuery();
                    con.Close();//closing the connection when the query is excepted
                    errormessage.Text = "You have Registered successfully.";//message will say there was a successful registration
                    Reset();//page will reset and new user data has been stored
                }
            }
        }
    }
}
