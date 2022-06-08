Ninja nathan = new Ninja();
Buffet ninjaBuffet = new Buffet();

nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());
nathan.Eat(ninjaBuffet.Serve());

class Food
{
    public string Name;
    public int Calories;
    public bool IsSpicy; 
    public bool IsSweet; 

    public Food(string name, int calories, bool isSpicy, bool isSweet) {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}

class Buffet
{
    public List<Food> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Banana", 100, false, true),
            new Food("Sandwich", 350, true, false),
            new Food("Zero Sugar Energy Drink", 10, false, true),
            new Food("Tofu", 50, false, false),
            new Food("Sweet and Spicy Chicken", 400, true, true),
            new Food("Cake", 800, false, true),
            new Food("Sushi", 370, false, false)
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(Menu.Count);
        return Menu[randomIndex];
    }
}

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    // add a constructor
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
    // add a public "getter" property called "IsFull"
    public bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }
    // build out the Eat method
    public void Eat(Food item)
    {
        if(!IsFull) {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.Write($"Ninja ate {item.Name}!");
            if(item.IsSpicy && item.IsSweet) {
                Console.WriteLine(" It was strangely spicy and sweet!");
            } else if(item.IsSpicy) {
                Console.WriteLine(" Ahh! It was spicy!");
            } else if(item.IsSweet) {
                Console.WriteLine(" It was sweet! Yum!");
            } else {
                Console.WriteLine(" It was pretty bland...");
            }
        } else {
            Console.WriteLine("Ninja is pretty full!");
        }
    }
}