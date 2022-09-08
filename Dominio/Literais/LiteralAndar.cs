using System.Collections.Generic;
using System.Linq;

namespace ConsoleImpl.Dominio.Literais
{
    public class LiteralAndar
    {
        public static List<LtAndar> ListarTodos()
        {
            var lRet = new List<LtAndar>();
            for (int iAndar = 0; iAndar <= 15; iAndar++)
            {
                lRet.Add(new LtAndar { Numero = iAndar });
            }
            return lRet;
        }
        
        public static LtAndar GetByNumero(int numero)
        {
            return ListarTodos().First(x => x.Numero == numero);
        }
        
        public static LtAndar? GetByNumeroOrDefault(int numero)
        {
            return ListarTodos().FirstOrDefault(x => x.Numero == numero);
        }
    }
}