using ConsoleImpl.Dominio.Implementacoes;
using ConsoleImpl.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ProvaAdmissionalCSharpApisul;

namespace ConsoleImpl.CrossCut
{
    public static class InversaoDeControle
    {
        public static IServiceCollection ImplementarElevador(this IServiceCollection servicos)
        {
            servicos.AddSingleton<IElevadorService, ElevadorService>();
            servicos.AddSingleton<IPrompter, Prompter>();
            return servicos;
        }
    }
}