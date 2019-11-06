using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    /// <summary>
    /// Denna klass ärver fron den abstrakta klassen Cipher. I denna klass så liger funktioner för att dekryptera och enkryptera detta cipher.
    /// </summary>
    class Rövarspråket : Cipher
    {

        public Rövarspråket(string name) : base(name)
        {

        }

        /// <summary>
        /// Kryptering för rövarspråket. Innehåller en lista för gemener och versaler. Bokstaven 'o' läggs till för varje konsonant i meningen.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Encrypt(string input)
        {
            string encrypt = "";
            List<char> gemener = new List<char> { 'a', 'o', 'ö', 'ä', 'å', 'y', 'e', 'i', 'u' };
            List<char> versaler = new List<char> { 'A', 'O', 'Ö', 'Ä', 'Å', 'Y', 'E', 'I', 'U' };
            

            for (int i = 0; i < input.Length; i++)
            {
                if (!gemener.Contains(input[i]) && !versaler.Contains(input[i]))
                {
                    encrypt += input[i] + "o" + input[i];
                } else
                {
                    encrypt += input[i];
                }               
            }
            return encrypt;
        }

        /// <summary>
        /// Dekryptering av krypteringen.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override string Decrypt(string input)
        {
            List<char> gemener = new List<char> { 'a', 'o', 'ö', 'ä', 'å', 'y', 'e', 'i', 'u' };
            List<char> versaler = new List<char> { 'A', 'O', 'Ö', 'Ä', 'Å', 'Y', 'E', 'I', 'U' };

            for (int i = 0; i < input.Length-2; i++)
            {
                if(!gemener.Contains(input[i]) && !versaler.Contains(input[i]))
                {
                    input = input.Remove(i,2);
                }
            }
            return input;
        }
    }
}
