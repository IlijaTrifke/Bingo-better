using Common;
using System.Net.Sockets;
using System.Timers;

namespace Serverskaa
{

    public class ClientHandler
    {
        Socket s;
        CommunicationHelper helper;
        System.Timers.Timer timer2 = new System.Timers.Timer();
        public string Username { get; set; }


        //PROVERI KAKO OVO RAAAAAAAAAAAAAAAADIIIIIIIIIIIII???????????????????????????
        public ClientHandler(Socket so)
        {
            //!!!!!!!!! communication.connect
            s = so;
            helper = new CommunicationHelper(s);
        }

        public void Login()
        {
            Request req = (Request)helper.Recieve();
            //blokirajuca je receive
            Username = req.Username;

        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            ProglasiKrajcic();
            timer2.Stop();

        }
        public void ZapocniIgru()
        {
            Response res = new Response();
            res.Operacija = Operation.KreniIgru;
            res.Username = Username;
            helper.Send(res);
            timer2.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer2.Interval = 10000;
            timer2.Start();
        }

        public int PrimiBroj()
        {
            Request req = (Request)helper.Recieve();
            timer2.Stop();
            return req.Broj;

        }

        internal void SendRezultat(Response r)
        {
            helper.Send(r);
        }

        internal void ProglasiKrajcic()
        {
            Response res = new Response()
            {
                PovratneInfo = "Isteklo vam je vreme",
                Operacija = Operation.VratiKraj
            };
            helper.Send(res);
        }
    }
}
