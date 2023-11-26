using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionBaris;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ICreateRandomNumberSingleton _singletonNumber;
    private readonly ICreateRandomNumberScoped _scopedNumber;
    private readonly ICreateRandomNumberScoped2 _scopedNumber2;
    private readonly ICreateRandomNumberTransient _transientNumber;

    public HomeController(ICreateRandomNumberSingleton createRandomNumberSingleton,
                        ICreateRandomNumberScoped createRandomNumberScoped,
                        ICreateRandomNumberScoped2 createRandomNumberScoped2,
                        ICreateRandomNumberTransient createRandomNumberTransient)
    {
        _singletonNumber = createRandomNumberSingleton;
        _scopedNumber= createRandomNumberScoped;
        _scopedNumber2 = createRandomNumberScoped2;
        _transientNumber = createRandomNumberTransient;
    }
    [HttpGet]
    public object GetNumber()
    {

        return "_singletonNumber.RandomNumber: \t\t\t\t"+_singletonNumber.RandomNumber +
                "\n\t_singletonNumber.GetRandomNumber(): \t"+_singletonNumber.GetRandomNumber()+"\n"+

                "\n\n_scopedNumber.RandomNumber: \t\t\t\t"+_scopedNumber.RandomNumber +
                "\n_scopedNumber.RandomNumberFromTransient: \t"+_scopedNumber2.RandomNumberFromTransient +

                "\n\n_transientNumber.RandomNumber: \t\t\t\t"+_transientNumber.RandomNumber +
                "\n_transientNumber.RandomNumberFromScoped: \t"+_transientNumber.RandomNumberFromScoped;
    }
}
