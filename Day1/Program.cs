using System.Runtime.InteropServices;

class Program
{
    string[] lines;
    public Program()
    {

        lines = File.ReadAllLines("../../../../Input/Day1.dat");
    }
    public void Task1()
    {
        var totalList = new List<int>();
        var count = 0;
        foreach (string line in lines)
        {
            if (int.TryParse(line, out var num))
            {
                count += num;
            }
            else
            {
                totalList.Add(count);
                count = 0;
            }
        }

        Console.WriteLine($"Task 1 Answer Is: {totalList.Max()}");

    }
    public void Task2()
    {
        var totalList = new List<int>();
        var count = 0;
        foreach (string line in lines)
        {
            if (int.TryParse(line, out var num))
            {
                count += num;
            }
            else
            {
                totalList.Add(count);
                count = 0;
            }
        }

        totalList.Sort();
        totalList.Reverse();

        var top3Count = 0;
        for (int i = 0; i < 3; i++)
        {
            top3Count += totalList[i];
        }
        Console.WriteLine($"Task 2 Answer Is: {top3Count}");

    }

    public static void Main(string[] args)
    {
        var p = new Program();
        p.Task1();
        p.Task2();
    }
}
