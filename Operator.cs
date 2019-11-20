using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp
{
    public class Operator
    {
        public bool isArgument;
        public string operatorType;
        public string value;
        public int power;

        public Operator(string value, bool isArgument, string operatorType)
        {
            this.value = value;
            this.isArgument = isArgument;
            this.operatorType = operatorType;
            this.power = 0;
        }
        public Operator(string value, bool isArgument)
        {
            this.value = value;
            this.isArgument = isArgument;
            this.operatorType = "default";
            this.power = 0;
        }
        public Operator(string value)
        {
            this.value = value;
            this.isArgument = false;
            this.operatorType = "default";
            this.power = 0;
        }
    }
}
