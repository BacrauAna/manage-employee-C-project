using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking.rpc
{
    public class RPVProxy : IServices
    {
        private string host;
        private int port;

        private IObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle waitHandle;
        public RPVProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new MyException("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                waitHandle.WaitOne();
                //WaitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

        public virtual void login(Cont user, IObserver client)
        {
            Console.WriteLine("Ma aflu in login proxy");
            initializeConnection();
            Request nr = new Request();
            nr.Type = RequestType.LOGIN;
            nr.Data = user;
            sendRequest(nr);
            Response response = readResponse();
            if (response.Type == ResponseType.OK)
            {
                this.client = client;
                return;
            }
            if (response.Type == ResponseType.ERROR)
            {

                closeConnection();
                throw new MyException(response.Data.ToString());
            }
        }

        public void add(Users usr)
        {
            Console.WriteLine("Ma aflu in add proxy");
            Request nr = new Request();
            nr.Type = RequestType.SAVEANG;
            nr.Data = usr;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void modify(Users usr)
        {
            Console.WriteLine("Ma aflu in modify proxy");
            Request nr = new Request();
            nr.Type = RequestType.MODIFYANG;
            nr.Data = usr;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void preluat(Sarcini sarcini)
        {
            Console.WriteLine("Ma aflu in preia proxy");
            Request nr = new Request();
            nr.Type = RequestType.PREIASRC;
            nr.Data = sarcini;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void progresat(Sarcini sarcini)
        {
            Console.WriteLine("Ma aflu in progresat proxy");
            Request nr = new Request();
            nr.Type = RequestType.PROGRESSRC;
            nr.Data = sarcini;
            sendRequest(nr);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void finalizat(Sarcini sarcini)
        {
            Console.WriteLine("Ma aflu in finalizat proxy");
            Request nr = new Request();
            nr.Type = RequestType.FINALIZARESRC;
            nr.Data = sarcini;
            sendRequest(nr);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void modifySrc(Sarcini sarcin, Cont user)
        {
            Console.WriteLine("ma aflu in modifySrc proxy");
            Request nr = new Request();
            nr.Type = RequestType.MODIFYSARC;
            nr.Data = sarcin;
            nr.Data = user;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public void delete(Users usr)
        {
            Console.WriteLine("ma aflu in delete proxy");
            Request nr = new Request();
            nr.Type = RequestType.DELETEANG;
            nr.Data = usr;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            return;
        }

        public virtual void logout(Cont user, IObserver client)
        {
            Request nr = new Request();
            nr.Type = RequestType.LOGOUT;
            nr.Data = user;
            sendRequest(nr);
            Response response = readResponse();
            closeConnection();
            if (response.Type == ResponseType.ERROR)
            {

                throw new MyException(response.Data.ToString());
            }
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }


        public virtual void run()
        {
            while (!finished)
            {
                try
                {

                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    //if (isupdate((Response)response))
                    //{
                    //    handleUpdate((Response)response);
                    //}
                    //else
                    //{

                        //lock (responses)
                        //{


                      //      responses.Enqueue((Response)response);

                    //    }
                  //      waitHandle.Set();
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }

        public IEnumerable<Sarcini> getAllSarcini()
        {
            Request nr = new Request();
            nr.Type = RequestType.GETSARCINI;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            List<Sarcini> al = ((IEnumerable<Sarcini>)response.Data).ToList();
            return al;
        }

        public IEnumerable<Sarcini> getAllSarcUser(Cont user)
        {
            Request nr = new Request();
            nr.Type = RequestType.GETSARCINIUSR;
            sendRequest(nr);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            List<Sarcini> al = ((IEnumerable<Sarcini>)response.Data).ToList();
            return al;
        }

        public IEnumerable<Users> getAllUsActive()
        {
            Request nr = new Request();
            nr.Type = RequestType.GETUSACT;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            List<Users> al = ((IEnumerable<Users>)response.Data).ToList();
            return al;
        }

        public IEnumerable<Users> getAllUsers()
        {
            Request nr = new Request();
            nr.Type = RequestType.GETALLUSERS;
            sendRequest(nr);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            List<Users> al = ((IEnumerable<Users>)response.Data).ToList();
            return al;
        }

        public IEnumerable<Stari> getAllStari()
        {
            Request nr = new Request();
            nr.Type = RequestType.GETALLSTARI;
            sendRequest(nr);
            Response response = readResponse();
            if(response.Type == ResponseType.ERROR)
            {
                throw new MyException(response.Data.ToString());
            }
            List<Stari> al = ((IEnumerable<Stari>)response.Data).ToList();
            return al;
        }

        
    }
}
