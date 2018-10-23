using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSwapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Program.slova = textBox1.Text;
            Program.broj_slova = (int)numericUpDown1.Value;
            Program.poznato = textBox2.Text;
            Program.validate = checkBox1.Checked;
            if (Program.validate)
            {
                Program.word_list = Program.PrepareWords(Program.dict, Program.broj_slova);
            }
            Program.lista = Program.Permutate(Program.slova, Program.broj_slova);

            foreach (string s in Program.lista)
            {
                if (Program.poznato.Length != 0)
                {
                    if (s.Substring(0, Program.poznato.Length) == Program.poznato)
                    {
                        if (Program.validate)
                        {
                            if (Program.IsInDictionary(s,Program.word_list))
                            {
                                listBox1.Items.Add(s);
                            }
                        }
                        else
                        {
                            listBox1.Items.Add(s);
                        }
                    }
                }
                else
                {
                    if (Program.validate)
                    {
                        if (Program.IsInDictionary(s, Program.word_list))
                        {
                            listBox1.Items.Add(s);
                        }
                    }
                    else
                    {
                        listBox1.Items.Add(s);
                    }
                }
            }
        }
    }
}
