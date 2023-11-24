
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

public class StringParametersHub : Hub
{
    public string GetUserName(string firstName, string lastName){
        return $"{firstName} {lastName}";
    }
}