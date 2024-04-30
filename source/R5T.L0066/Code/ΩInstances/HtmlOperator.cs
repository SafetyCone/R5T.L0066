using System;


namespace R5T.L0066
{
    public class HtmlOperator : IHtmlOperator
    {
        #region Infrastructure

        public static IHtmlOperator Instance { get; } = new HtmlOperator();


        private HtmlOperator()
        {
        }

        #endregion
    }
}
