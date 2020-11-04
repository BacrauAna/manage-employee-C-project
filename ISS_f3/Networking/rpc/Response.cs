using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.rpc
{
    enum ResponseType
    {
        ERROR,
        LOGIN,
        OK,
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
    class Response
    {
        public Response()
        {

        }
        public ResponseType type;
        public object data;

        public ResponseType Type
        {
            get { return type; }
            set { type = value; }
        }
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        [Serializable]
        public class Builder
        {
            private Response response = new Response();
            public Builder type(ResponseType t)
            {
                response.Type = t;
                return this;
            }
            public Builder data(object t)
            {
                response.data = t;
                return this;
            }
            public Response build()
            {
                return response;
            }
        }
    }
}
