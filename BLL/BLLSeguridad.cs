using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSeguridad
    {
        public string EncriptarPW(string pw)
        {
            UnicodeEncoding codigo = new UnicodeEncoding();
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(codigo.GetBytes(pw));

            return Convert.ToBase64String(hash);
        }
    }
}
