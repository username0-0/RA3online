using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RA3online
{
    class MD5
    {
        public static string Encrypt(string input)
        {
            return Encrypt(input, new UTF8Encoding());
        }

        public static string Encrypt(string input, int length)
        {
            string res = Encrypt(input, new UTF8Encoding());
            if (length == 16)
            {
                res = res.Substring(8, 16);
            }
            return res;
        }

        public static string Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}