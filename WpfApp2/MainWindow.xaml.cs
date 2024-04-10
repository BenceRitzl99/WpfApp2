using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string password = "";
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(1000);
            //string[] args = System.Environment.GetCommandLineArgs();
            //if (args.Length == 3)
            //{
            //    MessageBox.Show("Argumentumok: " + String.Join(", ", args));
            //    tbLogin.Text = args[1];
            //    tbPassword.Text = args[2];
            //}
            //else MessageBox.Show("Nincsenek Argumentumok!");
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)  //properties két click így hozom létre ezeket
        {
            this.DragMove();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
           IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Kulkertechnikum.txt", System.IO.FileMode.Append, isf);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(tbLogin + "; " + tbPassword.Text + "; " + DateTime.Now);


            sw.Close();
            fs.Close();
            isf.Close();

            MessageBox.Show("Bejelentkezés sikeres!");

            CanvasWindow cw = new CanvasWindow();
        }
        private void tbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Equals("Username")) tbLogin.Text = "";
        }

        private void tbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Equals("")) tbLogin.Text = "Username";
        }


        private void tbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text.Equals("Password")) tbPassword.Text = "";
        }
        private void tbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text.Equals("")) tbPassword.Text = "Password";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetMachineStoreForApplication();
            IsolatedStorageFileStream fs = new IsolatedStorageFileStream("Kulkertechnikum.txt", System.IO.FileMode.Append, isf);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(tbLogin + "; " + tbPassword.Text + "; " + DateTime.Now);


            sw.Close();
            fs.Close();
            isf.Close();

            MessageBox.Show("Bejelentkezés sikeres!");
        }

        //private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        //{
        //MessageBox.Show(e.Key.ToString()+":"+ e.SystemKey);
        //if ((e.Key.ToString().Length == 1)) {
        //tbPassword.Text += "*";
        //password += e.Key.ToString();
        //lbPassword.Content=password;
        //}
        //}
    }
}
