// Coin Flip
// Create a function called TossCoin() that returns a string
//   Have the function print "Tossing a Coin!"
//   Randomize a coin toss with a result signaling either side of the coin
//   Have the function print either "Heads" or "Tails"
//   Finally, return the result

static string TossCoin(){
    //log Tossing a Coin to the console
    Console.WriteLine("Tossing a Coin!");

    //declare string variable for result and create a new random object
    string result;
    Random rand = new Random();

    //create a new variable which will be randomly assigned to either 0 or 1
    int flip = rand.Next(2);

    if(flip == 0){
        result = "Heads";
    } else {
        result = "Tails";
    }
    return result;
}

// Optional:
// Create another function called TossMultipleCoins(int num) that returns a Double
//  Have the function call the tossCoin function multiple times based on num value
//  Have the function return a Double that reflects the ratio of head toss to total toss

static double TossMultipleCoins(int num){
    int count = 0;

    for (int i = 0; i < num; i++){
        string result = TossCoin();
        if (result == "Heads"){
            count++;
        }
    }
    double ratio = Convert.ToDouble(count) / num;
    return ratio;
}

//Names
// Build a function Names that returns a list of strings.  In this function:

// Required: 
//  Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
//  Return a list that only includes names longer than 5 characters

static List<string> Names(){
    List<string> names = new List<string>(){
        "Todd",
        "Tiffany",
        "Charlie",
        "Geneva",
        "Sydney"
    };

    return names.FindAll(name => name.Length > 5);
}

static List<string> ShuffleNames(){
    List<string> names = new List<string>(){
        "Todd",
        "Tiffany",
        "Charlie",
        "Geneva",
        "Sydney"
    };

    List<string> shuffledNames = new List<string>();

    Random rand = new Random();
    int count = names.Count;
    
    for (int i = 0; i < count; i++){
        int randomIndex = rand.Next(names.Count);
        shuffledNames.Add(names[randomIndex]);
        names.Remove(names[randomIndex]);
    }

    return shuffledNames;
}