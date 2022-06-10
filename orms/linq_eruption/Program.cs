List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!
//Use LINQ to find the first eruption that is in Chile and print the result.
// List<Eruption> firstChileEruption = new List<Eruption>();
// firstChileEruption.Add(eruptions.FirstOrDefault(e => e.Location == "Chile"));
// PrintEach(firstChileEruption, "First eruption in Chile");

//Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
// List<Eruption> firstEruption = new List<Eruption>();
// Console.Write("What is your query for first eruption?: ");
// string query = Console.ReadLine();
// Eruption queryResult = eruptions.FirstOrDefault(e => e.Location == query);
// if(queryResult != null)
// {
//     firstEruption.Add(queryResult);
//     PrintEach(firstEruption, $"First {query} Eruption");
// }
// else
// {
//     Console.WriteLine($"No {query} Eruption found.");
// }

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
// List<Eruption> firstEruption = new List<Eruption>();
// Eruption queryResult = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
// if(queryResult != null)
// {
//     firstEruption.Add(queryResult);
//     PrintEach(firstEruption, $"First Eruption after 1900 in New Zealand");
// }
// else
// {
//     Console.WriteLine($"No Eruption found.");
// }

//Find all eruptions where the volcano's elevation is over 2000m and print them.
// IEnumerable<Eruption> over2000Elevation = eruptions.Where(c => c.ElevationInMeters > 2000);
// PrintEach(over2000Elevation, "Eruptions at over 2000m elevation.");

//Find all eruptions where the volcano's name starts with "Z" and print them. Also print the number of eruptions found.
// IEnumerable<Eruption> startsWithZ = eruptions.Where(c => c.Volcano.StartsWith('Z'));
// PrintEach(startsWithZ, "Volcanoes starting with Z");
// Console.WriteLine($"Number of eruptions of volcannoes starting with Z: {startsWithZ.Count()}");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
// int queryResult = eruptions.Max(e => e.ElevationInMeters);
// Console.WriteLine($"Max Elevation: {queryResult}m");


// Use the highest elevation variable to find a print the name of the Volcano with that elevation.
// int maxElevation = eruptions.Max(e => e.ElevationInMeters);
// Eruption queryResult = eruptions.FirstOrDefault(e => e.ElevationInMeters == maxElevation);
// Console.WriteLine(queryResult.Volcano);

//Print all Volcano names alphabetically
// IEnumerable<Eruption> sortedVolcanoes = eruptions.OrderBy(c => c.Volcano);
// PrintEach(sortedVolcanoes);

//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
// IEnumerable<Eruption> sortedVolcanoes = eruptions.Where(c => c.Year<1000).OrderBy(c => c.Volcano);
// PrintEach(sortedVolcanoes);

//BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
IEnumerable<Eruption> sortedVolcanoes = eruptions.Where(c => c.Year<1000).OrderBy(c => c.Volcano);
string[] sortedVolcanoNames = sortedVolcanoes.Select(c => c.Volcano).ToArray();
PrintEach(sortedVolcanoNames, "Sorted Volcano Names:");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
