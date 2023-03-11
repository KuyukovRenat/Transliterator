using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nsLex;

/*   S -> <2> <2> <2> B | <2> <2> <1> <2> B | <1> <2> <1> B | <1> <2> <1> <1> B 
     B -> (< 2 >)*
*/

namespace nsSynt
{
    class uSyntAnalyzer
    {
        private String[] strFSource;
        private String[] strFMessage;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public CLex Lex = new CLex();



        private readonly TreeView treeView;
        private TreeNode currenTreeNode = new TreeNode();
        private TreeNode B_rootNode = new TreeNode();

        //private List<String> previpusNumbers = new List<String>();
        private List<String> previpusIdentifier = new List<String>();// создаем коллекцию идентификаторов

        public uSyntAnalyzer(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void S()
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add("S");
            currenTreeNode = treeView.TopNode;
            var tmpNode = currenTreeNode;

            if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                Lex.NextToken();
                A();
                if (Lex.enumPToken == TToken.lxmIdentifier)
                {
                    Lex.NextToken();
                    B();
                    throw new Exception("Конец слова, текст верный");
                }
                else throw new Exception("Ожидался буквенный идентификатор");
            }
            else if (Lex.enumPToken == TToken.lxmNumber)
            {
                currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                Lex.NextToken();
                A();
                if (Lex.enumPToken == TToken.lxmNumber)
                {
                    currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                    Lex.NextToken();
                    if (Lex.enumPToken == TToken.lxmNumber)
                    {
                        currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                        Lex.NextToken();
                    }
                    B();
                    throw new Exception("Конец слова, текст верный.");
                }
                else throw new Exception("Ожидался числовой идентификатор");
            }
        }
        public void A()
        {
            currenTreeNode.Nodes.Add("A");
            currenTreeNode = currenTreeNode.LastNode;
            if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                //currenTreeNode = currenTreeNode.PrevNode;
                Lex.NextToken();
                currenTreeNode = currenTreeNode.Parent;
            }
            else throw new Exception("Ожидался буквенный идентификатор");
        }

        public void B()
        {
            currenTreeNode.Nodes.Add("B");
            currenTreeNode = currenTreeNode.LastNode;
            if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                currenTreeNode.Nodes.Add(Lex.strPLexicalUnit);
                //currenTreeNode = currenTreeNode.FirstNode;
                Lex.NextToken();
                if (Lex.enumPToken == TToken.lxmIdentifier)
                {
                    Lex.NextToken();
                    B();
                }
            }
            else throw new Exception("Ожидался буквенный идентификатор");
        }
    }
}