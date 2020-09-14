using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2070,12,17);
            DateTime diaHoje = DateTime.Now;

            TimeSpan diff = dataFimPagamento - diaHoje; 

            Console.WriteLine( diaHoje + "\n" + dataFimPagamento + "\n" + "Vencimento em " + diff.Days + " " + "Dias");

            ContaCorrente conta = new ContaCorrente(3219, 132);
            Console.ReadLine();
            Console.WriteLine("Vencimento em" + Humanizer.TimeSpanHumanizeExtensions.Humanize(diff));
        }
    }
}
