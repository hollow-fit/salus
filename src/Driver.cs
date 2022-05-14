using System;

namespace Salus
{
    /// <summary>
    /// Class <c>Driver</c> serves as the entry point for the Salus
    /// application until GUI can be performed. 
    /// <para>
    /// The Driver class can be converted into the interface class between the 
    /// model and the view when the GUI is developed.
    /// </para>
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Instance variable <c>fileName</c> represents the file's name that is
        /// to be parsed.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Instance variable <c>parser</c> represents a Parser object. <see
        /// cref="Parser"/>
        /// </summary>
        private Parser parser;

        /// <summary>
        /// Method <c>Driver</c> constructs the Driver object.
        /// </summary>
        public Driver()
        {
            fileName = @"../res/nutrient-report.csv";
            this.parser = new Parser(fileName);
        }

        /// <summary>
        /// Method <c>Main</c> is the entry point for the Salus program.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Driver driver = new Driver();

            driver.parser.getHeaders().ForEach(str => Console.WriteLine(str));

            Console.WriteLine(driver.parser.getContent().Count);
            driver.parser.getContent().ForEach(strList => 
            {
                for (int i = 0; i < driver.parser.getHeaders().Count; i++)
                {
                    Console.WriteLine(strList[i]);
                }
            });
        }
    }
}
