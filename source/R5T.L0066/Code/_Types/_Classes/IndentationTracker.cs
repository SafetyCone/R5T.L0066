using System;

using R5T.T0142;

using Instances = R5T.L0066.Instances;


namespace R5T.N0000
{
    /// <summary>
    /// Allows tracking indentation, which is useful during serialization.
    /// </summary>
    [UtilityTypeMarker]
    public class IndentationTracker
    {
        public IndentationLevelTracker Level { get; } = new IndentationLevelTracker();

        /// <summary>
        /// The unit of indentation (examples: tab, or 4 spaces, or 2 spaces).
        /// </summary>
        public string IndentationUnit { get; set; }


        public string Get_Indentation()
        {
            var output = Instances.StringOperator.Repeat(
                this.IndentationUnit,
                this.Level.IndentationLevel);

            return output;
        }

        /// <summary>
        /// Resets the indentation level to zero.
        /// </summary>
        public void Reset()
        {
            this.Level.Reset();
        }

        /// <summary>
        /// Add one (1) to the indentation level.
        /// </summary>
        public void Increase()
        {
            this.Level.Increase();
        }

        /// <summary>
        /// Subtracts one (1) from the indentation level.
        /// </summary>
        public void Decrease()
        {
            this.Level.Decrease();
        }

        public void Indent(Action action)
        {
            this.Increase();

            action();

            this.Decrease();
        }
    }
}
