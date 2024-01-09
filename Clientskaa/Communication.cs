using Common;
using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Clientskaa
{
    public class Communication
    {
        Socket socket;
        CommunicationHelper helper;
        private static Communication _instance;
        // public string IstekloVremePoruka { get; set; }
        public FrmLogin FrmLogin { get; set; }
        public event EventHandler<Response> dobijenOdgovor;
        public static Communication Instance
        {
            get
            {
                if (_instance == null)
                {

                    _instance = new Communication();
                }
                return _instance;
            }
        }
        //jaoooo pazi return
        private Communication()
        {

        }
        public void Connection()
        {
            //!= od communicationhelpera
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            helper = new CommunicationHelper(socket);

        }
        public void Ulogujse(string ime)
        {
            Request req = new Request()
            {
                Operacija = Operation.Login,
                Username = ime
            };
            helper.Send(req);
        }
        public void ZapocniIgru()
        {
            Response res = (Response)helper.Recieve();
            //res.Operacija = Operation.SaljiBroj;
            //res.

        }



        public void SaljiBroj(int v)
        {
            Request req = new Request();
            req.Operacija = Operation.SaljiBroj;
            req.Broj = v;
            helper.Send(req);
        }

        //public string PrimiKraj()
        //{
        //    return ((Response)helper.Recieve()).PovratneInfo;
        //}
        //public void PrimiKrajj()
        //{

        //    Response res = (Response)helper.Recieve();
        //    switch (res.Operacija)
        //    {

        //        case Operation.VratiKraj:

        //            break;
        //        case Operation.VratiPobednika:

        //            break;
        //        default:
        //            break;
        //    }
        //    //IstekloVremePoruka = res.PovratneInfo;

        //}


        public void Osluskuj()
        {
            try
            {
                while (true)
                {
                    Response res = (Response)helper.Recieve();
                    dobijenOdgovor?.Invoke(this, res);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>" + ex.Message);
            }
        }
    }
}
