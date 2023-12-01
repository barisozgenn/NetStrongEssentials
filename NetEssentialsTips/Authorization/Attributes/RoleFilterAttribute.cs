using Microsoft.AspNetCore.Mvc;

namespace Authorization.Attributes;
public sealed class MyRoleFilterAttribute : TypeFilterAttribute
{
    public MyRoleFilterAttribute(string role) : base(typeof(MyRoleAttribute))
    {
        Arguments = new object[] { role };
    }
}
