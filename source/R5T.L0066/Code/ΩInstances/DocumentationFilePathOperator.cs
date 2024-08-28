using System;


namespace R5T.L0066
{
    public class DocumentationFilePathOperator : IDocumentationFilePathOperator
    {
        #region Infrastructure

        public static IDocumentationFilePathOperator Instance { get; } = new DocumentationFilePathOperator();


        private DocumentationFilePathOperator()
        {
        }

        #endregion
    }
}
