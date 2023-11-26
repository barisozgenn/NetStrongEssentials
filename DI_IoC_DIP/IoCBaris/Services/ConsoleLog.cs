namespace IoCBaris;

public class ConsoleLog: ILog
{

    public ConsoleLog(int a)
    {

    }

    public void TestMyLog()
    {
        Console.WriteLine("ILog > TextLog");
    }
}
