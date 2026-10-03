namespace Part1_ProceduralToOOP;

class Program
{
    static void Main(string[] args)
    {
        var system = new OrderSystem();
        SampleData.Seed(system);
        SampleData.RunDemo(system);
 
        var menu = new ConsoleMenu(system);
        menu.ShowOverview();
        menu.Run();
    }
}