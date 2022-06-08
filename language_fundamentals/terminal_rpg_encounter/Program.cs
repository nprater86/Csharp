//Intro
Console.WriteLine("Welcome to the Adventure Game! You will take control of three heroes and battle the evil monsters!");
Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

//Create Heroes
Console.Clear();
Console.Write("Let's create our heroes! What would you like to name your Ninja?: ");
var ninjaName = Console.ReadLine();
while(ninjaName == "" || ninjaName == null){
    Console.Clear();
    Console.Write("Ninja name cannot be blank! Please enter a ninja name: ");
    ninjaName = Console.ReadLine();
}
Console.Clear();
Console.Write($"{ninjaName} is a great name! Now, what would you like to name your Wizard?: ");
var wizardName = Console.ReadLine();
while(wizardName == "" || wizardName == null){
    Console.Clear();
    Console.Write("Wizard name cannot be blank! Please enter a wizard name: ");
    wizardName = Console.ReadLine();
}
Console.Clear();
Console.Write($"{wizardName} will do... Lastly, what would you like to name your Samurai?: ");
var samuraiName = Console.ReadLine();
while(samuraiName == "" || samuraiName == null){
    Console.Clear();
    Console.Write("Samurai name cannot be blank! Please enter a samurai name: ");
    samuraiName = Console.ReadLine();
}
Console.Clear();
Console.WriteLine($"{samuraiName} is excellent! Creating your party...");
Ninja ninja = new Ninja(ninjaName);
Wizard wizard = new Wizard(wizardName);
Samurai samurai = new Samurai(samuraiName);
Console.WriteLine("Party created! Press any key to start the game...");
Console.ReadKey(true);

//Set up monsters
Spider spider = new Spider("Spider");
Zombie zombie1 = new Zombie("Zombie 1");
Zombie zombie2 = new Zombie("Zombie 2");

//Introduce monsters
Console.Clear();
Console.WriteLine("Your party is walking through the woods and encounter a gang of monsters!");
Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);
Console.Clear();
Console.WriteLine("Looking closer, you see two Zombies and a Spider! Get ready for battle!");
Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

//Start encounter
int heroHp = ninja.Health + wizard.Health + samurai.Health;
int monsterHp = spider.Health + zombie1.Health + zombie2.Health;
List<Human> heroTurns = new List<Human>() {ninja, wizard, samurai};
List<Monster> monsterTurns = new List<Monster>() {spider, zombie1, zombie2};

//gameloop starts
while(heroHp > 0 && monsterHp > 0){
    Console.Clear();
    Console.WriteLine("------Party HP------");
    Console.WriteLine($"{ninja.Name}: {ninja.Health} | {wizard.Name}: {wizard.Health} | {samurai.Name}: {samurai.Health}");
    Console.WriteLine();
    Console.WriteLine("------Monster HP------");
    Console.WriteLine($"{spider.Name}: {spider.Health} | {zombie1.Name}: {zombie1.Health} | {zombie2.Name}: {zombie2.Health}");
    Console.WriteLine();

    //cycle through the heros
    foreach(Human hero in heroTurns){
        Console.WriteLine($"What would you like {human.Name} to do?");
        if(hero.GetType() == Wizard){
            Console.Write("Attack or Heal?: ");
        }
    }
}