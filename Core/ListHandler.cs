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

        public void SetAchievement(int points)
        {//start of SetAchievement() method

            string filepath = "Acheivement.txt"; //string created to iddentify file path

            string dataInput = points.ToString(); //string craeted to store the data input entered by the user.

            //StreamWriter object initialized to write to the file path.
            StreamWriter write = new StreamWriter(filepath);
            write.Write(dataInput); 

            write.Close();

        }//end of SetAcheievement() method

        public static int GetAchievement()
        {//start of GetAcheievement() method

            //StreamReader Object initialized to red from the filepath
            StreamReader file = new StreamReader("Acheivement.txt");

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

    }//End of Class ListHandler.
}
