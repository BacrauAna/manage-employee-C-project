using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.rpc
{
    enum RequestType
    {
        LOGIN,
        LOGOUT,
        GETSARCINI,
        GETSARCINIUSR,
        GETUSACT,
        GETALLUSERS,
        GETALLSTARI,
        SAVEANG,
        DELETEANG,
        MODIFYANG,
        MODIFYSARC,
        PREIASRC,
        PROGRESSRC,
        FINALIZARESRC
    }

    [Serializable]
    class Request
    {
        public Request() { }
        public RequestType type;
        public object data;

        public RequestType Type
        {
            get { return type; }
            set { type = value; }
        }
        public object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
