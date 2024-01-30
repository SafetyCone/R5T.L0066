using System;


namespace R5T.L0066
{
    public class DocumentationFileNameOperator : IDocumentationFileNameOperator
    {
        #region Infrastructure

        public static IDocumentationFileNameOperator Instance { get; } = new DocumentationFileNameOperator();


        private DocumentationFileNameOperator()
        {
        }

        #endregion
    }
}
