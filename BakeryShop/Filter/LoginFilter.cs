namespace BakeryShop.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



public class LoginFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Kiểm tra session "UserName"
        var authToken = context.HttpContext.Request.Cookies["AuthToken"];


        if (string.IsNullOrEmpty(authToken))
        {
            // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
            context.Result = new RedirectToActionResult("Index", "BakeryShop", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Không cần xử lý sau khi action thực thi
    }
}


