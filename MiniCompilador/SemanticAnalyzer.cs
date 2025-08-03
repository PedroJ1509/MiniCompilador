using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCompilador
{
    public class SemanticAnalyzer
    {
        private List<Token> tokens;
        private List<Simbolo> tablaSimbolos;

        public List<string> Mensajes { get; private set; } = new();

        public SemanticAnalyzer(List<Token> tokens, List<Simbolo> tablaSimbolos)
        {
            this.tokens = tokens;
            this.tablaSimbolos = tablaSimbolos;
        }

        public void Analizar()
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (token.Tipo == "IDENTIFICADOR")
                {
                    if (i > 0 && tokens[i - 1].Tipo != "TIPO_DATO")
                    {
                        var simbolo = tablaSimbolos.FirstOrDefault(s => s.Nombre == token.Valor);
                        if (simbolo == null)
                        {
                            Mensajes.Add($"Error: Variable '{token.Valor}' no declarada.");
                        }
                    }
                }
                else if (token.Tipo == "TIPO_DATO")
                {
                    if (i + 1 < tokens.Count && tokens[i + 1].Tipo == "IDENTIFICADOR")
                    {
                        string tipo = token.Valor;
                        string nombre = tokens[i + 1].Valor;
                        string valor = "";

                        if (i + 3 < tokens.Count && tokens[i + 2].Tipo == "ASIGNACION")
                        {
                            var valToken = tokens[i + 3];
                            valor = valToken.Valor;

                            if (tipo == "int" && !int.TryParse(valor, out _))
                                Mensajes.Add($"Error: Valor '{valor}' no es un entero válido para '{nombre}'.");
                            else if (tipo == "float" && !float.TryParse(valor, out _))
                                Mensajes.Add($"Error: Valor '{valor}' no es un float válido para '{nombre}'.");
                            else if (tipo == "bool" && valor != "true" && valor != "false")
                                Mensajes.Add($"Error: Valor '{valor}' no es booleano válido para '{nombre}'.");
                            else if (tipo == "string" && !(valor.StartsWith("\"") && valor.EndsWith("\"")))
                                Mensajes.Add($"Error: Valor '{valor}' no es una cadena válida para '{nombre}'.");
                        }

                        tablaSimbolos.Add(new Simbolo(nombre, tipo, valor));
                    }
                    else
                    {
                        Mensajes.Add("Error: Se esperaba un nombre de variable después del tipo de dato.");
                    }
                }
            }
        }
    }
}
