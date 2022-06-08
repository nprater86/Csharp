class Zombie : Monster
{
    public Zombie(string name) : base(name)
    {
        Strength = 50;
        Health = 3000;
    }

    // Build Attack method
    public override int Attack(Human target)
    {
        int dmg = Strength * 2;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}