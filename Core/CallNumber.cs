using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.Core
{
    class CallNumber
    {
        public string Number { get; set; }
        public string Description { get; set; }

        public CallNumber()
        {
        }

        public CallNumber(string number, string description)
        {
            Number = number;
            Description = description;
        }

        public string toString()
        {
            return $"{Number}-{ Description}";
        }
    }
}
