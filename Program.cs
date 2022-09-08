using System;
using ConsoleImpl.CrossCut;
using ConsoleImpl.Dominio.Implementacoes;
using ConsoleImpl.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ProvaAdmissionalCSharpApisul;

namespace ConsoleImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.ImplementarElevador();
            var serviceProvider = services.BuildServiceProvider();
            var prompter = serviceProvider.GetService<IPrompter>();
            prompter.RodarIndefinidamente();
        }
    }
}
