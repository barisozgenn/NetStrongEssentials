namespace DependencyInjectionBaris;

public class CreateRandomNumberSingleton : ICreateRandomNumberSingleton
{

    public int RandomNumber{get;}

    public CreateRandomNumberSingleton()
    {
        RandomNumber = GetRandomNumber();
    }
    public int GetRandomNumber()
    {
        return new Random().Next(100,999);
    }
}
public class CreateRandomNumberScoped : ICreateRandomNumberScoped
{
    public int RandomNumber{get;}
    public int RandomNumberFromTransient{get;}

    public CreateRandomNumberScoped()
    {
        RandomNumber = new Random().Next(100,999);
    }
}
public class CreateRandomNumberScoped2 : ICreateRandomNumberScoped2
{
    public int RandomNumberFromTransient{get;}
    private readonly ICreateRandomNumberTransient _createRandomNumberTransient;

    public CreateRandomNumberScoped2(ICreateRandomNumberTransient createRandomNumberTransient)
    {
        _createRandomNumberTransient = createRandomNumberTransient;
        RandomNumberFromTransient = _createRandomNumberTransient.RandomNumber;
    }
}
public class CreateRandomNumberTransient : ICreateRandomNumberTransient
{
    public int RandomNumber{get;}
    public int RandomNumberFromScoped{get;}

    private readonly ICreateRandomNumberScoped _createRandomNumberScoped;
    public CreateRandomNumberTransient(ICreateRandomNumberScoped createRandomNumberScoped)
    {
        _createRandomNumberScoped = createRandomNumberScoped;
        RandomNumberFromScoped = _createRandomNumberScoped.RandomNumber;
        RandomNumber = new Random().Next(100,999);
    }
}
