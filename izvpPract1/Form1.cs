using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izvpPract1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int[,] array;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int max = Convert.ToInt32(textBox6.Text) / Convert.ToInt32(tb1.Text); ;
                if (max > Convert.ToInt32(textBox5.Text) / Convert.ToInt32(tb2.Text)) max = Convert.ToInt32(textBox5.Text) / Convert.ToInt32(tb2.Text);
                if (max > Convert.ToInt32(textBox4.Text) / Convert.ToInt32(tb3.Text)) max = Convert.ToInt32(textBox4.Text) / Convert.ToInt32(tb3.Text);
                label1.Text = max.ToString();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                int h = 0;
                int w = 0;
                Boolean check = true;
                Random rnd = new Random();
                if (tbH.Text == "" )
                {
                    h = 5;
                }
                else
                {
                    h = Convert.ToInt32(tbH.Text);

                }
                if (tbW.Text =="")
                { w = 5; }
                else {
                    w = Convert.ToInt32(tbW.Text);
                    
                }
                array = new int[h, w];
                if (h != w) {
                    check = false;
                    lblMax.Text = "Головної діагоналі немає"; 
                }
                for (int i = 0; i < w; i++)
                {
                    dataGridView1.Columns.Add("Column"+i, "Column " + i);

                }
                for (int i = 0; i < h; i++)
                {
                    dataGridView1.Rows.Add();

                }
                for (int i = 0; i < h; i++)
                {
                  
                    for (int j = 0; j < w; j++)
                    {
                        array[i,j]=  rnd.Next(1,50);
                        dataGridView1.Rows[i].Cells[j].Value = array[i,j];
                    }
                }
                dataGridView1.Rows.Add();
                int mult = 1;
                for (int i = 0; i < w; i++)
                {
                    mult = 1;
                    for (int j = 0; j < h; j++)
                    {
                        mult *=Convert.ToInt32( dataGridView1.Rows[j].Cells[i].Value);

                    }
                    dataGridView1.Rows[dataGridView1.Rows.Count -2].Cells[i].Value = mult;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[i].Style.BackColor = Color.Red;

                }
                dataGridView1.Columns.Add("Sum","Sum");
                int sum = 0;
                
                for (int i = 0; i < h; i++)
                {
                    sum = 0;
                    for (int j = 0; j < w; j++)
                    {       
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                       
                    }
                    dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count-1].Value = sum;
                    dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Style.BackColor = Color.Red;

                }
                if(check)
                {
                    int max = 0;
                    for (int i = 0; i < h; i++)
                    {

                        if(Convert.ToInt32( dataGridView1.Rows[i].Cells[i].Value) > max) max= Convert.ToInt32(dataGridView1.Rows[i].Cells[i].Value);

                    }
                    lblMax.Text += max;
                }

            }
           
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
