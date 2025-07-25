using System;
using System.Collections.Generic;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConsoleOperator : IFunctionalityMarker,
        F10Y.L0000.IConsoleOperator
    {
        public TextWriter Get_OutputWriter()
            => Console.Out;

        public void Write_Line_WithTrailingBlankLine(string line)
        {
            this.Write_Line(line);
            this.Write_Line();
        }

        public void Write_Lines_WithTrailingBlankLine<T>(IEnumerable<T> values)
        {
            this.Write_Lines(values);

            this.Write_Line();
        }

        /// <summary>
        /// Chooses <see cref="Write_Line_IndentedByTab(string)"/> as the default.
        /// </summary>
        public void Write_Line_Indented(string line)
            => this.Write_Line_IndentedByTab(line);

        public void Write_Line_IndentedByTab(string line)
        {
            this.Write(Instances.Characters.Tab);
            this.Write_Line(line);
        }
    }
}
