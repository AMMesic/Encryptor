using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    /// <summary>
    /// Klass med samling som ärver från Icipher. Klassen används för funktionalitet för att kalla på de andra ciphers och deras metoder samt att skapa en lista som sparar de aktiva ciphers.
    /// </summary>
    class Samling : ICipher 
    {
        private List<Cipher> CifferList = new List<Cipher>();
        Cipher reversalCipher = new ReversalCipher("Reversal Cipher");
        Cipher caesarCipher = new CeasarChipher(1, "The Caesar Cipher");


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Decrypt(string input)
        {
            for (int i = CifferList.Count - 1; i >= 0; i--)
            {
                input = CifferList[i].Decrypt(input);
            }
            return input;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Encrypt(string input)
        {
            for (int i = 0; i < CifferList.Count; i++)
            {
                input = CifferList[i].Encrypt(input);
            }
            return input;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCiffer"></param>
        public void AddCipher(Cipher addCiffer)
        {
            CifferList.Add(addCiffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removeCiffer"></param>
        public void RemoveCipher(Cipher removeCiffer)
        {
            CifferList.Remove(removeCiffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cipher> Getlist()
        {
            return CifferList;
        }
    }
}
