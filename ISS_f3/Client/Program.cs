using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        static class StartChatClient
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
                IDictionary props = new Hashtable();

                props["port"] = 0;
                TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
                ChannelServices.RegisterChannel(channel, false);
                IServices services =
                     (IServices)Activator.GetObject(typeof(IServices), "tcp://localhost:55555/Chat");

                ClientController ctrl = new ClientController(services);
                Form1 win = new Form1(ctrl);
                Application.Run(win);
            }

        }
    }
}
