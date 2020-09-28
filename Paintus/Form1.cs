using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Paintus
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Graphics g1;
        string cur = "";
        Point sp, ep;
        Pen p=new Pen(Color.White,1);
        int size = 1;
        Color cc=Color.White;
        bool ismd = false;
        Stack stack = new Stack();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1";
            textBox2.Text = "10";
            bmp = new Bitmap(996, 461);
            g = Graphics.FromImage(bmp);
            g1 = panel1.CreateGraphics();
            p = new Pen(cc, size);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cut
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //save
            bmp.Save(cur, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //erase
            p = new Pen(Color.Black,int.Parse(textBox2.Text));
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //undo
  
        }

        private void button12_Click(object sender, EventArgs e)
        {
            size = int.Parse(textBox1.Text);
            p = new Pen(cc, size);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //redo
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //copy
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //paste
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //open
            openFileDialog1.Title = "Open";
            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = ".bmp";
            openFileDialog1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //new

            saveFileDialog1.Title = "New";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt= ".bmp";
            saveFileDialog1.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //color
            colorDialog1.ShowDialog();
            cc = colorDialog1.Color;
            p = new Pen(colorDialog1.Color,size);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            cur = saveFileDialog1.FileName;
            bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            cur = openFileDialog1.FileName;
            bmp = new Bitmap(cur);
            Bitmap temp = new Bitmap(bmp);
            bmp.Dispose();
            bmp = new Bitmap(temp);
            g = Graphics.FromImage(bmp);
            g1.DrawImage(bmp, 0, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = true;
            sp = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(ismd==true)
            {
                ep = e.Location;
                g1.DrawLine(p,sp,ep);
                g.DrawLine(p, sp, ep);
                sp = ep;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (ismd == true)
            {
                ep = e.Location;
                ismd = false;
            } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
