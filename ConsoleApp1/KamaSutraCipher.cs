using System;
using System.Collections.Generic;

namespace CryptoProgram.Ciphers
{
    class KamaSutraCipher : Cipher
    {
        private Dictionary<char, char> keyMap;

        public KamaSutraCipher()
        {
            keyMap = GenerateKamaSutraKey();
        }

        private Dictionary<char, char> GenerateKamaSutraKey()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string firstHalf = alphabet.Substring(0, 13);
            string secondHalf = alphabet.Substring(13);

            Dictionary<char, char> key = new Dictionary<char, char>();
            for (int i = 0; i < 13; i++)
            {
                key[firstHalf[i]] = secondHalf[i];
                key[secondHalf[i]] = firstHalf[i];
            }
            return key;
        }

        public override string Encrypt(string text) => Transform(text);
        public override string Decrypt(string text) => Transform(text);

        private string Transform(string text)
        {
            text = text.ToUpper();
            string result = "";
            foreach (char c in text)
            {
                result += keyMap.ContainsKey(c) ? keyMap[c] : c;
            }
            return result;
        }
    }
}
