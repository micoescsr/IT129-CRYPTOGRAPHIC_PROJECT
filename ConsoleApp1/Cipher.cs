using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProgram.Ciphers
{
    abstract class Cipher
    {
        public abstract string Encrypt(string text);
        public abstract string Decrypt(string text);
    }
}
