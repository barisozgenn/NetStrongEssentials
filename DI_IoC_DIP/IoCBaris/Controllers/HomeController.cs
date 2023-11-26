using Microsoft.AspNetCore.Mvc;

namespace IoCBaris;

public class HomeController: Controller
{
    readonly ILog _log;
    // Constructor injection with ILog dependency.
    public HomeController(ILog log){
        _log = log;
    }

    // Action method for the Index page.
    public IActionResult Index(){
        // Using the injected ILog instance to perform a log operation.
        // This demonstrates the flexibility of dependency injection.
        // We can easily switch between different log implementations (e.g., ConsoleLog, TextLog) without modifying this code.
        _log.TestMyLog();
        return View();
    }
}

