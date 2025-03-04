using System;
using CryptoProgram.Ciphers;

namespace CryptoProgram
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine(  "1. Kama Sutra Cipher");
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
                    Cipher cipher = null;

                    switch (choice)
                    {
                        case 1:
                            cipher = new KamaSutraCipher();
                            break;
                        case 2:
                            cipher = new MonoalphabeticCipher();
                            break;
                        case 3:
                            cipher = new VernamCipher(text);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            continue;
                    }

                    if (subChoice == 1)
                        Console.WriteLine("Encrypted: " + cipher.Encrypt(text));
                    else if (subChoice == 2)
                        Console.WriteLine("Decrypted: " + cipher.Decrypt(text));
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
    }
}