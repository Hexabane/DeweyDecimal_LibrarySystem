using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.Core
{
    class TreeNode<CallNumber>
    {
        public CallNumber Data { get; set; }
        public TreeNode<CallNumber> Parent { get; set; }
        public List<TreeNode<CallNumber>> Children { get; set; }



    }
}
