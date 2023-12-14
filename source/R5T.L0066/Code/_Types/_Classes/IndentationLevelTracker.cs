using System;

using R5T.T0142;


namespace R5T.N0000
{
    /// <summary>
    /// Allows tracking indentation level, which is useful during serialization.
    /// </summary>
    [UtilityTypeMarker]
    public class IndentationLevelTracker
    {
        public int IndentationLevel { get; set; }


        /// <summary>
        /// Resets the indentation level to zero.
        /// </summary>
        public void Reset()
        {
            this.IndentationLevel = 0;
        }

        /// <summary>
        /// Add one (1) to the indentation level.
        /// </summary>
        public void Increase()
        {
            this.IndentationLevel++;
        }

        /// <summary>
        /// Subtracts one (1) from the indentation level.
        /// </summary>
        public void Decrease()
        {
            this.IndentationLevel--;
        }
    }
}
