using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;




namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewPlaces();
        }

        static void ViewPlaces()
        {
            string allText = File.ReadAllText("../../../../data.json");
            Example downTown = JsonConvert.DeserializeObject<Example>(allText);

            var allCities = from d in downTown.features
                            select d.properties.neighborhood;
            foreach (var hood in allCities)
            {
                Console.WriteLine(hood);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("These are the hoods with names.");
            var filterQuery = from hood in allCities
                              where hood.Length > 0
                              select hood;
            foreach (var hood in filterQuery)
            {
                Console.WriteLine(hood);
            }


            Console.WriteLine("These are the nondupilicate hoods");
            var noDupQuery = filterQuery.Distinct();
            foreach (var hood in noDupQuery)
            {
                Console.WriteLine(hood);
            }

            Console.WriteLine("These are the hoods with all Queries.");


        }
    }


}
