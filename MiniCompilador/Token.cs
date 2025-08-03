using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCompilador
{
    public class Token
    {
        public string Tipo { get; set; }
        public string Valor { get; set; }

        public Token(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
}
