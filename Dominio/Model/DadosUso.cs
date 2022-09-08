using System.Collections.Generic;
using System.Linq;
using ConsoleImpl.Dominio.Literais;

namespace ConsoleImpl.Dominio.Model
{
    public class DadosUso<TLt>
    {
        public TLt Valor { get; set; }
        public int VezesUtilizado { get; set; }

        public static List<DadosUso<LtAndar>> UsoAndarFromListaTrafego(List<MdTrafego> listaTrafego)
        {
            var listaDados = new List<DadosUso<LtAndar>>();
            foreach (var iTrafego in listaTrafego)
            {
                var findIndex = listaDados.FindIndex(x => x.Valor.Numero == iTrafego.andar);
                if (findIndex == -1)
                {
                    listaDados.Add(new DadosUso<LtAndar>
                    {
                        Valor = LiteralAndar.GetByNumero(iTrafego.andar),
                        VezesUtilizado = 0
                    });
                    continue;
                }
                listaDados[findIndex].VezesUtilizado++;
            }
            return listaDados;
        }

        public static List<DadosUso<LtElevador>> UsoElevadorFromListaTrafego(List<MdTrafego> listaTrafego)
        {
            var listaDados = new List<DadosUso<LtElevador>>();
            foreach (var iTrafego in listaTrafego)
            {
                var findIndex = listaDados.FindIndex(x => x.Valor.Sigla == iTrafego.elevador);
                if (findIndex == -1)
                {
                    listaDados.Add(new DadosUso<LtElevador>
                    {
                        Valor = LiteralElevador.GetBySigla(iTrafego.elevador),
                        VezesUtilizado = 0
                    });
                    continue;
                }
                listaDados[findIndex].VezesUtilizado++;
            }
            return listaDados;
        }
        
        public static List<DadosUso<LtPeriodo>> FrequenciaPeriodoFromListaTrafego(List<MdTrafego> listaTrafego)
        {
            var listaDados = new List<DadosUso<LtPeriodo>>();
            foreach (var iTrafego in listaTrafego)
            {
                var findIndex = listaDados.FindIndex(x => x.Valor.Sigla == iTrafego.turno);
                if (findIndex == -1)
                {
                    listaDados.Add(new DadosUso<LtPeriodo>
                    {
                        Valor = LiteralPeriodo.GetBySigla(iTrafego.turno),
                        VezesUtilizado = 0
                    });
                    continue;
                }
                listaDados[findIndex].VezesUtilizado++;
            }
            return listaDados;
        }
    }
}