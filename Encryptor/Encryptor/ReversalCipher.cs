using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    class ReversalCipher : Cipher
    {
        /// <summary>
        /// Klassen ärver från abstrakta klassen cipher och i denna klass så ligger funktionen för att dectryptera och encryptera detta cihper.
        /// </summary>
        /// <param name="reversal"></param>
        public ReversalCipher(string reversal) : base(reversal)
        {
            
        }

        /// <summary>
        /// Metod för att vända tillbaka strängen. Returnerar "Encrypt" metoden med "input" från "Decrypt" metoden som argument.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Decrypt(string input)
        {
            return Encrypt(input);
        }

        /// <summary>
        /// Metod för att loppa igen strängen baklänges.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Encrypt(string input)
        {
            string Reversed = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Reversed += input[i];
            }
            return Reversed;
        }
    }
}
