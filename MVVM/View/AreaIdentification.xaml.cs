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
    /// Interaction logic for IdentifyArea.xaml
    /// </summary>
    public partial class AreaIdentification : UserControl
    {//start of class

        public Random random = new Random(); //a new random object initialized.
        int randValue; //variable initialized to hold the random value.

        public AreaIdentification()
        {
            InitializeComponent();
            PopulateAchievement(); //populates all the user achievements.
            PopulateLeftCol(); //populates the left coloumm.
            PopulateRightCol(); //populates the right coloum.
          
        }

        //This method will populate the left col with 4 call numbers or decriptions randomly as questions to match with.
        public void PopulateLeftCol()
        {//start of PopulateLeftCol()

            //initializing the dictionaries
            ListHandler.dicComparison = ListHandler.Dictionary;
            ListHandler.dicCallNumber = ListHandler.Dictionary;
            
            //giving the the variable a random value of 0 or 1.
            randValue = random.Next(2);
         
            //A list is populated with all the keys or values randomly from the dictionary depending on the randomValue. - if 0 then keys else values.
            ListHandler.randomList = ListHandler.dicCallNumber.Select(x => (randValue == 0) ? x.Key : x.Value).OrderBy(z => random.Next()).ToList();

            //for loop to populate the left col with only 4 items stored in the list.
            for (int i = 0; i < 4; i++)
            {

                lbLeftCol.Items.Add(ListHandler.randomList[i].ToString());
            }
            
        }//end of  PopulateLeftCol()

        public void PopulateRightCol()
        {//start of PopulateRightCol()
    
            //list created to store values or keys from the dictionary as possible answers to the question in the left Col.
            List<string> quesList = new List<string>();

            //foreach loop that goes through the left col to get the already populated question keys/values
            foreach (string item in lbLeftCol.Items)
            {

                //RandomList initialized again with keys or values from the dictionary depending on the randomValue and only the ones that match the lefr Col. - if 0 then keys else values.
                ListHandler.randomList = ListHandler.dicCallNumber.Where(x => (randValue == 0) ? x.Key.Equals(item) : x.Value.Equals(item)).Select(x => (randValue == 0) ? x.Value : x.Key).ToList();

                foreach (string item1 in ListHandler.randomList)
                {
                    
                    quesList.Add(item1); //adds the 4 confiremd answers in the list
                    ListHandler.dicCallNumber.Remove(item1); //removes the 4 confirmed answers from the dictionary so it does not repopulate in the right Col.
                    
                }

                ListHandler.dicCallNumber.Remove(item); //removes the 4 confirmed answers from the dictionary so it does not repopulate in the right Col.

            }

            //this foreach loop adds the remaining extra keys/values to populate the right Col but are incorrect answers!
            foreach (string item in randValue ==0 ? ListHandler.dicCallNumber.Values.OrderBy(x => random.Next()).Take(3) : ListHandler.dicCallNumber.Keys.OrderBy(x => random.Next()).Take(3))
            {
                quesList.Add(item);
            }

            //finall this foreach loop populates the right Col with 4 Correct answers and 3 wrong answers all arranged Randomly.
            foreach (string item in quesList.OrderBy(z => random.Next()).ToList())
            {

                lbRightCol.Items.Add(item);
            }

        }//end of PopulateRightCol()




        private void Button_submit(object sender, RoutedEventArgs e)
        {//start of Button_submit()

            Dictionary<string, string> userDic = new Dictionary<string, string>(); //dictionary created to store all the matches from the user.
            Dictionary<string, string> answerDic = new Dictionary<string, string>(); //dictionary created to store the correct keys and values to later compare with the user dic.
            ListHandler l = new ListHandler(); //Listhandler Object initialized.
            int point = ListHandler.GetAchievement(1); //gets the current point of the user.
            List<int> indexList = new List<int>(); //stores the index places of where the user has answered.
            List<string> inputList = new List<string>(); //gets all the inputs of the user from the text boxes.
            List<string> rightColList = new List<string>(); //stores all the values/keys from the rightCol.
            List<string> leftColList = new List<string>(); //stores all the values/keys from the leftCol.
            List<string> key = new List<string>(); //stores the keys depending on what the user matched.
            List<string> elementList = new List<string>(); //stores all the elements/values depending on what the user has matched.
            List<string> valueList = new List<string>(); //stores all the elements/values depending on what the user has matched.


            //populates the inputList with all the user inputs.
            inputList.Add(txb1.Text.ToString());
            inputList.Add(txb2.Text.ToString());
            inputList.Add(txb3.Text.ToString());
            inputList.Add(txb4.Text.ToString());
            inputList.Add(txb5.Text.ToString());
            inputList.Add(txb6.Text.ToString());
            inputList.Add(txb7.Text.ToString());

            try
            {//start of try statement

                //foreach loop adds all the items from the RightCol to the list.
                foreach (string item in lbRightCol.Items)
                {
                    rightColList.Add(item);

                }

                //for loop that gets the indexes based on where the user has mathced their answers with the second coloumn.
                //also adds the corresponding answers the user has matched with.
                for (int i = 0; i < 4; i++)
                {
                    List<int> indexes = inputList.Select((element, index) => element == (i+1).ToString() ? index : -1).Where(i => i >= 0).ToList();

                    foreach (int item1 in indexes)
                    {
                        indexList.Add(item1);
                    }

                    elementList.Add(rightColList.ElementAt(indexList[i]));
                }

             
                //for loop that loops through the answer list that the user has matched and gets the keys accordingly.
                //also populates the userdictionary - a seperate dictionary for user values.
                for (int i = 0; i < elementList.Count; i++)
                {

                    foreach (string item1 in ListHandler.dicComparison.Where(x => (randValue == 0) ? x.Value.Equals(elementList[i]) : x.Key.Equals(elementList[i])).Select(x => (randValue == 0) ? x.Key : x.Value).ToList())
                    {
                        key.Add(item1);
                    }


                    userDic.Add(key[i], elementList[i]);
                }

                //foreach loop that populates list with left col list and gets all the correct answers populated in the valuelist.
                foreach (string item in lbLeftCol.Items)
                {
                    leftColList.Add(item);

                    foreach (string item1 in ListHandler.dicComparison.Where(x => (randValue == 0) ? x.Key.Equals(item) : x.Value.Equals(item)).Select(x => (randValue == 0) ? x.Value : x.Key).ToList())
                    {
                        valueList.Add(item1);
                    }
                }

                //populates the correct keys and values in the answer dictionary.
                for (int i = 0; i < valueList.Count; i++)
                {
                    answerDic.Add(leftColList[i], valueList[i]);
                }

                
                //ifelse statement that compares the 2 dictionaries (user and answer) and check if the user was correct with their matchings.
                if (answerDic.Values.SequenceEqual(userDic.Values))
                {
                    point++;
                    l.SetAchievement(point, 1);
                    PopulateAchievement();
                    ResetGame();
                    MessageBox.Show("Correctly Matched!");
                }
                else
                {
                    l.SetAchievement(0, 1);
                    PopulateAchievement();
                    MessageBox.Show("Incorrectly matched, try again!");
                }

            }//end of try statement.
            catch(Exception E)
            {//start of catch statement

                MessageBox.Show("Please Match and fill atleast 4 textboxes!");

            }//end of catch statement.

        }//end of Button_submit()

        //button method that resets theg game for the user
        private void Button_reset(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        //button method that resets all the achievements of th user.
        private void Button_resetAchievement(object sender, RoutedEventArgs e)
        {
            ListHandler l = new ListHandler();
            l.SetAchievement(0, 1);
            PopulateAchievement();
            MessageBox.Show("Achievements Reset!");
        }

        //populates all the saved achivements scored of the user.
        public void PopulateAchievement()
        {//start of PopulateAchievement method

            int point = ListHandler.GetAchievement(1);

            PB1.Value = point;
            PB2.Value = point;
            PB3.Value = point;
            PB4.Value = point;
            PB5.Value = point;

        }//end of PopulateAchievement method

        //resets the whole page and the game.
        public void ResetGame()
        {//start of ResetGame method

            txb1.Clear();
            txb2.Clear();
            txb3.Clear();
            txb4.Clear();
            txb5.Clear();
            txb6.Clear();
            txb7.Clear();
            lbLeftCol.Items.Clear();
            lbRightCol.Items.Clear();

            PopulateLeftCol();
            PopulateRightCol();

        }//end of ResetGame method.

    }//end of class.
}