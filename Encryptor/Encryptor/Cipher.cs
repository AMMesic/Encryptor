using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    abstract class Cipher : ICipher
    {
    /// <summary>
    /// Ärver från interfacet Ichipher och har en konstruktor som tar emot en string.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
        public abstract string Encrypt(string input);
        public abstract string Decrypt(string input);

        
        public string CipherName { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="ciphername"></param>
        public Cipher(string ciphername)
        {
            CipherName = ciphername;
        }

        /// <summary>
        /// Metoden skickar tillbaka namnet på chiffret.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CipherName;
        }

    }
}
