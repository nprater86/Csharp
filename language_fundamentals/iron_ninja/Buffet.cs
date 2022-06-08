class Buffet
{
    public List<IConsumable> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("Banana", 100, false, true),
            new Food("Sandwich", 350, true, false),
            new Food("Tofu", 50, false, false),
            new Food("Sweet and Spicy Chicken", 400, true, true),
            new Food("Cake", 800, false, true),
            new Food("Sushi", 370, false, false),
            new Food("Pie", 700, false, true),
            new Drink("Zero Sugar Energy Drink", 10),
            new Drink("Water", 0),
            new Drink("Gatorade", 200),
            new Drink("Coca Cola Starlight", 90),
            new Drink("Coffee", 45),
            new Drink("Milkshake", 900),
            new Drink("Veggie Smoothie", 50)
        };
    }

    public IConsumable Serve()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(Menu.Count);
        return Menu[randomIndex];
    }
}