using System;


namespace R5T.L0066
{
    public class DictionaryOperator : IDictionaryOperator
    {
        #region Infrastructure

        public static IDictionaryOperator Instance { get; } = new DictionaryOperator();


        private DictionaryOperator()
        {
        }

        #endregion
    }
}
