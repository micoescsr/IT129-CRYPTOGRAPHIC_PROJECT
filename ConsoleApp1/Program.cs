using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random rand = new Random();

    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Kama Sutra Cipher");
                Console.WriteLine("2. Monoalphabetic Cipher");
                Console.WriteLine("3. Vernam Cipher");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 4)
                    break;

                Console.WriteLine("Choose:");
                Console.WriteLine("1. Encryption");
                Console.WriteLine("2. Decryption");
                Console.WriteLine("3. Go back");
                Console.Write("Enter your choice: ");
                int subChoice = int.Parse(Console.ReadLine());

                if (subChoice == 3)
                    continue;

                Console.Write("Enter text: ");
                string text = Console.ReadLine();

                switch (choice)
                {
                    case 1:
                        Dictionary<char, char> kamaKey = GenerateKamaSutraKey();
                        if (subChoice == 1)
                            Console.WriteLine("Encrypted: " + KamaSutraCipher(text, kamaKey));
                        else if (subChoice == 2)
                            Console.WriteLine("Decrypted: " + KamaSutraCipher(text, kamaKey));
                        break;
                    case 2:
                        string monoKey = GenerateMonoalphabeticKey();
                        if (subChoice == 1)
                            Console.WriteLine("Encrypted: " + MonoalphabeticCipher(text, monoKey));
                        else if (subChoice == 2)
                        {
                            Console.Write("Enter Monoalphabetic Key: ");
                            string monoKeyDec = Console.ReadLine();
                            Console.WriteLine("Decrypted: " + MonoalphabeticDecipher(text, monoKeyDec));
                        }
                        break;
                    case 3:
                        if (subChoice == 1)
                        {
                            string vernamKey = GenerateVernamKey(text.Length);
                            Console.WriteLine("Key: " + vernamKey);
                            Console.WriteLine("Encrypted: " + VernamCipher(text, vernamKey));
                        }
                        else if (subChoice == 2)
                        {
                            Console.Write("Enter Vernam Key: ");
                            string vernamKeyDec = Console.ReadLine();
                            Console.WriteLine("Decrypted: " + VernamCipher(text, vernamKeyDec));
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    static Dictionary<char, char> GenerateKamaSutraKey()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string firstHalf = alphabet.Substring(0, 13);
        string secondHalf = alphabet.Substring(13);

        Dictionary<char, char> keyMap = new Dictionary<char, char>();
        for (int i = 0; i < 13; i++)
        {
            keyMap[firstHalf[i]] = secondHalf[i];
            keyMap[secondHalf[i]] = firstHalf[i];
        }
        return keyMap;
    }

    static string GenerateMonoalphabeticKey()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(alphabet.OrderBy(x => rand.Next()).ToArray());
    }

    static string GenerateVernamKey(int length)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Range(0, length).Select(x => alphabet[rand.Next(alphabet.Length)]).ToArray());
    }

    static string KamaSutraCipher(string text, Dictionary<char, char> key)
    {
        text = text.ToUpper();
        string result = "";
        foreach (char c in text)
        {
            result += key.ContainsKey(c) ? key[c] : c;
        }
        return result;
    }

    static string MonoalphabeticCipher(string text, string key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        text = text.ToUpper();
        string result = "";
        foreach (char c in text)
        {
            if (alphabet.Contains(c))
            {
                int index = alphabet.IndexOf(c);
                result += key[index];
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    static string MonoalphabeticDecipher(string text, string key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        text = text.ToUpper();
        string result = "";
        foreach (char c in text)
        {
            if (key.Contains(c))
            {
                int index = key.IndexOf(c);
                result += alphabet[index];
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    static string VernamCipher(string text, string key)
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
