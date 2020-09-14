using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    internal class AutenticacaoHelper
    {
        public bool CompararaSenhas(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaTentativa == senhaVerdadeira;
        }
    }
}
