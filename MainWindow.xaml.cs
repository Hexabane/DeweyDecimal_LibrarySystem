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

namespace DeweySystem
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

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {//start of mouse enter.

            // Set ToolTip Visibility
            if (Tg_Btn.IsChecked == true)
            {//start of first if statement


                tt_RBV.Visibility = Visibility.Collapsed;
                tt_IAV.Visibility = Visibility.Collapsed;
                tt_FCN.Visibility = Visibility.Collapsed;
                tt_logout.Visibility = Visibility.Collapsed;


            }//end of second if statement

            else
            {//start if elese statement

                tt_RBV.Visibility = Visibility.Visible;
                tt_IAV.Visibility = Visibility.Visible;
                tt_FCN.Visibility = Visibility.Visible;
                tt_logout.Visibility = Visibility.Visible;


            }//end of else statement



        }//end of mouse enter

        ////(Design Pro, 2020) **REFERENCE IN REFERENCE LIST**
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }


        //Button Click event for when the user clicks the exit button and it exits the application.
        private void Click_ButtonExit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to Log Out?", "Logging Out", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                MessageBox.Show("Thank you for using this application!", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

    }
}
