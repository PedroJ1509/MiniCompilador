# Mini Compilador Visual en C# para la materia de Compiladores.

Este proyecto es un **Mini Compilador** desarrollado con **Windows Forms en C#**, diseñado para analizar y traducir un subconjunto de código fuente a C++. El sistema incluye análisis **léxico**, **sintáctico**, **semántico** y una etapa de **generación de código intermedio en C++**.

## Características

- ✅ Análisis Léxico con reconocimiento de:
  - Identificadores
  - Tipos de datos (`int`, `float`, `string`, `bool`)
  - Operadores (`+`, `-`, `*`, `/`, `==`, `!=`, `>`, `<`, `=`)
  - Palabras reservadas (`if`, `else`, `print`, `true`, `false`)
  - Literales numéricos y cadenas

- ✅ Análisis Sintáctico:
  - Validación de estructuras como declaraciones, expresiones, bloques condicionales (`if/else`) y llamadas a `print`.

- ✅ Análisis Semántico:
  - Validación de tipos (`int`, `float`, `string`, `bool`)
  - Verificación de variables no declaradas
  - Compatibilidad de asignación con tipos

- ✅ Generación de Código Intermedio:
  - Traducción de instrucciones válidas a código C++ funcional.
  - Soporte para `if/else` y `print()` convertidos a `cout`.

## Estructura del Proyecto

- `Lexer.cs`: Realiza el análisis léxico y tokeniza el código fuente.
- `Parser.cs`: Analiza la sintaxis de los tokens.
- `SemanticAnalyzer.cs`: Verifica la semántica del código.
- `Simbolo.cs`: Representa la tabla de símbolos.
- `Token.cs`: Representa los tokens identificados por el lexer.
- `Form1.cs`: Interfaz gráfica y lógica principal para cargar, analizar y mostrar resultados.
- `Resultado`: Se muestra el código generado en C++ listo para compilar.

## Autor

- Pedro J. De la Rosa / 1-03-3398
