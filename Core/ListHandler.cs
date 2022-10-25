//ST10116273
//Kunal Goyal
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.Core
{
    class ListHandler
    {//start of class ListHandler

        public static Dictionary<string, string> dicCallNumber = new Dictionary<string, string>();
        public static Dictionary<string, string> dicComparison = new Dictionary<string, string>();
        public static List<string> randomList = new List<string>();

        public static List<string> deweyList()
        {//start of List Type method deweyList()

            //StreamReader Object for the textfile file path
            StreamReader file = new StreamReader("DeweyDecimalList.txt");

            List<string> output = new List<string>(10); //new list type string created to store data from the text file

            string line;

            //a while loop where there is a line in the text file and adds into the list until there are no lines.
            while ((line = file.ReadLine()) != null)
            {
                output.Add(line);
            }

            file.Close();

            //randomizer variable to randomize the components in the list
            Random rand = new Random();
            return output.OrderBy(x => rand.Next()).ToList();

        }//end of List Type methoid deweyList()

        public void SetAchievement(int points, int check)
        {//start of SetAchievement() method

            string filepath = "";

            if (check == 0)
            {
                filepath = "Acheivement.txt"; //string created to identify file path
            }
            if (check == 1)
            {
                filepath = "Acheivement1.txt"; //string created to identify file path
            }

            string dataInput = points.ToString(); //string craeted to store the data input entered by the user.

            //StreamWriter object initialized to write to the file path.
            StreamWriter write = new StreamWriter(filepath);
            write.Write(dataInput); 

            write.Close();

        }//end of SetAcheievement() method

        public static int GetAchievement(int check)
        {//start of GetAcheievement() method
            StreamReader file = new StreamReader("Acheivement.txt");

            if (check == 0)
            {
                //StreamReader Object initialized to red from the filepath
                file = new StreamReader("Acheivement.txt");
            }
            if (check == 1)
            {
                //StreamReader Object initialized to red from the filepath
                file = new StreamReader("Acheivement1.txt");
            }
            //strings created to store the data read from the file.
            string point = "";
            string line;

            while((line = file.ReadLine()) != null)
            {
                point = line;
            }

            file.Close();

            //returns the data stored from the textfile.
            return Convert.ToInt32(point);

        }//end of GetAchievement() method

        public static Dictionary<string, string> Dictionary
        {//start of Dictionary()

            get => dicCallNumber = new Dictionary<string, string>()
            {
                {"000", "Computer science, information & general works"},
                {"100", "Philosophy & psychology"},
                {"200", "Religion"},
                {"300", "Social sciences"},
                {"400", "Language"},
                {"500", "Science"},
                {"600", "Technology"},
                {"700", "Arts & recreation"},
                {"800", "Literature"},
                {"900", "History & geography"},
            };

        }//end of Dictionary()


    }//End of Class ListHandler.
}
