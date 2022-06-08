Buffet ninjaBuffet = new Buffet();
SweetTooth nathan = new SweetTooth();
SpiceHound sekiro = new SpiceHound();

int nathanCount = 0;
int sekiroCount = 0;

while(!nathan.IsFull)
{
    nathan.Consume(ninjaBuffet.Serve());
    nathanCount++;
}

while(!sekiro.IsFull)
{
    sekiro.Consume(ninjaBuffet.Serve());
    sekiroCount++;
}

if(nathanCount > sekiroCount)
{
    Console.WriteLine($"Nathan ate more than Sekiro! Nathan ate {nathanCount} items while Sekiro only ate {sekiroCount}!");
} 
else if (nathanCount < sekiroCount)
{
    Console.WriteLine($"Sekiro ate more than Nathan! Sekrio ate {sekiroCount} items while Nathan only ate {nathanCount}!");
}
else
{
    Console.WriteLine($"Nathan and Sekrio tied! Both ate {nathanCount} items!");
}