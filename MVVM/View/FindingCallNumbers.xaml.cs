using DeweySystem.Core;
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

namespace DeweySystem.MVVM.View
{
    /// <summary>
    /// Interaction logic for findingCallNumbers.xaml
    /// </summary>
    public partial class FindingCallNumbers : UserControl
    {

        public int randValue, rv, rv1; //variable initialized to hold the random value.
        public Random random = new Random(); //a new random object initialized.
        public List<int> randomList = new List<int>();
        public int counter= 0;

        public FindingCallNumbers()
        {
            InitializeComponent();
            PopulateGame();
            PopulateAchievement();
        }

        // A method that creates random variables and is stored for a single set of level session
        public void Randomizer()
        {//start of Randomizer() method
            randomList.Clear();
            rv = random.Next(3);
            rv1 = random.Next(3);

            for (int i = 0; i < ListHandler.CallList().Count; i++)
            {
                randValue = random.Next(10);

                if (randomList.Contains(randValue))
                {
                    i--;
                }
                else
                {
                    randomList.Add(randValue);
                }
            }
        }//end of Randomizer() method

        //A method that popualates the list box and the text field for the question for the user.
        public void PopulateGame()
        {
            Randomizer();
            ListHandler.PopulateTree();
            questiontxt.Text = "Q - " + ListHandler.treeList[randomList[0]].Root.Children[rv].Children[rv1].Data.Description.ToString();
            Populatelb(1);

        }

        //Submit button that gets selection of the user answer and matches is it with the question already set in the begining with PopulateGame() mewthod.
        private void Button_submit(object sender, RoutedEventArgs e)
        {
            
            ListHandler l = new ListHandler(); //Listhandler Object initialized.
            int point = ListHandler.GetAchievement(2); //gets the current point of the user.
            if (lbCallNumbers.SelectedItem != null) // if the user slects and item.
            {
                if (GetParent(0).Equals(GetParent(1)))
                {
                    MessageBox.Show("Correct Answer!");
                    lbCallNumbers.Items.Clear();
                    Populatelb(2); // if the answer is correct the list box is populated again with the other set of call numbers (level 3)
                    counter++; 

                    if (counter > 1) //checks if a both levels are answered correctly by the user, if correct then points are awarded to the user and the game is reset.
                    {
                        point++; //adds and awards points to the user.
                        l.SetAchievement(point, 2); //sets and gives points on the achievement bar
                        PopulateAchievement();
                        ResetGame(); //resets the game
                        MessageBox.Show("You have answered all levels correctly!");
                    }
                }
                else //if the answer is selected incorrectly then the game resets.
                {
                    l.SetAchievement(0, 2);
                    PopulateAchievement();
                    ResetGame();
                    MessageBox.Show("Wrong Answer!");

                }
               
            }
            else // if the user doesnt select an item from the list box
            {
                MessageBox.Show("please select an option!");
            }

        }

        //gets the parent of element selected by the user and the question provided to the user.
        public string GetParent(int check)
        {//start of GetParent() method

            string checkParent = " ";


            if (check == 0)
            {
                checkParent = ListHandler.treeList[randomList[0]].Root.Children[rv].Children[rv1].Data.toString();
            }
            if(check == 1)
            {
                checkParent = lbCallNumbers.SelectedItem.ToString();
            }

            for (int i = 0; i < 4; i++)
            {
                 
                if (checkParent.Equals(ListHandler.treeList[randomList[i]].Root.Children[rv].Data.toString()))
                {
                    checkParent = ListHandler.treeList[randomList[i]].Root.Children[rv].Parent.Data.toString();
                }
                if (checkParent.Equals(ListHandler.treeList[randomList[i]].Root.Children[rv].Children[rv1].Data.toString()))
                {
                    checkParent = ListHandler.treeList[randomList[i]].Root.Children[rv].Parent.Data.toString();
                }

            }

            return checkParent; //returns the parent element.

        }//end of GetParent() method


        //Populates the listbox depending on the level, if level 1 then populates with the level 1 elements and if level 2 then populate with level 2 elements.
        //the int check - is for the level number.
        public void Populatelb(int check)
        {//start of Populatelb()

            List<string> sortedList = new List<string>();

            
            for (int i = 0; i < 4; i++)
            {
                //checks if the game is level 1
                if (check == 1)
                {
                    sortedList.Add(ListHandler.treeList[randomList[i]].Root.Data.toString());
                }
                //checks if the game is level 2
                if (check == 2)
                {
                    sortedList.Add(ListHandler.treeList[randomList[i]].Root.Children[rv].Data.toString());
                }
            }

            sortedList.Sort();

            foreach (string item in sortedList)
            {
                lbCallNumbers.Items.Add(item);
            }
            
        }//end of Populatelb()

        public void ResetGame()
        {
            lbCallNumbers.Items.Clear();
            counter = 0;
            PopulateGame();
        }


        //button method that resets theg game for the user
        private void Button_reset(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        //button method that resets all the achievements of th user.
        private void Button_resetAchievement(object sender, RoutedEventArgs e)
        {
            ListHandler l = new ListHandler();
            l.SetAchievement(0, 2);
            PopulateAchievement();
            MessageBox.Show("Achievements Reset!");
        }

        //populates all the saved achivements scored of the user.
        public void PopulateAchievement()
        {//start of PopulateAchievement method

            int point = ListHandler.GetAchievement(2);

            PB1.Value = point;
            PB2.Value = point;
            PB3.Value = point;
            PB4.Value = point;
            PB5.Value = point;

        }//end of PopulateAchievement method
    }
}
