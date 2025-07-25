using System;

using R5T.T0243;


namespace R5T.L0066.V000
{
    /// <summary>
    /// Path operator test article for the functionality method instances in <see cref="IPathOperator"/>.
    /// </summary>
    [TestArticleImplementationMarker]
    public class PathOperatorTestArticle : ITestArticleImplementationMarker,
        V0002.IPathOperatorTestArticle
    {
        public string Combine_ToFilePath(string[] pathParts)
        {
            var output = Instances.PathOperator.Combine_ToFilePath(pathParts);
            return output;
        }

        public bool Is_FileIndicated(string path)
        {
            var output = Instances.PathOperator.Is_FileIndicated(path);
            return output;
        }

        public bool Is_Windows(string path)
        {
            var output = Instances.PathOperator.Is_Windows(path);
            return output;
        }
    }
}
