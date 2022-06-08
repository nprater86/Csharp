//Create an array to hold integer values 0 through 9
int[] arrayOfInts = new int[] {0,1,2,3,4,5,6,7,8,9};

//Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
string[] arrayOfNames = new string[] {"Tim","Martin","Nikki","Sara"};

//Create an array of length 10 that alternates between true and false values, starting with true
bool[] arrayOfBools = new bool[] {true, false, true, false, true, false, true, false, true, false};

//Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
List<string> icecream = new List<string>();
icecream.Add("chocolate");
icecream.Add("vanilla");
icecream.Add("strawberry");
icecream.Add("cookie dough");
icecream.Add("birthday cake");

// Output the length of this list after building it
for (var i = 0; i < icecream.Count; i++)
{
    Console.WriteLine(icecream[i]);
}

// Output the third flavor in the list, then remove this value
Console.WriteLine(icecream[2]);
icecream.RemoveAt(2);

// Output the new length of the list (It should just be one fewer!)
Console.WriteLine(icecream.Count);

// Create a dictionary that will store both string keys as well as string values
Dictionary<string,string> faveIcecream = new Dictionary<string, string>();

// Add key/value pairs to this dictionary where:
//  - each key is a name from your names array
//  - each value is a randomly elected flavor from your flavors list.

Random rand = new Random();
for (var i = 0; i < arrayOfNames.Length; i++){
    faveIcecream.Add(arrayOfNames[i],icecream[rand.Next(4)]);
}


// Loop through the dictionary and print out each user's name and their associated ice cream flavor
foreach (var entry in faveIcecream){
    Console.WriteLine(entry.Key + ": " + entry.Value);
}