using System;

namespace ConsoleImpl.Dominio.Uteis
{
    public static class Uteis
    {
        public static float EmDuasCasasDecimais(this double d)
        {
            var ajusteAntesDeCortar = (d * 100);
            var cortado = Math.Round(ajusteAntesDeCortar);
            var comCasasDevolvidas = cortado / 100;
            return (float)comCasasDevolvidas;
        }
    }
}