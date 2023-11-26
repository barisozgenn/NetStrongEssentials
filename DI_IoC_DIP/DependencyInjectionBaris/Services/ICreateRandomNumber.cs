namespace DependencyInjectionBaris;

public interface ICreateRandomNumberSingleton
{
    public int RandomNumber{get;}
    public int GetRandomNumber();
}
public interface ICreateRandomNumberScoped
{
    public int RandomNumber{get;}
}
public interface ICreateRandomNumberScoped2
{
    public int RandomNumberFromTransient{get;}
}
public interface ICreateRandomNumberTransient
{
    public int RandomNumber{get;}
    public int RandomNumberFromScoped{get;}
}
