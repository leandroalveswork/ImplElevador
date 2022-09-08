using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ConsoleImpl.Dominio.Interfaces;
using ProvaAdmissionalCSharpApisul;

namespace ConsoleImpl.Dominio.Implementacoes
{
    public class Prompter : IPrompter
    {
        private readonly IElevadorService _elevadorService;
        public Prompter(IElevadorService elevadorService)
        {
            _elevadorService = elevadorService;
        }

        public void RodarIndefinidamente()
        {
            Console.WriteLine("Bem-vindo ao ImplElevador (v1.0)!");
            Console.WriteLine("Esse sistema tem como objetivo consumir a implementação de IElevadorService.cs, utilizando dados de um JSON.");
            Console.WriteLine("");
            while (true)
            {
                var path = Directory.GetCurrentDirectory();
                Console.WriteLine(path);
                Console.WriteLine("Digite o nome do método a ser testado:");
                var nomeMetodoDigitado = Console.ReadLine().Trim();
                ExecutarMetodo(nomeMetodoDigitado);
            }
        }

        private void ExecutarMetodo(string nomeMetodo)
        {
            Console.WriteLine("Saída:");
            if (nomeMetodo.ToLower() == "andarMenosUtilizado".ToLower())
            {
                var res = _elevadorService.andarMenosUtilizado();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "elevadorMaisFrequentado".ToLower())
            {
                var res = _elevadorService.elevadorMaisFrequentado();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "periodoMaiorFluxoElevadorMaisFrequentado".ToLower())
            {
                var res = _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "elevadorMenosFrequentado".ToLower())
            {
                var res = _elevadorService.elevadorMenosFrequentado();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "periodoMenorFluxoElevadorMenosFrequentado".ToLower())
            {
                var res = _elevadorService.periodoMenorFluxoElevadorMenosFrequentado();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "periodoMaiorUtilizacaoConjuntoElevadores".ToLower())
            {
                var res = _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
                foreach (var iRes in res)
                {
                    Console.WriteLine("-- " + iRes.ToString());
                }
                return;
            }
            if (nomeMetodo.ToLower() == "percentualDeUsoElevadorA".ToLower())
            {
                var res = _elevadorService.percentualDeUsoElevadorA();
                Console.WriteLine(res.ToString());
                return;
            }
            if (nomeMetodo.ToLower() == "percentualDeUsoElevadorB".ToLower())
            {
                var res = _elevadorService.percentualDeUsoElevadorB();
                Console.WriteLine(res.ToString());
                return;
            }
            if (nomeMetodo.ToLower() == "percentualDeUsoElevadorC".ToLower())
            {
                var res = _elevadorService.percentualDeUsoElevadorC();
                Console.WriteLine(res.ToString());
                return;
            }
            if (nomeMetodo.ToLower() == "percentualDeUsoElevadorD".ToLower())
            {
                var res = _elevadorService.percentualDeUsoElevadorD();
                Console.WriteLine(res.ToString());
                return;
            }
            if (nomeMetodo.ToLower() == "percentualDeUsoElevadorE".ToLower())
            {
                var res = _elevadorService.percentualDeUsoElevadorE();
                Console.WriteLine(res.ToString());
                return;
            }
        }
    }
}