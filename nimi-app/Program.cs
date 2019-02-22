using System;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// 
/// Doing stuff with first and last names of people
/// Reads names from txt files
/// 
/// Author: laveez
/// 
/// Creation date: 21.02.2019
/// 
/// </summary>
namespace nimi_app
{
    /// <summary>
    /// Program-class
    /// </summary>
    class Program
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Makes scambled versions of etunimet and sukunimet files
        /// </summary>
        public static void ScrambleNames()
        {
            var lines = File.ReadAllLines(@".\..\..\..\etunimet.txt");
            lines = lines.OrderBy(line => rnd.Next()).ToArray();
            File.WriteAllLines(@".\..\..\..\etunimet_scrambled.txt", lines);

            lines = File.ReadAllLines(@".\..\..\..\sukunimet.txt");
            lines = lines.OrderBy(line => rnd.Next()).ToArray();
            File.WriteAllLines(@".\..\..\..\sukunimet_scrambled.txt", lines);
        }

        /// <summary>
        /// Main program
        /// Streamreaders and writers for files
        /// 
        /// Makes random names using scrambled lists of first and lastnames
        /// </summary>
        /// <param name="args">Args</param>
        static void Main(string[] args)
        {
            string luettu_etu, luettu_suku;
            ScrambleNames();

            System.IO.StreamReader etunimet = new System.IO.StreamReader(@".\..\..\..\etunimet_scrambled.txt", Encoding.Default);
            System.IO.StreamReader sukunimet = new System.IO.StreamReader(@".\..\..\..\sukunimet_scrambled.txt", Encoding.Default);

            System.IO.StreamWriter tiedoston_kirjoitus = new System.IO.StreamWriter(@".\..\..\..\output.txt");

            while ((luettu_etu = etunimet.ReadLine()) != null  && (luettu_suku = sukunimet.ReadLine()) != null)
            {
                tiedoston_kirjoitus.Flush();
                tiedoston_kirjoitus.WriteLine(luettu_etu + " " + luettu_suku);
                Console.WriteLine(luettu_etu + " " + luettu_suku);
            }

            Console.WriteLine();
        }
    }
}
