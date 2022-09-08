using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleImpl.Dominio.Interfaces;
using ConsoleImpl.Dominio.Literais;
using ConsoleImpl.Dominio.Model;
using ConsoleImpl.Dominio.Uteis;
using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul;

namespace ConsoleImpl.Dominio.Implementacoes
{
    public class ElevadorService : IElevadorService
    {
        private List<MdTrafego>? _trafegosImportados = null;

        private void ImportarTrafegos()
        {
            var caminhoCompleto = Directory.GetCurrentDirectory() + "\\input.json";
            if (caminhoCompleto.Contains("\\bin\\Debug"))
            {
                caminhoCompleto = caminhoCompleto.Split("\\bin\\Debug")[0] + "\\input.json";
            }
            var trafegosAsString = File.ReadLines(caminhoCompleto).Aggregate((prev, cur) => prev + cur);
            _trafegosImportados = JsonConvert.DeserializeObject<List<MdTrafego>>(trafegosAsString);
        }

        public List<int> andarMenosUtilizado()
        {
            ImportarTrafegos();
            var listaDadosUso = DadosUso<LtAndar>.UsoAndarFromListaTrafego(_trafegosImportados)
                .OrderBy(x => x.VezesUtilizado);
            var andaresInt = new List<int>();
            foreach (var iDadosUso in listaDadosUso)
            {
                if (!andaresInt.Any()) 
                {
                    andaresInt.Add(iDadosUso.Valor.Numero);
                    continue;
                }  
                if (iDadosUso.VezesUtilizado > listaDadosUso.First().VezesUtilizado)
                {
                    break;
                }
                andaresInt.Add(iDadosUso.Valor.Numero);
            }
            return andaresInt;
        }

        public List<char> elevadorMaisFrequentado()
        {
            ImportarTrafegos();
            var listaDadosUso = DadosUso<LtElevador>.UsoElevadorFromListaTrafego(_trafegosImportados)
                .OrderByDescending(x => x.VezesUtilizado);
            var elevadoresChar = new List<char>();
            foreach (var iDadosUso in listaDadosUso)
            {
                if (!elevadoresChar.Any()) 
                {
                    elevadoresChar.Add(iDadosUso.Valor.Sigla[0]);
                    continue;
                }  
                if (iDadosUso.VezesUtilizado < listaDadosUso.First().VezesUtilizado)
                {
                    break;
                }
                elevadoresChar.Add(iDadosUso.Valor.Sigla[0]);
            }
            return elevadoresChar;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            ImportarTrafegos();
            var elevadoresMaisFrequentados = elevadorMaisFrequentado();
            var periodosChar = new List<char>();
            foreach (var iElevador in elevadoresMaisFrequentados)
            {
                var trafegosDoElevador = _trafegosImportados.Where(x => x.elevador[0] == iElevador).ToList();
                var periodoMaisFrequente = DadosUso<LtPeriodo>.FrequenciaPeriodoFromListaTrafego(trafegosDoElevador)
                    .OrderByDescending(x => x.VezesUtilizado).First().Valor;
                periodosChar.Add(periodoMaisFrequente.Sigla[0]);
            }
            return periodosChar;
        }

        public List<char> elevadorMenosFrequentado()
        {
            ImportarTrafegos();
            var listaDadosUso = DadosUso<LtElevador>.UsoElevadorFromListaTrafego(_trafegosImportados)
                .OrderBy(x => x.VezesUtilizado);
            var elevadoresChar = new List<char>();
            foreach (var iDadosUso in listaDadosUso)
            {
                if (!elevadoresChar.Any()) 
                {
                    elevadoresChar.Add(iDadosUso.Valor.Sigla[0]);
                    continue;
                }  
                if (iDadosUso.VezesUtilizado > listaDadosUso.First().VezesUtilizado)
                {
                    break;
                }
                elevadoresChar.Add(iDadosUso.Valor.Sigla[0]);
            }
            return elevadoresChar;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            ImportarTrafegos();
            var elevadoresMenosFrequentados = elevadorMenosFrequentado();
            var periodosChar = new List<char>();
            foreach (var iElevador in elevadoresMenosFrequentados)
            {
                var trafegosDoElevador = _trafegosImportados.Where(x => x.elevador[0] == iElevador).ToList();
                var periodoMenosFrequente = DadosUso<LtPeriodo>.FrequenciaPeriodoFromListaTrafego(trafegosDoElevador)
                    .OrderBy(x => x.VezesUtilizado).First().Valor;
                periodosChar.Add(periodoMenosFrequente.Sigla[0]);
            }
            return periodosChar;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            ImportarTrafegos();
            var listaDadosUso = DadosUso<LtPeriodo>.FrequenciaPeriodoFromListaTrafego(_trafegosImportados)
                .OrderByDescending(x => x.VezesUtilizado);
            var periodosChar = new List<char>();
            foreach (var iDadosUso in listaDadosUso)
            {
                if (!periodosChar.Any())
                {
                    periodosChar.Add(iDadosUso.Valor.Sigla[0]);
                    continue;
                }  
                if (iDadosUso.VezesUtilizado < listaDadosUso.First().VezesUtilizado)
                {
                    break;
                }
                periodosChar.Add(iDadosUso.Valor.Sigla[0]);
            }
            return periodosChar;
        }

        public float percentualDeUsoElevadorA()
        {
            ImportarTrafegos();
            var totalUsado = _trafegosImportados.Count(x => x.elevador == LiteralElevador.A.Sigla);
            return (totalUsado * 100.0 / _trafegosImportados.Count).EmDuasCasasDecimais();
        }

        public float percentualDeUsoElevadorB()
        {
            ImportarTrafegos();
            var totalUsado = _trafegosImportados.Count(x => x.elevador == LiteralElevador.B.Sigla);
            return (totalUsado * 100.0 / _trafegosImportados.Count).EmDuasCasasDecimais();
        }

        public float percentualDeUsoElevadorC()
        {
            ImportarTrafegos();
            var totalUsado = _trafegosImportados.Count(x => x.elevador == LiteralElevador.C.Sigla);
            return (totalUsado * 100.0 / _trafegosImportados.Count).EmDuasCasasDecimais();
        }

        public float percentualDeUsoElevadorD()
        {
            ImportarTrafegos();
            var totalUsado = _trafegosImportados.Count(x => x.elevador == LiteralElevador.D.Sigla);
            return (totalUsado * 100.0 / _trafegosImportados.Count).EmDuasCasasDecimais();
        }

        public float percentualDeUsoElevadorE()
        {
            ImportarTrafegos();
            var totalUsado = _trafegosImportados.Count(x => x.elevador == LiteralElevador.E.Sigla);
            return (totalUsado * 100.0 / _trafegosImportados.Count).EmDuasCasasDecimais();
        }
    }
}