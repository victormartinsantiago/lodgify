namespace VacationRental.Contact.Api.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><body><h2>Contact Service is up and running</h2></body></html>"
            };
        }
    }
}