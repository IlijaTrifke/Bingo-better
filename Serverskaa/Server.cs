using Common;
using System;
using System.Net;
using System.Net.Sockets;

namespace Serverskaa
{
    public class Server
    {
        public static int brojac = 0;
        Socket osluskujucisocket;
        ClientHandler handler1;
        ClientHandler handler2;
        public static int pobednickibroj;


        public Server()
        {
            osluskujucisocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start()
        {
            //IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("9999"));
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            osluskujucisocket.Bind(ipendpoint);
            osluskujucisocket.Listen(5);
            Listen();
        }
        public void Listen()
        {
            Socket klijentskisoket1 = osluskujucisocket.Accept();
            Socket klijentskisoket2 = osluskujucisocket.Accept();
            handler1 = new ClientHandler(klijentskisoket1);
            handler2 = new ClientHandler(klijentskisoket2);
            handler1.Login();
            handler2.Login();//nema handle request,
            //!!!!!!!!!!!

        }



        public void Stop()
        {
            osluskujucisocket.Close();
        }
        public void ZapocniIgru()
        {
            handler1.ZapocniIgru();
            handler2.ZapocniIgru();


        }
        public void ProglasanjePobednika()
        {
            int br1;
            int br2;
            br1 = handler1.PrimiBroj();
            br2 = handler2.PrimiBroj();
            Response r = new Response()
            {
                Operacija = Operation.VratiKraj,

            };
            if (Math.Abs(br1 - pobednickibroj) > Math.Abs(br2 - pobednickibroj))
            {
                r.PovratneInfo = $"Pobedio je: {handler2.Username}";


            }
            else if (Math.Abs(br1 - pobednickibroj) < Math.Abs(br2 - pobednickibroj))
            {
                r.PovratneInfo = $"Pobedio je: {handler1.Username}";


            }
            else
            {
                r.PovratneInfo = "Nereseno je";

            }
            handler1.SendRezultat(r);
            handler2.SendRezultat(r);

        }
        //public void ProglasiKraj()
        //{
        //    handler1.ProglasiKrajcic();
        //    handler2.ProglasiKrajcic();

        //}

    }
}
