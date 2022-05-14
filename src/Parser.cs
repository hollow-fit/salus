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
        /// Instance variable <c>contentHeaders</c> represents the header
        /// columns that are listed in the file that is to be parsed.
        /// </summary>
        /// <remarks> 
        /// v0.0.1-prealpha only takes file of type CSV. 
        /// </remarks>
        private List<string> contentHeaders;

        /// <summary>
        /// Instance variable <c>fileContents</c> represents the contents of the
        /// file that are read into the programs. 
        /// </summary>
        private List<string[]> fileContents;

        /// <summary>
        /// Method <c>Parser</c> constructs a Parser object.
        /// </summary>
        /// <param name="fileName">the name of the file to be parsed.</param>
        public Parser(string fileName)
        {
            this.fileName = fileName;
            this.contentHeaders = new List<string>();
            this.fileContents = new List<string[]>();
            this.parseFile();
        }

        /// <summary>
        /// Method <c>parseFile</c> parses the file whose name is specified by
        /// the file's name. <see cref="fileName"/> 
        /// </summary>
        private void parseFile()
        {
            try
            {
                using (StreamReader stringReader = new StreamReader(this.fileName))
                {
                    Array.ForEach(stringReader.ReadLine().Split(','), str => this.contentHeaders.Add(str.Trim()));
                    string line;
                    while((line = stringReader.ReadLine()) != null)
                    {
                        int count = 0;
                        string[] content = new string[this.contentHeaders.Count];
                        Array.ForEach(line.Split(','), (str) => content[count++] = str.Trim());
                        this.fileContents.Add(content);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Method <c>getContentHeaders</c> returns the list of headers that are
        /// specified in the file.
        /// </summary>
        /// <return>
        /// A List of strings that represent the file's headers.
        /// </return>
        public List<string> getContentHeaders()
        {
            return this.contentHeaders;
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
        public List<string[]> getFileContents()
        {
            return fileContents;
        }
    }
}

