using System;
using System.Linq;

namespace CryptoProgram.Ciphers
{
    class MonoalphabeticCipher : Cipher
    {
        private string key;
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public MonoalphabeticCipher()
        {
            key = GenerateMonoalphabeticKey();
        }

        private string GenerateMonoalphabeticKey()
        {
            return new string(alphabet.OrderBy(x => new Random().Next()).ToArray());
        }

        public override string Encrypt(string text) => Transform(text, alphabet, key);
        public override string Decrypt(string text) => Transform(text, key, alphabet);

        private string Transform(string text, string from, string to)
        {
            text = text.ToUpper();
            string result = "";
            foreach (char c in text)
            {
                int index = from.IndexOf(c);
                result += index != -1 ? to[index] : c;
            }
            return result;
        }
    }
}
