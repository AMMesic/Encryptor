using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    
    class OddAndEvenChipher : Cipher
    {
        /// <summary>
        /// Denna klass ärver från den abstrakta klassen Cipher och i denna klass ligger funktionen för att dekryptera och enkryptera.
        ///Detta Cipher bygger på att kryptera en mening genom att skriva ihop alla bokstäver i en mening som finns på udda positoner. Det slås sedan ihop med alla bokstäver som finns på jämna positioner.
        /// </summary>
        /// <param name="name"></param>
        public OddAndEvenChipher(string name) : base(name)
        {

        }

        /// <summary>
        /// Dekrypterar som krypterar strängen.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Decrypt(string input)
        {
            
            string jämna = "";
            string udda = "";
            string sum = "";

            udda = input.Substring(0, input.Length / 2);
            jämna = input.Substring(input.Length / 2);

            for (int i = 0; i < udda.Length; i++)
            {
                {
                    sum += jämna[i];
                    sum += udda[i];
                }
            }
            if(input.Length % 2 != 0)
            {
                sum += jämna[jämna.Length - 1];
            }
            return sum;
        }
        /// <summary>
        /// Metod som hämtas från den abstrakta klassen "Chiper". Denna metod är av override så att det går att implementera en egen metod. Denna metod krypterar en mening genom att skriva ihop bokstäver som är av udda och jämna.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Encrypt(string input)
        {
            string jämna = "";
            string udda = "";
            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 == 1)
                {
                    udda += input[i];
                } else
                {
                    jämna += input[i];
                }
            }
            return udda + jämna;
        }
    }
}
