using Admixer.TestTask;

internal class Program
{
    private static void Main(string[] args)
    {
        ThreeInRow threeInRow = new ThreeInRow(9, 9);

        Console.WriteLine("Before:");
        threeInRow.OutputMatrix();

        threeInRow.DeleteSameNumber();

        Console.WriteLine("After:");
        threeInRow.OutputMatrix();

        threeInRow.LogMatrix("result.txt");
    }
}