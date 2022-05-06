using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.Web.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class UsersController : Controller
    {

    }
}
