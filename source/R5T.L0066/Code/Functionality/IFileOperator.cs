using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileOperator : IFunctionalityMarker
    {
        /// <summary>
		/// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank lines, instead adding the new line character to the previous line!
		/// </summary>
		public async Task<string[]> ActuallyReadAllLines(string filePath)
        {
            var text = await File.ReadAllTextAsync(filePath);

            var lines = this.GetLinesFromText(text);
            return lines;
        }

        /// <inheritdoc cref="ActuallyReadAllLines(string)"/>
        public string[] ActuallyReadAllLines_Synchronous(string filePath)
        {
            var text = File.ReadAllText(filePath);

            var lines = this.GetLinesFromText(text);
            return lines;
        }

        public string[] GetLinesFromText(string text)
        {
            if (Instances.StringOperator.Is_Empty(text))
            {
                return Array.Empty<string>();
            }

            var lines = text.Split(
                new[]
                {
                    Strings.Instance.NewLine_NonWindows,
                    Strings.Instance.NewLine_Windows,
                },
                StringSplitOptions.None);

            return lines;
        }

        /// <summary>
        /// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
        /// </summary>
        public async Task<string[]> ReadAllLines(string filePath)
        {
            var lines = await this.ActuallyReadAllLines(filePath);
            return lines;
        }

        /// <inheritdoc cref="ReadAllLines(string)"/>
        public string[] ReadAllLines_Synchronous(string filePath)
        {
            var lines = this.ActuallyReadAllLines_Synchronous(filePath);
            return lines;
        }

        public FileAttributes Get_FileAttributes(string filePath)
        {
            var output = File.GetAttributes(filePath);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Open_ForWrite(string, bool)"/>.
        /// </summary>
        public TextWriter Get_Writer(
            string filePath,
            bool overwrite = IValues.Default_OverwriteValue_Constant)
        {
            var output = this.Open_ForWrite(
                filePath,
                overwrite);

            return output;
        }

        public bool Has_ByteOrderMark(
            string filePath)
        {
            var bytes = this.Read_Bytes_Synchronous(filePath);

            var byteOrderMark = Instances.Values.ByteOrderMark;

            var hasByteOrderMark = Instances.EnumerableOperator.StartsWith(
                bytes,
                byteOrderMark);

            return hasByteOrderMark;
        }

        public void In_WriterContext_Synchronous(
            string filePath,
            Action<TextWriter> action)
        {
            using var writer = Instances.StreamWriterOperator.New_Write(
                filePath);

            action(writer);

            writer.Flush();
        }

        //public bool Is_ReadOnly(string filePath)
        //{
        //    var fileAttributes = this.Get_FileAttributes(filePath);

        //    var output = fileAttributes & FileAttributes.ReadOnly;
        //    return output;
        //}

        public StreamWriter Open_ForWrite(
            string filePath,
            bool overwrite = IValues.Default_OverwriteValue_Constant)
        {
            var output = Instances.StreamWriterOperator.New_Write(
                filePath,
                overwrite);

            return output;

        }

        public Task<byte[]> Read_AllBytes(string filePath)
        {
            var output = File.ReadAllBytesAsync(filePath);
            return output;
        }

        public byte[] Read_AllBytes_Synchronous(string filePath)
        {
            var output = File.ReadAllBytes(filePath);
            return output;
        }

        public Task<byte[]> Read_Bytes(string filePath)
        {
            var output = File.ReadAllBytesAsync(filePath);
            return output;
        }

        public string Read_Text_Synchronous(string filePath)
        {
            var text = File.ReadAllText(filePath);
            return text;
        }

        public Task<string> Read_Text(string filePath)
        {
            return File.ReadAllTextAsync(filePath);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Read_AllBytes_Synchronous(string)"/>.
        /// </summary>
        public byte[] Read_Bytes_Synchronous(string filePath)
        {
            var output = this.Read_AllBytes_Synchronous(filePath);
            return output;
        }

        /// <summary>
        /// Writes the provided lines (and only the provided lines, with no trailing blank line) to a file.
        /// </summary>
        public Task Write_Lines(
            string textFilePath,
            IEnumerable<string> lines)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = Instances.StringOperator.Join(
                Instances.Characters.NewLine,
                lines);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        /// <inheritdoc cref="Write_Lines(string, IEnumerable{string})"/>
        public Task Write_Lines(
            string textFilePath,
            params string[] lines)
            => this.Write_Lines(
                textFilePath,
                lines.AsEnumerable());

        /// <inheritdoc cref="Write_Lines(string, IEnumerable{string})"/>
        public void Write_Lines_Synchronous(
            string textFilePath,
            params string[] lines)
        {
            this.Write_Lines_Synchronous(
                textFilePath,
                lines.AsEnumerable());
        }

        /// <inheritdoc cref="Write_Lines(string, IEnumerable{string})"/>
        public void Write_Lines_Synchronous(
            string textFilePath,
            IEnumerable<string> lines)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = Instances.StringOperator.Join(
                Instances.Characters.NewLine,
                lines);

            File.WriteAllText(
                textFilePath,
                text);
        }

        public Task Write_Text(
            string textFilePath,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        public void Write_Text_Synchronous(
            string textFilePath,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            File.WriteAllText(
                textFilePath,
                text);
        }

        public async Task Write_ToFile_FromIntermediateMemoryStream(
            string filePath,
            Action<StreamWriter> memoryStreamWriterAction,
            bool overwrite = IValues.Default_OverwriteValue_Constant)
        {
            // Open the file stream first, to trigger any overwrite errors before getting started with the in-memory stream,
            // and to make it look like this entire operation is using the file.
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                filePath,
                overwrite);

            // Now use a memory stream.
            using var memoryStream = new MemoryStream();
            using var memoryStreamWriter = new StreamWriter(memoryStream);

            memoryStreamWriterAction(memoryStreamWriter);

            // Synchronous flush since this is working on an in-memory stream.
            memoryStreamWriter.Flush();

            // Reset for reading.
            memoryStream.Position = 0;

            await memoryStream.CopyToAsync(fileStream);

            // No need to flush the file stream; it will be flushed upon exit from this method.
        }
    }
}
