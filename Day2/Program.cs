using System.Reflection;

enum Hand : int
{
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}
enum Result : int
{
    Win = 6,
    Lose = 0,
    Draw = 3,
}
class Program
{
    string[] lines;
    public Program()
    {
        lines = File.ReadAllLines("../../../../Input/Day2.dat");
    }
    public Result GetResult(Hand plyHand, Hand oppHand)
    {
        if (plyHand == oppHand)
        {
            return Result.Draw;
        }
        switch (plyHand)
        {
            case Hand.Rock:
                return (oppHand == Hand.Paper ? Result.Lose : Result.Win);
            case Hand.Paper:
                return (oppHand == Hand.Scissors ? Result.Lose : Result.Win);
            case Hand.Scissors:
                return (oppHand == Hand.Rock ? Result.Lose : Result.Win);
            default:
                throw new Exception("In Function GetResult: Expected a result");
        }
    }
    public Hand GetHand(string turn)
    {
        switch (turn)
        {
            case "A":
            case "X":
                return Hand.Rock;
            case "B":
            case "Y":
                return Hand.Paper;
            case "C":
            case "Z":
                return Hand.Scissors;
            default:
                throw new Exception("Field Not ABC OR XYZ");
        }
    }

    public Hand GetMove(Hand oppHand, Result result)
    {
        if (result == Result.Draw)
        {
            return oppHand;
        }
        switch (oppHand)
        {
            case Hand.Rock:
                return result == Result.Win ? Hand.Paper : Hand.Scissors;
            case Hand.Paper:
                return result == Result.Win ? Hand.Scissors : Hand.Rock;
            case Hand.Scissors:
                return result == Result.Win ? Hand.Rock : Hand.Paper;
            default:
                throw new Exception("In Function GetMove: Expected a result");
        }
    }



    public void Task1()
    {
        int count = 0;
        foreach (string line in lines)
        {
            var turns = line.Split(' ');
            var oppTurn = turns[0];
            var plyTurn = turns[1];

            Hand oppHand = GetHand(oppTurn);

            Hand plyHand = GetHand(plyTurn);

            count += (int)plyHand;
            var result = GetResult(plyHand, oppHand);
            count += (int)result;
        }
        Console.WriteLine($"The Answer to Part 1 is: {count}");
    }
    public void Task2()
    {
        int count = 0;
        foreach (string line in lines)
        {
            Result result = Result.Draw;
            var splitLine = line.Split(' ');
            var oppTurn = splitLine[0];
            var resultTurn = splitLine[1];

            switch (resultTurn)
            {
                case "X":
                    result = Result.Lose;
                    break;
                case "Y":
                    result = Result.Draw;
                    break;
                case "Z":
                    result = Result.Win;
                    break;
                default:
                    throw new Exception("Field OppHand Not X/Y/Z");
            }

            Hand oppHand = GetHand(oppTurn);
            Hand plyHand = GetMove(oppHand, result);

            count += (int)plyHand;
            count += (int)result;
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
