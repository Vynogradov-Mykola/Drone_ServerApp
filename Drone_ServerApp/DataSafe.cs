using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_ServerApp
{
    class DataSafe
    {
        public string Safer(string dataReceived)
        {
            string ret = "No access";
            RequestHandler sender = new RequestHandler();
            //IF for find unavaibled things for client
           
            if (dataReceived.ToLower().Contains(" drop ") || dataReceived.ToLower().Contains(" insert ") || dataReceived.ToLower().Contains(" alert ") || dataReceived.ToLower().Contains(" update "))
            {
                return ret;
            }
            return ret = sender.Request(dataReceived); ;
        }
    }
}
