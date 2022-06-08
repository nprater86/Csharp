class Spider : Monster
{
    public Spider(string name) : base(name)
    {
        Dexterity = 50;
        Health = 1500;
    }

    // Build Attack method
    public override int Attack(Human target)
    {
        int dmg = Dexterity * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}