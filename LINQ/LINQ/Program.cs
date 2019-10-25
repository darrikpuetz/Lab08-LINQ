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
            //Reading json file and instructions from readings
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
            var allQ = downTown.features.Where(a => a.properties.neighborhood.Length > 0)
                .GroupBy(b => b.properties.neighborhood)
                .Select(c => c.First());
            foreach (var hood in allQ)
            {
                Console.WriteLine(hood.properties.neighborhood);
            }


            Console.WriteLine("These are the hoods revised.");
            var newQ = downTown.features.Select(d => d.properties.neighborhood);
            foreach (var hood in newQ)
            {
                Console.WriteLine(hood);
            }
        }

    }


}
