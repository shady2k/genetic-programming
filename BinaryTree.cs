using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NExpression = NCalc.Expression;

namespace gp
{
    class BinaryTree
    {
        static readonly List<Operator> operators = new List<Operator> { 
            new Operator("+"), 
            new Operator("-"), 
            new Operator("*"), 
            new Operator("/"),
            new Operator("Abs()", true),
            new Operator("Sin()", true),
            new Operator("Cos()", true),
            new Operator("Exp()", true),
            new Operator("Pow()", true, "power"),
        };
        static readonly string[] values = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static readonly string[] arguments = { "x" };
        public string[] argumentsList { get; private set; }
        private int lastNodeID = 0;
        public Node Root { get; set; }
        public int NodesCount { get; private set; }

        public BinaryTree(string[] unknownVariables)
        {
            if(unknownVariables.Length > 0)
            {
                argumentsList = unknownVariables;
            } else
            {
                argumentsList = arguments;
            }
        }
        public int GenerateNewNodeID()
        {
            lastNodeID++;
            return lastNodeID;
        }
        public void ChangeLastNodeID(int val)
        {
            this.lastNodeID = val;
        }
        public int GetLastNodeID()
        {
            return lastNodeID;
        }
        public string ParseData()
        {
            GetNodesCount();
            return TraverseInOrder(this.Root, "");
        }
        public static int GetRandomNumber(int min, int max)
        {
            return StaticRandom.Next(min, max);
        }
        public static string GetRandomNumberS(int min, int max)
        {
            return GetRandomNumber(min, max).ToString();
        }
        public bool GetChance()
        {
            int t = GetRandomNumber(0, 2);
            if (t.Equals(1))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public Node GetRandomNode()
        {
            int td = GetTreeDepth();
            int depth = StaticRandom.Next(td);
            Node cn = this.Root;

            for (var i = 0; i < depth; i++)
            {
                if (GetChance())
                {
                    if (cn.LeftNode != null)
                    {
                        cn = cn.LeftNode;
                    }
                    else
                    {
                        return cn;
                    }
                }
                else
                {
                    if (cn.RightNode != null)
                    {
                        cn = cn.RightNode;
                    }
                    else
                    {
                        return cn;
                    }
                }
            }
            return cn;
        }
        public void GenerateRandomTree(Chromosome chromosome, int maxTreeDepth)
        {
            chromosome.Tree.Root = new Node(GenerateNewNodeID());
            Node root = chromosome.Tree.Root;

            Operator op = chromosome.Tree.GetRandomOperator();
            root.Data = op.value;
            if(op.operatorType == "power")
            {
                root.DataVisible = op.value.Replace("()", string.Format("({0})", op.power));
            } else
            {
                root.DataVisible = op.value;
            }
            root.isRoot = true;
            root.isOperator = true;
            root.Operator = op;

            GenerateRandomTree(maxTreeDepth, 0, root);
            chromosome.Tree.ParseData();
        }
        public void GenerateRandomTree(int maxTreeDepth, int currentDepth, Node parentNode)
        {
            currentDepth += 1;
            if (currentDepth >= maxTreeDepth)
            {
                return;
            }

            if (parentNode.isOperator)
            {
                parentNode.LeftNode = GenerateNode(maxTreeDepth, currentDepth, parentNode);
                if (parentNode.LeftNode.isOperator)
                {
                    GenerateRandomTree(maxTreeDepth, currentDepth, parentNode.LeftNode);
                }
            }

            if (parentNode.isOperator && !parentNode.Operator.isArgument)
            {
                parentNode.RightNode = GenerateNode(maxTreeDepth, currentDepth, parentNode);
                GenerateRandomTree(maxTreeDepth, currentDepth, parentNode.RightNode);
            }
        }
        public Node GenerateNode(int maxTreeDepth, int currentDepth, Node parentNode)
        {
            Node newNode = new Node(GenerateNewNodeID());
            newNode.ParentNode = parentNode;
            if (currentDepth + 1 >= maxTreeDepth)
            {
                newNode.Data = GetRandomValue();
            }
            else
            {
                if (GetChance())
                {
                    Operator op = GetRandomOperator();
                    newNode.Data = op.value;
                    if (op.operatorType == "power")
                    {
                        newNode.DataVisible = op.value.Replace("()", string.Format("({0})", op.power));
                    }
                    else
                    {
                        newNode.DataVisible = op.value;
                    }
                    newNode.isOperator = true;
                    newNode.Operator = op;
                }
                else
                {
                    newNode.Data = GetRandomValue();
                }
            }
            return newNode;
        }
        public string GetRandomValue(int length)
        {
            string res = string.Empty;

            if (GetChance())
            {
                int rvl = GetRandomNumber(1, length);
                for (int i = 0; i <= rvl; i++)
                {
                    int oc = values.Length;
                    int rn = GetRandomNumber(0, oc);
                    res += values[rn].ToString();
                }
                return Int32.Parse(res).ToString();
            }
            else
            {
                int oc = argumentsList.Length;
                int rn = GetRandomNumber(0, oc);
                return argumentsList[rn];
            }
        }
        public string GetRandomValue()
        {
            return GetRandomValue(3);
        }
        public Operator GetRandomOperator()
        {
            int oc = operators.Count;
            int rn = GetRandomNumber(0, oc);
            Operator op = operators[rn];
            if(op.operatorType == "power")
            {
                op.power = StaticRandom.Next(2, 11);
            }
            return op;
        }
        public Node FindNode(int id)
        {
            return FindNode(id, this.Root);
        }
        private Node FindNode(int id, Node parent)
        {
            if (parent != null)
            {
                if (id == parent.id)
                {
                    return parent;
                }
                else
                {
                    Node ln = FindNode(id, parent.LeftNode);
                    Node rn = FindNode(id, parent.RightNode);
                    if (ln != null) return ln;
                    if (rn != null) return rn;
                }
            }

            return null;
        }
        public void CopyNode(Chromosome source, Chromosome target)
        {
            target.Tree.Root = new Node(source.Tree.Root.id);

            Node sourceTree = source.Tree.Root;
            Node targetTree = target.Tree.Root;

            CopyNode(sourceTree, targetTree);
            target.Tree.ParseData();
        }
        public void CopyNode(Node sourceTree, Node targetTree)
        {
            if (targetTree.ParentNode == null)
            {
                targetTree.isRoot = true;
            }
            else
            {
                targetTree.isRoot = false;
            }
            targetTree.id = sourceTree.id;
            targetTree.Data = sourceTree.Data;
            targetTree.DataVisible = sourceTree.DataVisible;
            targetTree.isOperator = sourceTree.isOperator;
            targetTree.Operator = sourceTree.Operator;
            if (sourceTree.LeftNode != null)
            {
                if (targetTree.LeftNode == null)
                {
                    targetTree.LeftNode = new Node(sourceTree.LeftNode.id);
                    targetTree.LeftNode.ParentNode = targetTree;
                }
                CopyNode(sourceTree.LeftNode, targetTree.LeftNode);
            }
            if (sourceTree.RightNode != null)
            {
                if (targetTree.RightNode == null)
                {
                    targetTree.RightNode = new Node(sourceTree.RightNode.id);
                    targetTree.RightNode.ParentNode = targetTree;
                }
                CopyNode(sourceTree.RightNode, targetTree.RightNode);
            }
        }
        /*
        public void CopyNode(Chromosome source, Chromosome target)
        {
            target.Tree.Root = new Node(GenerateNewNodeID());

            Node sourceTree = source.Tree.Root;
            Node targetTree = target.Tree.Root;

            CopyNode(sourceTree, targetTree);
            target.Tree.ParseData();
        }
        public void CopyNode(Node sourceTree, Node targetTree)
        {
            if (targetTree.ParentNode == null)
            {
                targetTree.isRoot = true;
            }
            else
            {
                targetTree.isRoot = false;
            }
            targetTree.Data = sourceTree.Data;
            targetTree.isOperator = sourceTree.isOperator;
            if (sourceTree.LeftNode != null)
            {
                if (targetTree.LeftNode == null)
                {
                    targetTree.LeftNode = new Node(GenerateNewNodeID());
                    targetTree.LeftNode.ParentNode = targetTree;
                }
                CopyNode(sourceTree.LeftNode, targetTree.LeftNode);
            }
            if (sourceTree.RightNode != null)
            {
                if (targetTree.RightNode == null)
                {
                    targetTree.RightNode = new Node(GenerateNewNodeID());
                    targetTree.RightNode.ParentNode = targetTree;
                }
                CopyNode(sourceTree.RightNode, targetTree.RightNode);
            }
        }
         */
        public void ReplaceNode(Node source, Node target)
        {
            if(target.ParentNode == null)
            {
                target.isRoot = true;
            } else
            {
                target.isRoot = false;
            }
            target.Data = source.Data;
            target.DataVisible = source.DataVisible;
            target.isOperator = source.isOperator;
            target.Operator = source.Operator;
            if (source.LeftNode != null)
            {
                if (target.LeftNode == null)
                {
                    target.LeftNode = new Node(GenerateNewNodeID());
                    target.LeftNode.ParentNode = target;
                }
                ReplaceNode(source.LeftNode, target.LeftNode);
            } else
            {
                target.LeftNode = null;
            }
            if (source.RightNode != null)
            {
                if (target.RightNode == null)
                {
                    target.RightNode = new Node(GenerateNewNodeID());
                    target.RightNode.ParentNode = target;
                }
                ReplaceNode(source.RightNode, target.RightNode);
            } else
            {
                target.RightNode = null;
            }
        }
        public List<Adjacency> GetEdges()
        {
            int depthLevel = 0;
            List<Adjacency> res = new List<Adjacency>();

            GetEdges(this.Root, res, depthLevel);

            return res;
        }
        private void GetEdges(Node node, List<Adjacency> res, int depthLevel)
        {
            depthLevel += 1;
            if (node == null) return;
            if (node.RightNode != null)
            {
                Adjacency a = new Adjacency();
                a.sourceId = node.id;
                a.targetId = node.RightNode.id;
                a.sourceData = node.DataVisible;
                a.targetData = node.RightNode.Data;
                a.level = node.id;
                res.Add(a);
            }
            if (node.LeftNode != null)
            {
                Adjacency a = new Adjacency();
                a.sourceId = node.id;
                a.targetId = node.LeftNode.id;
                a.sourceData = node.DataVisible;
                a.targetData = node.LeftNode.Data;
                a.level = node.id;
                res.Add(a);
            }


            GetEdges(node.RightNode, res, depthLevel);
            GetEdges(node.LeftNode, res, depthLevel);
        }
        /*public void Remove(int value)
        {
            Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }*/
        public void GetNodesCount()
        {
            Dictionary<int, int> nodesList = new Dictionary<int, int>();
            GetNodesCount(this.Root, nodesList);
            this.NodesCount = nodesList.Count();
        }
        public void GetNodesCount(Node parent, Dictionary<int, int> nodesList)
        {
            if(parent != null)
            {
                nodesList.Add(parent.id, 0);
                GetNodesCount(parent.LeftNode, nodesList);
                GetNodesCount(parent.RightNode, nodesList);
            }
        }
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Debug.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public string TraverseInOrder(Node parent, string parsed)
        {
            if (parent != null)
            {
                /*var ln = string.Empty;
                var rn = string.Empty;
                if (parent.LeftNode != null)
                {
                    ln = parent.LeftNode.Data;
                }
                else
                {
                    ln = "null";
                }
                if (parent.RightNode != null)
                {
                    rn = parent.RightNode.Data;
                }
                else
                {
                    rn = "null";
                }
                Debug.WriteLine(parent.Data + ": " + ln + " AND " + rn);

                if (parent.LeftNode == null && parent.RightNode == null)
                {
                    var t = 1;
                }*/

                var rln = TraverseInOrder(parent.LeftNode, parsed);
                var rrn = TraverseInOrder(parent.RightNode, parsed);

                /*Debug.WriteLine("cn: " + parent.Data);
                Debug.WriteLine("ln: " + rln);
                Debug.WriteLine("rn: " + rrn);*/

                if (parent.isOperator)
                {
                    if (parent.isRoot)
                    {
                        if (parent.Operator.isArgument)
                        {
                            string val = string.Empty;
                            if(parent.Operator.operatorType == "power")
                            {
                                val = parent.Data.Replace("()", string.Format("({0},{1})", rln, parent.Operator.power));
                            } else
                            {
                                val = parent.Data.Replace("()", "(" + rln + ")");
                            }
                            
                            parsed = val;
                        } else
                        {
                            parsed = rln + parent.Data + rrn;
                        }
                    } else
                    {
                        if(parent.Operator.isArgument)
                        {
                            string val = string.Empty;
                            if (parent.Operator.operatorType == "power")
                            {
                                val = parent.Data.Replace("()", string.Format("({0},{1})", rln, parent.Operator.power));
                            }
                            else
                            {
                                val = parent.Data.Replace("()", "(" + rln + ")");
                            }
                            parsed = val;
                        } else
                        {
                            parsed = "(" + rln + parent.Data + rrn + ")";
                        }
                    }
                }
                else
                {
                    parsed = parent.Data;
                }
            }
            return parsed;
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Debug.Write(parent.Data + " ");
            }
        }
    }
}
