using System;
using System.IO;
using System.Text;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IStreamWriterOperator : IFunctionalityMarker
    {
        /// <summary>
        /// The <see cref="StreamWriter"/> class by default closes the underlying stream to which it writes. The <see cref="IStreamWriterOperator.New_LeaveOpen(Stream)"/> method creates a <see cref="StreamWriter"/> that will be left open.
        /// This method provides the default <see cref="StreamWriter"/> behavior, to allow library users to get in the habit of using the <see cref="IStreamWriterOperator"/> in all cases, and to make the behavior of the <see cref="StreamWriter"/> explicit.
        /// </summary>
        /// <remarks>
        /// Note: Returned writer produces no BOM.
        /// </remarks>
        public StreamWriter New_CloseAfter(Stream stream)
        {
            // This constructor produces no BOM as proven in an ExaminingCSharp experiment.
            var output = new StreamWriter(stream);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// </summary>
        /// <remarks>
        /// Note: Returned writer produces no BOM.
        /// </remarks>
        public StreamWriter New_LeaveOpen(Stream stream)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks.
            // This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, new UTF8Encoding(false), IValues.Default_StreamReaderBufferSize_Constant, true);
            return output;
        }

        /// <summary>
        /// Returns a writer that will produce initial byte-order-marks (BOM).
        /// <inheritdoc cref="New_LeaveOpen(Stream)" path="/summary"/>
        /// </summary>
        public StreamWriter New_LeaveOpen_AddByteOrderMarks(Stream stream)
        {
            // Note: using Encoding.UTF8 (inestead of UTF8Encodeing(false)) includes byte-order-marks (BOM) marks.
            // This will be a problem if writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, Encoding.UTF8, IValues.Default_StreamReaderBufferSize_Constant, true);
            return output;
        }

        /// <summary>
        /// Gets a new file stream opened for writing.
        /// </summary>
        public StreamWriter New_Write(
            string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            var stream = Instances.FileStreamOperator.Open_Write(filePath, overwrite);

            var output = this.New_CloseAfter(stream);
            return output;
        }
    }
}
