using System;
using System.Threading;
using System.Windows.Forms;

namespace Serverskaa
{
    public partial class FrmServer : Form
    {
        Server s;
        System.Windows.Forms.Timer timer;
        System.Windows.Forms.Timer time;


        public FrmServer()
        {
            InitializeComponent();
            btnUgasiServer.Enabled = false;
            btnPokreniIgru.Enabled = false;

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            btnPokreniServer.Enabled = false;
            btnUgasiServer.Enabled = true;
            s = new Server();
            s.Start();
            btnPokreniIgru.Enabled = true;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;

            timer.Tick += (s, a) =>
            {
                label1.Text = new Random().Next(1, 100).ToString();

            };


            timer.Start();
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            btnUgasiServer.Enabled = false;
            btnPokreniServer.Enabled = true;

            s.Stop();
            timer.Stop();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //probaj i kad bi vreme ograniceno imali
            timer.Stop();
            Server.pobednickibroj = int.Parse(label1.Text);
            s.ZapocniIgru();
            //time = new System.Windows.Forms.Timer();
            //time.Interval = 10000;
            //time.Tick += (b, a) =>
            //{
            //    s.ProglasiKraj();
            //    time.Stop();

            //};
            //time.Start();

            Thread thread = new Thread(s.ProglasanjePobednika);
            thread.Start();
            //ne mora sad kad je obrisan tajmer sa tredom

            //sad se poziva...

            //pozivaj obvz

            //randomize treab da zaustavi
        }
    }
}
