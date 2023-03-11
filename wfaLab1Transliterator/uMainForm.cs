using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsLex;
using nsSynt;
using nsHashTables;


namespace nsLexMainForm
{
    public partial class Form1 : Form
    {
        public CHashTableList htl = new CHashTableList(2);
        public Form1()
        {
            InitializeComponent();
            tbFSource.AppendText("001100 a 100 bcba");
            int n = tbFSource.Lines.Length;
        }
        public void TablesToMemo(object sender, System.EventArgs e)
        {
            List<string> listTable = new List<string>();

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            htl.TableToStringList(0, listTable);
            for (int i = 0; i < listTable.Count; i++)
                listBox1.Items.Add(listTable[i]);
            listTable.Clear();

            htl.TableToStringList(1, listTable);
            for (int i = 0; i < listTable.Count; i++)
                listBox2.Items.Add(listTable[i]);
            listTable.Clear();
        }
        private void btnFStart_Click(object sender, EventArgs e)
        {
            tbFMessage.Clear();
            uSyntAnalyzer Synt = new uSyntAnalyzer(treeView1);
            Synt.Lex.strPSource = tbFSource.Lines;
            Synt.Lex.strPMessage = tbFMessage.Lines;
            Synt.Lex.enumPState = TState.Start;
            try
            {
                Synt.Lex.NextToken();
                Synt.S();
                throw new Exception("Текст верный");
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Synt.Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Synt.Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CLex Lex = new CLex();
            Lex.strPSource = tbFSource.Lines;
            Lex.strPMessage = tbFMessage.Lines;
            Lex.intPSourceColSelection = 0;
            Lex.intPSourceRowSelection = 0;
            int x = tbFSource.TextLength;
            int y = tbFSource.Lines.Length;
            tbFMessage.Text = "";
            try
            {
                while (Lex.enumPState != TState.Finish)
                {
                    Lex.NextToken();
                    string s1 = "", s = "";
                    switch (Lex.enumPToken)
                    {
                        case TToken.lxmIdentifier:
                            {
                                s1 = "id " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 0, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                        case TToken.lxmNumber:
                            {
                                s1 = "num " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 1, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                    }
                    String m = "(" + s + "" + s1 + ")";
                    tbFMessage.Text += m;
                }
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
        }
    }
}


