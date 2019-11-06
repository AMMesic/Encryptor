using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    class CeasarChipher : Cipher
    {
        /// <summary>
        /// Klassen ärver från den abstrakta klassen Cipher och i denna klass så ligger funktionen för att dektryptera och enkryptera detta cipher. Detta cipher bygger på att alla bokstäver i den mening som krypteras förflyttas med ett angivet antal positiner i alfabetet.
        /// </summary>
        private int Steps;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="reversal"></param>
        public CeasarChipher(int steps, string reversal) : base(reversal)
        {
            Steps = steps;
            
        }


        
        /// <summary>
        /// Metod för "decrypt" av Ceasarchiffer. Denna metod kallar på GetChipperChar för att dekryptera där den går steg tillbaka till den ursprungliga strängen.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Decrypt(string input)
        {

            string crypt = "";
            for (int i = 0; i < input.Length; i++)
            {
                crypt += GetChipherChar(input[i], 26-Steps);
            }
            return crypt;
        }

        /// <summary>
        /// Metod för "encrypt" av caesarchiffer. Denna metod kallar på metoden nedan.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Encrypt(string input)
        {
            string crypt = "";
            for (int i = 0; i < input.Length; i++)
            {
                crypt += GetChipherChar(input[i], Steps);

            }
            return crypt;
        }

        /// <summary>
        /// Metod for CeasarChiffer.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        private char GetChipherChar(char c, int steps)
        {
            List<char> specialCharachters = new List<char>() {'å', 'ä', 'ö' };

            if (!char.IsLetter(c) || specialCharachters.Contains(char.ToLower(c)))
                return c;

            char d = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + steps) - d) % 26) + d);
        }
    }
}
