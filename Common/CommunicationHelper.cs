using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class CommunicationHelper
    {
        Socket sockett;
        NetworkStream stream;
        BinaryFormatter formatter;
        public CommunicationHelper(Socket socket)
        {
            sockett = socket;
            stream = new NetworkStream(socket);
            formatter = new BinaryFormatter();

        }
        public void Send(object Srgument)
        {
            formatter.Serialize(stream, Srgument);
        }
        public object Recieve()
        {
            return formatter.Deserialize(stream);
        }

    }
}
