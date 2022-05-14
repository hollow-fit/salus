using System;
using System.IO;
using System.Collections.Generic;

namespace Salus
{
    /// <summary>
    /// Class <Parser> parses an incoming file, places the contents into a data
    /// structure and returns that data structure to the client.
    /// <para>
    /// In order for parser to function correctly, it will need to have at 
    /// minimum the name of the file to be parsed. 
    /// <para>
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Instance variable <c>fileName</c> represents the file name of the
        /// file that is to be parsed. 
        /// </summary>
        private string fileName;

        /// <summary>
        /// Instance variable <c>headers</c> represents the header
        /// columns that are listed in the file that is to be parsed.
        /// </summary>
        /// <remarks> 
        /// v0.0.1-prealpha only takes file of type CSV. 
        /// </remarks>
        private List<string> headers;

        /// <summary>
        /// Instance variable <c>content</c> represents the contents of the
        /// file that are read into the programs. 
        /// </summary>
        private List<string[]> content;

        /// <summary>
        /// Method <c>Parser</c> constructs a new Parser object with the name of
        /// the file, <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">the name of the file to be parsed.</param>
        public Parser(string fileName)
        {
            this.fileName = fileName;
            (this.headers, this.content) = this.parseFile(this.fileName);
        }

        /// <summary>
        /// Method <c>parseFile</c> parses the file whose name is specified by
        /// the file's name. <see cref="fileName"/> 
        /// </summary>
        /// <param name="fileName">the name of the file to be parsed.</param>
        /// <return>
        /// A tuple that contains the files headers in position 0 and the files
        /// conents in position 2. The headers are a list of strings. The
        /// content of the file is a list of arrays of type string.
        /// </return>
        private (List<string>, List<string[]>) parseFile(string fileName)
        {
            List<string> headers = new List<string>();
            List<string[]> content = new List<string[]>();
            try
            {
                using (StreamReader stringReader = new StreamReader(fileName))
                {
                    Array.ForEach(stringReader.ReadLine().Split(','), str => headers.Add(str.Trim()));
                    string line;
                    while((line = stringReader.ReadLine()) != null)
                    {
                        int count = 0;
                        string[] temp = new string[headers.Count];
                        Array.ForEach(line.Split(','), (str) => temp[count++] = str.Trim());
                        content.Add(temp);
                    } 
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File could not be read:");
                Console.WriteLine(e.Message);
            }
            return (headers, content);
        }

        /// <summary>
        /// Method <c>getContentHeaders</c> returns the list of headers that are
        /// specified in the file.
        /// </summary>
        /// <return>
        /// A List of strings that represent the file's headers.
        /// </return>
        public List<string> getHeaders()
        {
            return this.headers;
        }

        /// <summary>
        /// Method <c>getFileContents</c> returns the list of contents that are
        /// specified in the file.
        /// </summary>
        /// <return>
        /// A list of arrays of strings which contain the files contents. The
        /// arrays of strings contains the representation of a single data 
        /// record in the file. 
        /// </return>
        public List<string[]> getContent()
        {
            return this.content;
        }
    }
}

