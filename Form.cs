using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualizer
{
    public partial class Form : System.Windows.Forms.Form
    {

        Graphics graphics;
        int[] array;
        public Form()
        {
            InitializeComponent();
            panel1.Resize += panel1_Resize;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (array != null && graphics != null)
            {
                int numEntry = panel1.Width;
                int max = panel1.Height;
                graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, numEntry, max);

                for (int i = 0; i < numEntry; i++)
                {
                    int x = (int)(i * (float)numEntry / array.Length);
                    int height = (int)(array[i] * (float)max / array.Max());
                    graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), x, max - height, 1, height);
                }
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            int numEntry = panel1.Width;
            int max = panel1.Height;
            array = new int[numEntry];
            graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, numEntry, max);
            Random seed = new Random();
            for (int i = 0; i < numEntry; i++)
            {
                array[i] = seed.Next(0, max);
            }

            for (int i = 0; i < numEntry; i++)
            {
                graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, max - array[i], 1, max);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            ISort se = new Bubble();
            se.bone(array, graphics, panel1.Height);
        }
    }
}
