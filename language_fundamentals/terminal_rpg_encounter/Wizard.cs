class Wizard : Human 
{
    public Wizard(string name) : base(name)
    {
        Intelligence = 25;
        Health = 50;
    }

    public override int Attack(Monster target)
    {
        int dmg = Intelligence * 5;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and healed for {dmg}!");
        return target.Health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 10;
        target.Health += heal;
        return target.Health;
    }
}