using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    /// <summary>
    /// Deklarerar ett kontrakt för att de klasser/interfaces som implementerar detta interface har med dessa två metoder.
    /// </summary>
    interface ICipher
    {
        string Encrypt(string input);
        string Decrypt(string input);


    }
}
