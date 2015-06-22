using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class CONSTANT
    {
        // Connection string to connect to the database
        public const string STR = SERVER + DATABASE + UID + PASSWORD;

        public const string SERVER = "server=259a2693-7bcb-46e5-adb2-a47a0101d17f.mysql.sequelizer.com;";
        public const string DATABASE = "database=db259a26937bcb46e5adb2a47a0101d17f;charset=utf8;";
        public const string UID = "uid=oosbszkpqgotoeqb;";
        public const string PASSWORD = "pwd=4Cu2nEaWFcZNZVKsx2vbuSYdTw46T5wipApPhfTdG4FQeSSZKpwPWKPjLrhXJcdJ";
    
        // App Key to connect to Dropbox
        public const string APP_KEY = "9g6pg6vi7lstkoh";
        public const string APP_SECRET = "er56qsux5hjdpwq";
    }
}
