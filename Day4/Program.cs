using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Program
{
    string[] lines;
    public Program()
    {

        lines = File.ReadAllLines("../../../../Input/Day4.dat");
    }

    public void Task1()
    {
        var count = 0;
        foreach(string line in lines)
        {
            string[] sections = line.Split(',');
            int p1Min = int.Parse(sections[0].Split("-")[0]);
            int p1Max = int.Parse(sections[0].Split("-")[1]);
            int p2Min = int.Parse(sections[1].Split("-")[0]);
            int p2Max = int.Parse(sections[1].Split("-")[1]);

            List<int> person1 = new List<int>();
            List<int> person2 = new List<int>();

            for (int i = p1Min; i <= p1Max; i++)
                person1.Add(i);
            for (int i = p2Min; i <= p2Max; i++)
                person2.Add(i);

            if(person1.Intersect(person2).Count() == person1.Count())
            {
                count++;
                continue;
            }
            if (person2.Intersect(person1).Count() == person2.Count())
            {
                count++;
                continue;
            }
        }
        Console.WriteLine($"The Answer to Part 1 is: {count}");
    }
    public void Task2()
    {
        var count = 0;
        foreach (string line in lines)
        {
            string[] sections = line.Split(',');
            int p1Min = int.Parse(sections[0].Split("-")[0]);
            int p1Max = int.Parse(sections[0].Split("-")[1]);
            int p2Min = int.Parse(sections[1].Split("-")[0]);
            int p2Max = int.Parse(sections[1].Split("-")[1]);

            List<int> person1 = new List<int>();
            List<int> person2 = new List<int>();

            for (int i = p1Min; i <= p1Max; i++)
                person1.Add(i);
            for (int i = p2Min; i <= p2Max; i++)
                person2.Add(i);

            if (person1.Intersect(person2).Any())
            {
                count++;
                continue;
            }
        }
        Console.WriteLine($"The Answer to Part 2 is: {count}");
    }

    public static void Main(string[] args)
    {
        var p = new Program();
        p.Task1();
        p.Task2();
    }
}
