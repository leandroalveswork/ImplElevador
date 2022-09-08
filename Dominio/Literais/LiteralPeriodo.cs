using System.Collections.Generic;
using System.Linq;

namespace ConsoleImpl.Dominio.Literais
{
    public class LiteralPeriodo
    {
        public static readonly LtPeriodo Matutino = new LtPeriodo
        {
            Id = 1,
            Nome = "Matutino",
            Sigla = "M"
        };
        public static readonly LtPeriodo Vespertino = new LtPeriodo
        {
            Id = 2,
            Nome = "Vespertino",
            Sigla = "V"
        };
        public static readonly LtPeriodo Noturno = new LtPeriodo
        {
            Id = 3,
            Nome = "Noturno",
            Sigla = "N"
        };
        
        public static List<LtPeriodo> ListarTodos()
        {
            return new List<LtPeriodo> { Matutino, Vespertino, Noturno };
        }
        
        public static LtPeriodo GetById(int id)
        {
            return ListarTodos().First(x => x.Id == id);
        }
        
        public static LtPeriodo? GetByIdOrDefault(int id)
        {
            return ListarTodos().FirstOrDefault(x => x.Id == id);
        }
        
        public static LtPeriodo GetBySigla(string sigla)
        {
            return ListarTodos().First(x => x.Sigla == sigla);
        }
        
        public static LtPeriodo? GetBySiglaOrDefault(string sigla)
        {
            return ListarTodos().FirstOrDefault(x => x.Sigla == sigla);
        }
    }
}