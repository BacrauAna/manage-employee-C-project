using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;


namespace Server
{
    using Networking;
    using Networking.rpc;
    using Persistence;

    using Server;
    using Services;
    using System.Collections;
    using System.Configuration;
    using System.Net.Sockets;
    using System.Threading;
    using System.IO;
    using System.Runtime.Remoting.Channels.Tcp;

    class StartServer
    {
        static void Main(string[] args)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);
            IUseriRepository ur = new UseriRepository();
            ISarciniRepository sr = new SarciniRepository();
            IStariRepository str = new StariRepository();
            var serv = new ServerImplementation(ur, sr, str);

            RemotingServices.Marshal(serv, "chat");
            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
