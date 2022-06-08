class Wizard : Human 
{
    public Wizard(string name) : base(name)
    {
        Intelligence = 25;
        health = 50;
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 5;
        target.health -= dmg;
        health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and healed for {dmg}!");
        return target.health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 10;
        target.health += heal;
        return target.health;
    }
}