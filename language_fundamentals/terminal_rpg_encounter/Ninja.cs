class Ninja : Human 
{
    public Ninja(string name) : base(name)
    {
        Dexterity = 175;
    }

    public override int Attack(Monster target)
    {
        int dmg = Dexterity * 5;

        Random rand = new Random();
        int critRoll = rand.Next(5);
        if(critRoll == 0){
            dmg += 10;
        }

        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }

    public int Steal(Monster target)
    {
        target.Health -= 5;
        Health += 5;
        return target.Health;
    }
}