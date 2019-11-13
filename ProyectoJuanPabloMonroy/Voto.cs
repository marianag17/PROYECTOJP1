using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoJuanPabloMonroy
{
    class Voto
    {
        string presidente;
        string alcalde;
        string diputadoNac;
        string diputadoDist;

        public Voto()
        {

        }

        public string Presidente { get => presidente; set => presidente = value; }
        public string Alcalde { get => alcalde; set => alcalde = value; }
        public string DiputadoNac { get => diputadoNac; set => diputadoNac = value; }
        public string DiputadoDist { get => diputadoDist; set => diputadoDist = value; }
    }
}
