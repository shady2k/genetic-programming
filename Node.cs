using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp
{
    class Node
    {
        public int id { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node ParentNode { get; set; }
        public string Data { get; set; }
        public string DataVisible { get; set; }
        public bool isRoot { get; set; } = false;
        public bool isOperator { get; set; } = false;
        public Operator Operator { get; set; }
        public Node(int id)
        {
            this.id = id;
        }
    }
}
