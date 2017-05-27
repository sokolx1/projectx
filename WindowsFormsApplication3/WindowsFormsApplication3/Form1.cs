using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string x;

        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButton1.Checked )
                {
                treeView1.Nodes.Add(textBox1.Text);
            }
            if (radioButton2.Checked)
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("error");
                }
                else {
                    treeView1.SelectedNode.Nodes.Add(textBox1.Text);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                treeView1.ExpandAll();
            }
            else
            {
                treeView1.CollapseAll();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Level)
            {
                case 0:
                    int x = treeView1.SelectedNode.Nodes.Count;
                    string text = treeView1.SelectedNode.Text;
                    string text2 = x.ToString();
                    label1.Text = text + text2;
                    string y = " - ";
                    foreach (TreeNode item in treeView1.SelectedNode.Nodes)
                    {
                        y = y + item.Text + " - ";
                    }
                    label2.Text = y;
                    break;
                case 1:
                    string text3 = treeView1.SelectedNode.Text;
                    string text4 = treeView1.SelectedNode.Parent.Text;
                    label1.Text = text3;
                    label2.Text = text4;
                    break;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Text = textBox1.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = treeView1.SelectedNode.Text;
            treeView1.SelectedNode.Remove();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("error");
            }
            else {
                treeView1.SelectedNode.Nodes.Add(x);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendar1.SelectionEnd.Date;
            int Count = 0;
            date = date.AddDays(-30.0);
            DateTime date2 = date.AddDays(30.0);
            int result = DateTime.Compare(date, date2);
            while (true)
            {
                if (result>0)
                {
                    break;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    Count++;
                }
                date = date.AddDays(1.0);
                result = DateTime.Compare(date, date2);
               

            }
            label4.Text = Count.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            int Count = 0;
            while (true)
            {
                if (date1.DayOfWeek == DayOfWeek.Tuesday)
                {
                    break;
                }
                date1 = date1.AddDays(1.0);
                Count++;
            }
            monthCalendar1.SetDate(date1);
            string text = "До вторника " + Count.ToString();
            label3.Text = text;
        }
    }
}
