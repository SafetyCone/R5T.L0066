using System;
using System.Xml;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IXmlFileOperator : IFunctionalityMarker
    {
        /// <summary>
		/// Examines file context to determine if a file is an XML file.
		/// </summary>
		/// <remarks>
		/// This implementation is very inefficient: it simply checks if the XML file can be loaded, and if not, catches the exception and returns that file is not XML.
		/// TODO: write a better examiner.
		/// </remarks>
		public bool IsXmlFile(string possibleXmlFilePath)
        {
            var isXmlFile = true;

            try
            {
                // Ignore the output XDocument.
                Instances.XmlOperator.Load_Synchronous(possibleXmlFilePath);
            }
            // Only catch XML exceptions.
            catch (XmlException)
            {
                isXmlFile = false;
            }

            return isXmlFile;
        }
    }
}
