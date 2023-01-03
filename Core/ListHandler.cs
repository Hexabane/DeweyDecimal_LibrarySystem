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
        public static List<Tree<CallNumber>> treeList = new List<Tree<CallNumber>>();

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
            try
            {
                string filepath = "";

                if (check == 0)
                {
                    filepath = "Acheivement.txt"; //string created to identify file path
                }
                if (check == 1)
                {
                    filepath = "Acheivement1.txt"; //string created to identify file path
                }
                if (check == 2)
                {
                    filepath = "Acheivement2.txt"; //string created to identify file path
                }

                string dataInput = points.ToString(); //string craeted to store the data input entered by the user.

                //StreamWriter object initialized to write to the file path.
                StreamWriter write = new StreamWriter(filepath);
                write.Write(dataInput);

                write.Close();
            }
            catch(Exception E)
            {

            }

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
            if (check == 2)
            {
                //StreamReader Object initialized to red from the filepath
                file = new StreamReader("Acheivement2.txt");
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

        public static List<List<CallNumber>> CallList()
        {
            StreamReader file = new StreamReader("CallEntries.txt");

            List<CallNumber> output = new List<CallNumber>();
            List<List<CallNumber>> testy = new List<List<CallNumber>>();

            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line.Equals(""))
                {
                    testy.Add(output);
                    output = new List<CallNumber>();
                }
                else
                {
                    string[] ListInfo = line.Split('-');
                    output.Add(new CallNumber { Number = ListInfo[0], Description = ListInfo[1] });
                }

            }

            file.Close();

            return testy;

        }

        //Method that Populates the tree from the CallList() method
        public static void PopulateTree()
        {//start of PopulateTree()

            //Goes through the CallList() and every section of data stored in the text file
            foreach (var item in CallList())
            {
                List<CallNumber> treeNode = new List<CallNumber>();
                treeNode = item;

                Tree<CallNumber> tree = new Tree<CallNumber>();
                tree.Root = new TreeNode<CallNumber>() { Data = new CallNumber(treeNode[0].Number, treeNode[0].Description) };

                for (int i = 0; i < treeNode.Count; i++)
                {

                    //Tree data is stored in the tree nodes
                    tree.Root.Children = new List<TreeNode<CallNumber>>
                    {
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[1].Number, treeNode[1].Description), Parent = tree.Root },
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[5].Number, treeNode[5].Description), Parent = tree.Root },
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[9].Number, treeNode[9].Description), Parent = tree.Root }
                    };

                    tree.Root.Children[0].Children = new List<TreeNode<CallNumber>>
                    {
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[2].Number, treeNode[2].Description), Parent = tree.Root.Children[0]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[3].Number, treeNode[3].Description), Parent = tree.Root.Children[0]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[4].Number, treeNode[4].Description), Parent = tree.Root.Children[0]}
                    };

                    tree.Root.Children[1].Children = new List<TreeNode<CallNumber>>
                    {
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[6].Number, treeNode[6].Description), Parent = tree.Root.Children[1]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[7].Number, treeNode[7].Description), Parent = tree.Root.Children[1]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[8].Number, treeNode[8].Description), Parent = tree.Root.Children[1]}
                    };

                    tree.Root.Children[2].Children = new List<TreeNode<CallNumber>>
                    {
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[10].Number, treeNode[10].Description), Parent = tree.Root.Children[2]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[11].Number, treeNode[11].Description), Parent = tree.Root.Children[2]},
                    new TreeNode<CallNumber>() {Data = new CallNumber(treeNode[12].Number, treeNode[12].Description), Parent = tree.Root.Children[2]}
                    };

                }

                //every tree is added into the list of type tree list
                treeList.Add(tree);
            }
        }//end of PopulateTree()

    }//End of Class ListHandler.
}
