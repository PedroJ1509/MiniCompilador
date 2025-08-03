using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCompilador
{
    public class Simbolo
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }

        public Simbolo(string nombre, string tipo, string valor)
        {
            Nombre = nombre;
            Tipo = tipo;
            Valor = valor;
        }
    }
}
