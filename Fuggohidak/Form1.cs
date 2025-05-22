using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form1 : Form
    {
        public static List<Fuggohid> lista = new List<Fuggohid>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("fuggohidak.csv");
            string elsosor = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Fuggohid sor = new Fuggohid(sr.ReadLine());
                lista.Add(sor);
                listBox1.Items.Add(sor.hid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbHely.Text = lista[listBox1.SelectedIndex].hely;
            txbOrszag.Text = lista[listBox1.SelectedIndex].orszag;
            txbHossz.Text = lista[listBox1.SelectedIndex].hossz.ToString();
            txbEv.Text = lista[listBox1.SelectedIndex].atadas;
        }
    }

    public class Fuggohid
    {
        public int helyezes { get; set; }
        public string hid { get; set; }
        public string hely { get; set; }
        public string orszag { get; set; }
        public int hossz { get; set; }
        public string atadas { get; set; }

        public Fuggohid(string sor)
        {
            string[] d = sor.Split('\t');
            helyezes = Convert.ToInt32(d[0]);
            hid = d[1];
            hely = d[2];
            orszag = d[3];
            hossz = Convert.ToInt32(d[4]);
            atadas = d[5];
        }
    }
}
