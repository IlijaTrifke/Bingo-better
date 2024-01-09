using System;

namespace Common
{
    [Serializable]

    public class Response
    {
        public int Broj { get; set; }
        public Operation Operacija { get; set; }
        public string Username { get; set; }
        public string PovratneInfo { get; set; }
    }
}
