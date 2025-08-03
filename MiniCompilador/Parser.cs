using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCompilador
{
    public class Parser
    {
        private List<Token> tokens;
        private int posicion;
        public StringBuilder CodigoCpp { get; private set; } = new();

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            this.posicion = 0;
        }

        public string Analizar()
        {
            CodigoCpp.Clear();
            CodigoCpp.AppendLine("#include <iostream>\n#include <string>\nusing namespace std;\n\nint main() {");

            while (posicion < tokens.Count)
            {
                if (EsDeclaracionVariable()) continue;
                else if (EsImprimir()) continue;
                else if (EsIfElse()) continue;
                else
                    return "Error: Expresión inválida.";
            }

            CodigoCpp.AppendLine("    return 0;\n}");
            return "Sintaxis correcta.";
        }

        private bool EsDeclaracionVariable()
        {
            if (posicion + 4 <= tokens.Count && tokens[posicion].Tipo == "TIPO_DATO")
            {
                var tipo = tokens[posicion++].Valor;
                if (tokens[posicion].Tipo == "IDENTIFICADOR")
                {
                    var nombre = tokens[posicion++].Valor;
                    if (tokens[posicion].Tipo == "ASIGNACION")
                    {
                        posicion++;
                        var valor = "";
                        while (posicion < tokens.Count && tokens[posicion].Tipo != "PUNTOYCOMA")
                        {
                            valor += tokens[posicion++].Valor + " ";
                        }
                        if (tokens[posicion].Tipo == "PUNTOYCOMA")
                        {
                            posicion++;
                            CodigoCpp.AppendLine($"    {tipo} {nombre} = {valor.Trim()};");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool EsImprimir()
        {
            if (posicion < tokens.Count && tokens[posicion].Tipo == "IMPRIMIR")
            {
                posicion++;
                if (tokens[posicion].Tipo == "PAR_ABRE")
                {
                    posicion++;
                    var contenido = "";
                    while (posicion < tokens.Count && tokens[posicion].Tipo != "PAR_CIERRA")
                    {
                        contenido += tokens[posicion++].Valor + " ";
                    }
                    if (tokens[posicion].Tipo == "PAR_CIERRA")
                    {
                        posicion++;
                        if (tokens[posicion].Tipo == "PUNTOYCOMA")
                        {
                            posicion++;
                            CodigoCpp.AppendLine($"    cout << {contenido.Trim()} << endl;");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool EsIfElse()
        {
            if (posicion < tokens.Count && tokens[posicion].Tipo == "IF")
            {
                posicion++;
                if (tokens[posicion].Tipo == "PAR_ABRE")
                {
                    posicion++;
                    var condicion = "";
                    while (posicion < tokens.Count && tokens[posicion].Tipo != "PAR_CIERRA")
                    {
                        condicion += tokens[posicion++].Valor + " ";
                    }
                    if (tokens[posicion].Tipo == "PAR_CIERRA")
                    {
                        posicion++;
                        if (tokens[posicion].Tipo == "LLAVE_ABRE")
                        {
                            posicion++;
                            CodigoCpp.AppendLine($"    if ({condicion.Trim()}) {{");

                            while (tokens[posicion].Tipo != "LLAVE_CIERRA")
                            {
                                if (!EsImprimir() && !EsDeclaracionVariable())
                                    return false;
                            }

                            posicion++; // cerrar llave
                            CodigoCpp.AppendLine("    }");

                            if (posicion < tokens.Count && tokens[posicion].Tipo == "ELSE")
                            {
                                posicion++;
                                if (tokens[posicion].Tipo == "LLAVE_ABRE")
                                {
                                    posicion++;
                                    CodigoCpp.AppendLine("    else {");

                                    while (tokens[posicion].Tipo != "LLAVE_CIERRA")
                                    {
                                        if (!EsImprimir() && !EsDeclaracionVariable())
                                            return false;
                                    }

                                    posicion++;
                                    CodigoCpp.AppendLine("    }");
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
