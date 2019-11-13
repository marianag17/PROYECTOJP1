using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoJuanPabloMonroy
{
    class Partido
    {
        string colorPartido;
        int votosPresidente;
        int votosAlcalde;
        int votosDiputadoNac;
        int votosDiputadoDistrital;
        double curulesNac;
        double curulesDist;
        double diputadosTotales;
        double porcentajeGrafica;

        public Partido()
        {

        }

        public int VotosPresidente { get => votosPresidente; set => votosPresidente = value; }
        public int VotosAlcalde { get => votosAlcalde; set => votosAlcalde = value; }
        public int VotosDiputadoNac { get => votosDiputadoNac; set => votosDiputadoNac = value; }
        public int VotosDiputadoDistrital { get => votosDiputadoDistrital; set => votosDiputadoDistrital = value; }
        public string ColorPartido { get => colorPartido; set => colorPartido = value; }
        public double CurulesNac { get => curulesNac; set => curulesNac = value; }
        public double CurulesDist { get => curulesDist; set => curulesDist = value; }
        public double DiputadosTotales { get => diputadosTotales; set => diputadosTotales = value; }
        public double PorcentajeGrafica { get => porcentajeGrafica; set => porcentajeGrafica = value; }
    }
}
