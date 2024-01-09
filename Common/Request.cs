using System;

namespace Common
{
    [Serializable]

    public class Request
    {
        public Operation Operacija { get; set; }
        public int Broj { get; set; }
        public string Username { get; set; }
    }
}
