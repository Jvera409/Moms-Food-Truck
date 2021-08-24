using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MomsFoodTruck.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuDAO menuDAO;

        public MenuController(IMenuDAO menuDAO)
        {
            this.menuDAO = menuDAO;
        }

        [HttpGet]
        public ActionResult<List<Menu>> ListAllMenuItems()
        {
            List<Menu> menuItems = menuDAO.GetAllMenuItems();

            return Ok(menuItems);
        }
    }
}
