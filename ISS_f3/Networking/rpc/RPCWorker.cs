using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Networking.rpc
{
    public class RPCWorker : IObserver
    {
        private IServices server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        public RPCWorker(IServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    System.Threading.Thread.Sleep(1000);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            Console.WriteLine("am intrat in handle Request");
            if (request.Type == RequestType.LOGIN)
            {
                Console.WriteLine("Login request ...");
                Cont ac = (Cont)request.Data;


                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de login in handreRequest - rpcWorker");
                        server.login(ac, this);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.OK;
                    ok.Data = ac;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.SAVEANG)
            {
                Console.WriteLine("save request");
                Users us = (Users)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de save in handleReq -rpcWorker");
                        server.add(us);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.SAVEANG;
                    ok.Data = us;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.MODIFYANG)
            {
                Console.WriteLine("modify request");
                Users us = (Users)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de modify in handlereq  - rpcWorker");
                        server.modify(us);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.MODIFYANG;
                    ok.Data = us;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.PREIASRC)
            {
                Console.WriteLine("preia request");
                Sarcini sc = (Sarcini)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de preia in handleReq - rpcWorker");
                        server.preluat(sc);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.PREIASRC;
                    ok.Data = sc;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.PROGRESSRC)
            {
                Console.WriteLine("preia request");
                Sarcini sc = (Sarcini)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de progresat in handleReq - rpcWorker");
                        server.progresat(sc);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.PROGRESSRC;
                    ok.Data = sc;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.FINALIZARESRC)
            {
                Console.WriteLine("preia request");
                Sarcini sc = (Sarcini)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de finalizare in handleReq - rpcWorker");
                        server.finalizat(sc);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.FINALIZARESRC;
                    ok.Data = sc;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.MODIFYSARC)
            {
                Console.WriteLine("modify sarcina request");
                Cont us = (Cont)request.Data;
                Sarcini sa = (Sarcini)request.Data;
                try
                {
                    lock (server)
                    {
                        Console.WriteLine("inainte de modify sarcina in handlereq - rpcWorker");
                        server.modifySrc(sa, us);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.MODIFYSARC;
                    ok.Data = sa;
                    ok.Data = us;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.DELETEANG)
            {
                Console.WriteLine("delete request");
                Users us = (Users)request.Data;

                try
                {
                    lock (server)
                    {
                        Console.WriteLine("ininte de delete in handlereq =rpc worker");
                        server.delete(us);
                    }
                    Response ok = new Response();
                    ok.Type = ResponseType.DELETEANG;
                    ok.Data = us;
                    return ok;
                }
                catch (MyException e)
                {
                    connected = false;
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if (request.Type == RequestType.LOGOUT)
            {
                Console.WriteLine("Logout request");
                Cont ac = (Cont)request.Data;
                try
                {
                    lock (server)
                    {

                        server.logout(ac, this);

                    }
                    connected = false;
                    Response ok = new Response();
                    ok.Type = ResponseType.OK;
                    ok.Data = ac;
                    return ok;

                }
                catch (MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.GETSARCINI)
            {
                Console.WriteLine("get all sarcini request");
                Cont ac = (Cont)request.Data;
                try
                {
                    List<Sarcini> al;
                    lock (server)
                    {
                        al = server.getAllSarcini().ToList();
                    }
                    Response getAlls = new Response();
                    getAlls.Type = ResponseType.GETSARCINI;
                    getAlls.Data = al;
                    return getAlls;
                }
                catch(MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.GETSARCINIUSR)
            {
                Console.WriteLine("get all sarcini user request");
                Cont ac = (Cont)request.Data;
                try
                {
                    List<Sarcini> al;
                    lock (server)
                    {
                        al = server.getAllSarcUser(ac).ToList();
                    }
                    Response getallusrsc = new Response();
                    getallusrsc.Type = ResponseType.GETSARCINIUSR;
                    getallusrsc.Data = al;
                    return getallusrsc;
                }
                catch (MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.GETUSACT)
            {
                Console.WriteLine("get all users active request");
                Cont ac = (Cont)request.Data;
                try
                {
                    List<Users> al;
                    lock (server)
                    {
                        al = server.getAllUsActive().ToList();
                    }
                    Response getAllu = new Response();
                    getAllu.Type = ResponseType.GETUSACT;
                    getAllu.Data = al;
                    return getAllu;
                }
                catch(MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.GETALLUSERS)
            {
                Console.WriteLine("get all users request");
                Cont ac = (Cont)request.Data;
                try
                {
                    List<Users> al;
                    lock (server)
                    {
                        al = server.getAllUsers().ToList();
                    }
                    Response getAllu = new Response();
                    getAllu.Type = ResponseType.GETALLUSERS;
                    getAllu.Data = al;
                    return getAllu;
                }
                catch (MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            if(request.Type == RequestType.GETALLSTARI)
            {
                Console.WriteLine("get all stari request");
                Cont ac = (Cont)request.Data;
                try
                {
                    List<Stari> al;
                    lock (server)
                    {
                        al = server.getAllStari().ToList();
                    }
                    Response getAllst = new Response();
                    getAllst.Type = ResponseType.GETALLSTARI;
                    getAllst.Data = al;
                    return getAllst;
                }
                catch (MyException e)
                {
                    Response error = new Response();
                    error.Type = ResponseType.ERROR;
                    error.Data = e.Message;
                    return error;
                }
            }
            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();

        }
    }
}
