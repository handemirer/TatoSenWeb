using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using EntityLayer.Model;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeApiAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        var user = (User)context.HttpContext.Items["User"];

        //if (user == null)
        //{
        //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //}
    }
}