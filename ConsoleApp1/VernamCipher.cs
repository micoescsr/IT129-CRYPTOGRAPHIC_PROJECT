using System;
using System.Linq;

namespace CryptoProgram.Ciphers
{
    class VernamCipher : Cipher
    {
        private string key;
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public VernamCipher(string text)
        {
            key = GenerateVernamKey(text.Length);
        }

        private string GenerateVernamKey(int length)
        {
            return new string(Enumerable.Range(0, length).Select(x => alphabet[new Random().Next(alphabet.Length)]).ToArray());
        }

        public override string Encrypt(string text) => Transform(text, key);
        public override string Decrypt(string text) => Transform(text, key);

        private string Transform(string text, string key)
        {
            text = text.ToUpper();
            key = key.ToUpper();
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    int xor = (text[i] - 'A') ^ (key[i] - 'A');
                    result += (char)('A' + xor);
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
    }
}
