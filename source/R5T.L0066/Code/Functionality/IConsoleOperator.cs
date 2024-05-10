using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IConsoleOperator : IFunctionalityMarker
    {
        public void Write(char character)
            => Console.Write(character);

        public void Write_Line()
            => Console.WriteLine();

        public void Write_Line(string line)
            => Console.WriteLine(line);

        public void Write_Line_WithTrailingBlankLink(string line)
        {
            this.Write_Line(line);
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
