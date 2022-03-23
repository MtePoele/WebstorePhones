using Microsoft.AspNetCore.Mvc;

namespace WebstorePhones.Api.Controllers
{
    public class BaseController : Controller
    {
        public string UserId => User.FindFirst("Id").Value;
    }
}
