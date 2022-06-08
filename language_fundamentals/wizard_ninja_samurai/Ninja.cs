class Ninja : Human 
{
    public Ninja(string name) : base(name)
    {
        Dexterity = 175;
    }

    public override int Attack(Human target)
    {
        int dmg = Dexterity * 5;

        Random rand = new Random();
        int critRoll = rand.Next(5);
        if(critRoll == 0){
            dmg += 10;
        }

        target.health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.health;
    }

    public int Steal(Human target)
    {
        target.health -= 5;
        health += 5;
        return target.health;
    }
}