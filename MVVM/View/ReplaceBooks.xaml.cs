using DeweySystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DeweySystem.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : UserControl
    {//Start of Class ReplaceBooks

        //global variables created to store listbox values
        List<string> ListBoxRecValues = new List<string>();
        ListBox dragSource = null;

        public ReplaceBooks()
        {
            InitializeComponent();
            PopulateListBox();
            PopulateAchievement();
        }

    
        //Action Method for when left mouse click is held down on the lb_send Listbox
        private void lbSend_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//start of lbSendActionMethod
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }//end of lbSendActionMethod

        //Method that gets data from the list box from which the item has been dragged from.
        private object GetDataFromListBox(ListBox source, Point point)
        {//start of GetDataFromListBox()
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }//end of GetDataFromListBox()

        //Action Method of the listbox reciving the dragged item from the other listbox
        private void lbRec_Drop(object sender, DragEventArgs e)
        {//start of lbRecActionMethod.

            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));
            lbSend.Items.Remove(data);
            parent.Items.Add(data);

        }//end of lbRecActionMethod.

        //Action Method for the Up Button to move the items in the list box UP.
        private void Button_Up(object sender, RoutedEventArgs e)
        {//start of Button_Up Method
            ListBoxRecValues = new List<string>();

            foreach (var item in lbRec.Items)
            {
                ListBoxRecValues.Add(item.ToString());
            }
            var selectedIndex = this.lbRec.SelectedIndex;

            if (selectedIndex > 0)
            {
                var itemToMoveUp = this.ListBoxRecValues[selectedIndex];
                ListBoxRecValues.RemoveAt(selectedIndex);
                ListBoxRecValues.Insert(selectedIndex - 1, itemToMoveUp);
                lbRec.SelectedIndex = selectedIndex - 1;
                lbRec.Items.Clear();
                foreach (var item in ListBoxRecValues)
                {
                    lbRec.Items.Add(item.ToString());
                }

            }

        }//end of Button_Up() Method

        //Action Method for the Down Button to move the items in the list box DOWN.
        private void Button_Down(object sender, RoutedEventArgs e)
        {//start of Button_Down Method
            ListBoxRecValues = new List<string>();

            foreach (var item in lbRec.Items)
            {
                ListBoxRecValues.Add(item.ToString());
            }

            var selectedIndex = lbRec.SelectedIndex;

            if (selectedIndex + 1 < ListBoxRecValues.Count)
            {
                var itemToMoveDown = ListBoxRecValues[selectedIndex];
                ListBoxRecValues.RemoveAt(selectedIndex);
                ListBoxRecValues.Insert(selectedIndex + 1, itemToMoveDown);
                lbRec.SelectedIndex = selectedIndex + 1;
                lbRec.Items.Clear();
                foreach (var item in ListBoxRecValues)
                {
                    lbRec.Items.Add(item.ToString());
                }
            }

        }//end of Button_Down Method.

        //Action Method for the Reset Button that resets the game.
        private void Button_reset(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void Button_resetAchievement(object sender, RoutedEventArgs e)
        {
            ListHandler l = new ListHandler();
            l.SetAchievement(0,0);
            PopulateAchievement();
            MessageBox.Show("Achievements Reset!");
        }

        //Action method for the submit button when the user decides to submit their list arrangement.
        private void Button_submit(object sender, RoutedEventArgs e)
        {//start of Button_submit

            //List Variables to store the randomized list and the user entered list
            List<string> userList = new List<string>();
            List<string> userList1 = new List<string>();
            int point = ListHandler.GetAchievement(0);
            

            //if statement that checks whether the arrangement area listbox has all the 10 call numbers.
            if (lbRec.Items.Count == 10)
            {
                foreach(string item in lbRec.Items)
                {
                    userList.Add(item);
                    userList1.Add(item);

                }

                //sorting algorithm that sorts the randomized list by ascending order.
               SortingAlgorithm.SortIt(userList);
               ListHandler l = new ListHandler();
                
                //if statement to check if the entered list by user matches the correct sorted one.
                if(userList.SequenceEqual(userList1))
                {
                    point++;
                    l.SetAchievement(point, 0);
                    PopulateAchievement();
                    ResetGame();
                    MessageBox.Show("Call Numbers Were Sorted Correctly!!");
                }
                else
                {
                    l.SetAchievement(0, 0);
                    PopulateAchievement();
                    MessageBox.Show("Wrong Arrangement, All Achievements will be lost!!");
                   
                }
                

    
            }
            else
            {
                MessageBox.Show("Please drag all 10 call numbers!");
            }

        }//end of Button_submit

        //Reads from the textfile and populates the acheivements the user has made.
        public void PopulateAchievement()
        {//start of PopulateAchievement method

            int point = ListHandler.GetAchievement(0);

            PB1.Value = point;
            PB2.Value = point;
            PB3.Value = point;
            PB4.Value = point;
            PB5.Value = point;

        }//end of PopulateAchievement method

        //method that populates the list box with 10 randomized call numbers.
        public void PopulateListBox()
        {//start of PopulateListBox method

            List<string> shuffled = ListHandler.deweyList();

            for (int i = 0; i < 10; i++)
            {
                lbSend.Items.Add(shuffled[i]).ToString();
            }

        }//end of PopulateListBox method

        //method that resets the game when called.
        public void ResetGame()
        {//start of ResetGame method

            List<string> shuffled = ListHandler.deweyList();

            lbSend.Items.Clear();
            lbRec.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                lbSend.Items.Add(shuffled[i]).ToString();
            }

        }//end of ResetGame method.

    }//End of class ReplaceBooks.
}
