using MomsFoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MomsFoodTruck.DAO.Interface
{
    public interface IMenuDAO
    {

        List<Menu> GetAllMenuItems();
    }
}
