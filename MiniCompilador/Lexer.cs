using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniCompilador
{
    public class Lexer
    {
        private string _codigo;

        private static readonly Dictionary<string, string> palabrasReservadas = new()
        {
            { "int", "TIPO_DATO" },
            { "float", "TIPO_DATO" },
            { "string", "TIPO_DATO" },
            { "bool", "TIPO_DATO" },
            { "print", "IMPRIMIR" },
            { "true", "BOOLEANO" },
            { "false", "BOOLEANO" },
            { "if", "IF" },
            { "else", "ELSE" }
        };

        public Lexer(string codigo)
        {
            _codigo = codigo;
        }

        public List<Token> Analizar()
        {
            var tokens = new List<Token>();

            var patron = @"(?<CADENA>\""[^\""]*\"")" +
                         @"|(?<ID>[a-zA-Z_]\w*)" +
                         @"|(?<NUM>\d+(\.\d+)?)" +
                         @"|(?<IGUAL>==)" +
                         @"|(?<DIFERENTE>!=)" +
                         @"|(?<ASIG>=)" +
                         @"|(?<MAYOR>>)" +
                         @"|(?<MENOR><)" +
                         @"|(?<MAS>\+)" +
                         @"|(?<MENOS>-)" +
                         @"|(?<MULT>\*)" +
                         @"|(?<DIV>/)" +
                         @"|(?<PYC>;)" +
                         @"|(?<PARA>\()" +
                         @"|(?<PARC>\))" +
                         @"|(?<LLAVEA>{)" +
                         @"|(?<LLAVEC>})" +
                         @"|(?<WS>\s+)";

            var regex = new Regex(patron);

            foreach (Match match in regex.Matches(_codigo))
            {
                if (match.Groups["WS"].Success) continue;

                if (match.Groups["CADENA"].Success)
                    tokens.Add(new Token("CADENA", match.Groups["CADENA"].Value));
                else if (match.Groups["ID"].Success)
                {
                    var val = match.Groups["ID"].Value;
                    if (palabrasReservadas.ContainsKey(val))
                        tokens.Add(new Token(palabrasReservadas[val], val));
                    else
                        tokens.Add(new Token("IDENTIFICADOR", val));
                }
                else if (match.Groups["NUM"].Success)
                    tokens.Add(new Token("NUMERO", match.Groups["NUM"].Value));
                else if (match.Groups["IGUAL"].Success)
                    tokens.Add(new Token("IGUALDAD", "=="));
                else if (match.Groups["DIFERENTE"].Success)
                    tokens.Add(new Token("DIFERENTE", "!="));
                else if (match.Groups["ASIG"].Success)
                    tokens.Add(new Token("ASIGNACION", "="));
                else if (match.Groups["MAYOR"].Success)
                    tokens.Add(new Token("MAYOR", ">"));
                else if (match.Groups["MENOR"].Success)
                    tokens.Add(new Token("MENOR", "<"));
                else if (match.Groups["MAS"].Success)
                    tokens.Add(new Token("SUMA", "+"));
                else if (match.Groups["MENOS"].Success)
                    tokens.Add(new Token("RESTA", "-"));
                else if (match.Groups["MULT"].Success)
                    tokens.Add(new Token("MULTIPLICACION", "*"));
                else if (match.Groups["DIV"].Success)
                    tokens.Add(new Token("DIVISION", "/"));
                else if (match.Groups["PYC"].Success)
                    tokens.Add(new Token("PUNTOYCOMA", ";"));
                else if (match.Groups["PARA"].Success)
                    tokens.Add(new Token("PAR_ABRE", "("));
                else if (match.Groups["PARC"].Success)
                    tokens.Add(new Token("PAR_CIERRA", ")"));
                else if (match.Groups["LLAVEA"].Success)
                    tokens.Add(new Token("LLAVE_ABRE", "{"));
                else if (match.Groups["LLAVEC"].Success)
                    tokens.Add(new Token("LLAVE_CIERRA", "}"));
            }

            return tokens;
        }
    }
}
