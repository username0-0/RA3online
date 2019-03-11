using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA3online
{
    class UUID
    {
        public static string GetUUID()
        {
            return MD5.Encrypt(Environment.MachineName,32);
        }

    }
}
