using Common;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Clientskaa
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Communication.Instance.Connection();
            button2.Visible = false;
            Communication.Instance.dobijenOdgovor += Instance_dobijenOdgovor;
            Thread thread = new Thread(Communication.Instance.Osluskuj);
            thread.Start();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Communication.Instance.Ulogujse(textBox1.Text);
        }

        private void Instance_dobijenOdgovor(object sender, Common.Response e)
        {
            this.Invoke(new Action(() =>
            {
                //ili whole ilioevent
                switch (e.Operacija)
                {
                    case Operation.KreniIgru:
                        textBox1.Text = "";
                        button1.Enabled = false;
                        button2.Visible = true;
                        button1.Visible = false;
                        break;
                    case Operation.VratiKraj:
                        MessageBox.Show(e.PovratneInfo);
                        button2.Enabled = false;
                        Communication.Instance.SaljiBroj(-1);
                        break;
                    case Operation.VratiPobednika:
                        MessageBox.Show(e.PovratneInfo);
                        break;


                    default:
                        break;
                }
            }));
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

            Communication.Instance.SaljiBroj(int.Parse(textBox1.Text));



        }
    }
}
