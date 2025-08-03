using System.Text;

namespace MiniCompilador
{
    public partial class MiniCompilador : Form
    {
        public MiniCompilador()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            // Agrupar bloques por llaves
            List<string> bloques = new();
            StringBuilder bloqueActual = new();
            int contadorLlaves = 0;

            foreach (var linea in txtCodigo.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var trim = linea.Trim();
                if (string.IsNullOrWhiteSpace(trim)) continue;

                bloqueActual.AppendLine(trim);
                contadorLlaves += trim.Count(c => c == '{');
                contadorLlaves -= trim.Count(c => c == '}');

                if (contadorLlaves == 0)
                {
                    bloques.Add(bloqueActual.ToString().Trim());
                    bloqueActual.Clear();
                }
            }

            // Limpiar resultados anteriores
            grdLexico.Rows.Clear();
            grdSintactico.Rows.Clear();
            dgTablaSimbolos.Rows.Clear();
            dgSemantico.Rows.Clear();

            var tablaSimbolos = new List<Simbolo>();

            foreach (var bloque in bloques)
            {
                var lexer = new Lexer(bloque);
                var tokens = lexer.Analizar();

                // Mostrar análisis léxico
                foreach (var t in tokens)
                    grdLexico.Rows.Add(t.Tipo, t.Valor);

                var parser = new Parser(tokens);
                var resultadoSintactico = parser.Analizar();

                grdSintactico.Rows.Add(resultadoSintactico);

                if (resultadoSintactico == "Sintaxis correcta.")
                {
                    var semantic = new SemanticAnalyzer(tokens, tablaSimbolos);
                    semantic.Analizar();

                    if (semantic.Mensajes.Count == 0)
                    {
                        dgSemantico.Rows.Add(new object[] { "Semántica válida." });
                    }
                    else
                    {
                        foreach (var mensaje in semantic.Mensajes)
                            dgSemantico.Rows.Add(new object[] { mensaje });
                    }
                }
                else
                {
                    dgSemantico.Rows.Add(new object[] { "No analizado por error de sintaxis." });
                }

                // Registrar en tabla de símbolos si es declaración válida
                if (tokens.Count >= 5 &&
                    tokens[0].Tipo == "TIPO_DATO" &&
                    tokens[1].Tipo == "IDENTIFICADOR" &&
                    tokens[2].Tipo == "ASIGNACION")
                {
                    var tipo = tokens[0].Valor;
                    var nombre = tokens[1].Valor;
                    var expresionTokens = tokens.Skip(3).TakeWhile(t => t.Tipo != "PUNTOYCOMA").ToList();
                    var valor = string.Join(" ", expresionTokens.Select(t => t.Valor));

                    tablaSimbolos.Add(new Simbolo(nombre, tipo, valor));
                }
            }

            // Mostrar tabla de símbolos
            foreach (var sim in tablaSimbolos)
                dgTablaSimbolos.Rows.Add(sim.Nombre, sim.Tipo, sim.Valor);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtResultado.Clear();
            grdLexico.Rows.Clear();
            dgSemantico.Rows.Clear();
            grdSintactico.Rows.Clear();
            dgTablaSimbolos.Rows.Clear();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // Agrupar bloques (manejar llaves { } para bloques múltiples)
            List<string> bloques = new();
            StringBuilder bloqueActual = new();
            int contadorLlaves = 0;

            foreach (var linea in txtCodigo.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var trim = linea.Trim();
                if (string.IsNullOrWhiteSpace(trim)) continue;

                bloqueActual.AppendLine(trim);

                contadorLlaves += trim.Count(c => c == '{');
                contadorLlaves -= trim.Count(c => c == '}');

                if (contadorLlaves == 0)
                {
                    bloques.Add(bloqueActual.ToString().Trim());
                    bloqueActual.Clear();
                }
            }
            var cuerpoCpp = new StringBuilder();

            foreach (var bloque in bloques)
            {
                var lexer = new Lexer(bloque);
                var tokens = lexer.Analizar();

                // Declaraciones tipo: int x = 5;
                if (tokens.Count >= 5 &&
                    tokens[0].Tipo == "TIPO_DATO" &&
                    tokens[1].Tipo == "IDENTIFICADOR" &&
                    tokens[2].Tipo == "ASIGNACION")
                {
                    string tipoC = tokens[0].Valor switch
                    {
                        "int" => "int",
                        "float" => "float",
                        "string" => "string",
                        "bool" => "bool",
                        _ => tokens[0].Valor
                    };

                    string nombre = tokens[1].Valor;
                    var expresionTokens = tokens.Skip(3).TakeWhile(t => t.Tipo != "PUNTOYCOMA");
                    string expresion = string.Join(" ", expresionTokens.Select(t => t.Valor));

                    cuerpoCpp.AppendLine($"    {tipoC} {nombre} = {expresion};");
                }
                // print(...)
                else if (tokens.Count >= 4 &&
                         tokens[0].Tipo == "IMPRIMIR" &&
                         tokens[1].Tipo == "PAR_ABRE")
                {
                    var contenido = tokens.Skip(2).TakeWhile(t => t.Tipo != "PAR_CIERRA").Select(t => t.Valor);
                    string texto = string.Join(" ", contenido);
                    cuerpoCpp.AppendLine($"    cout << {texto} << endl;");
                }
                // if (...)
                else if (tokens[0].Tipo == "IF")
                {
                    var condicion = string.Join(" ", tokens.Skip(2).TakeWhile(t => t.Tipo != "PAR_CIERRA").Select(t => t.Valor));
                    cuerpoCpp.AppendLine($"    if ({condicion}) {{");
                }
                // else {
                else if (tokens[0].Tipo == "ELSE" && tokens.Any(t => t.Tipo == "LLAVE_ABRE"))
                {
                    cuerpoCpp.AppendLine("    else {");
                }
                // cierre de bloque
                else if (tokens.Count == 1 && tokens[0].Tipo == "LLAVE_CIERRA")
                {
                    cuerpoCpp.AppendLine("    }");
                }
            }

            string codigoFinal = "#include <iostream>\r\n" +
                      "#include <string>\r\n" +
                      "using namespace std;\r\n\r\n" +
                      "int main() {\r\n" +
                      cuerpoCpp.ToString() +
                      "    return 0;\r\n" +
                      "}";

            txtResultado.Text = codigoFinal;
        }
    }
}
