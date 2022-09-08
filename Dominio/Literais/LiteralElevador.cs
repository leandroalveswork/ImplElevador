using System.Collections.Generic;
using System.Linq;

namespace ConsoleImpl.Dominio.Literais
{
    public class LiteralElevador
    {
        public static readonly LtElevador A = new LtElevador
        {
            Id = 1,
            Sigla = "A"
        };
        public static readonly LtElevador B = new LtElevador
        {
            Id = 2,
            Sigla = "B"
        };
        public static readonly LtElevador C = new LtElevador
        {
            Id = 3,
            Sigla = "C"
        };
        public static readonly LtElevador D = new LtElevador
        {
            Id = 4,
            Sigla = "D"
        };
        public static readonly LtElevador E = new LtElevador
        {
            Id = 5,
            Sigla = "E"
        };
        
        public static List<LtElevador> ListarTodos()
        {
            return new List<LtElevador> { A, B, C, D, E };
        }
        
        public static LtElevador GetById(int id)
        {
            return ListarTodos().First(x => x.Id == id);
        }
        
        public static LtElevador? GetByIdOrDefault(int id)
        {
            return ListarTodos().FirstOrDefault(x => x.Id == id);
        }
        
        public static LtElevador GetBySigla(string sigla)
        {
            return ListarTodos().First(x => x.Sigla == sigla);
        }
        
        public static LtElevador? GetBySiglaOrDefault(string sigla)
        {
            return ListarTodos().FirstOrDefault(x => x.Sigla == sigla);
        }
    }
}