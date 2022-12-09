using System.Runtime.InteropServices;

class Program
{
    string[] lines;
    public Program()
    {

        lines = File.ReadAllLines("../../../../Input/Day3.dat");
    }

    public int getPriority(char inputChar)
    {
        string priorityIndex = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < priorityIndex.Length; i++)
        {
            if (priorityIndex[i] == inputChar)
            {
                return i+1;
            }
        }
        throw new Exception("Non Alphabetical character checked in getPriority Function");
    }
    public void Task1()
    {
        var count = 0;
        foreach (string line in lines)
        {

            string comp1 = line.Substring(0, line.Length / 2);
            string comp2 = line.Substring(line.Length / 2);

            char[] comp1Arr = comp1.ToCharArray();
            char[] comp2Arr = comp2.ToCharArray();

            foreach (char item in comp1Arr)
            {
                if (comp2Arr.Contains(item))
                {
                    count += getPriority(item);
                    break;
                }
            }
        }
        Console.WriteLine($"The Answer to Part 1 is: {count}");
    }
    public void Task2()
    {
        var count = 0;
        for (int i = 0; i < lines.Length; i+=3)
        {
            string person1 = lines[i];
            string person2 = lines[i+1];
            string person3 = lines[i+2];

            char[] p1Array = person1.ToCharArray();
            char[] p2Array = person2.ToCharArray();
            char[] p3Array = person3.ToCharArray();

            
            foreach (char item in p1Array)
            {
                if(p2Array.Contains(item) && p3Array.Contains(item))
                {
                    count += getPriority(item);
                    break;
                }
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
