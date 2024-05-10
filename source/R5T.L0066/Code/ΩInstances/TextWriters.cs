using System;


namespace R5T.L0066
{
    public class TextWriters : ITextWriters
    {
        #region Infrastructure

        public static ITextWriters Instance { get; } = new TextWriters();


        private TextWriters()
        {
        }

        #endregion
    }
}
