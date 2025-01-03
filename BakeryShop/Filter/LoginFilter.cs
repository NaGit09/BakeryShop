namespace BakeryShop.Filter
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class LoginFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Kiểm tra cookie "AuthToken"
            var authToken = context.HttpContext.Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(authToken))
            {
                // Sử dụng TempData thay vì Session
                context.HttpContext.Response.Cookies.Append("LoginRequired", "true");

                context.Result = new RedirectToActionResult("Index", "BakeryShop", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Không cần xử lý sau khi action thực thi
        }
    }
}
