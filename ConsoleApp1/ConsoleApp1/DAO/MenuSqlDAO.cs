using MomsFoodTruck.DAO.Interface;
using MomsFoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MomsFoodTruck.DAO
{
    class MenuSqlDAO : IMenuDAO
    {
        private readonly string connectionString;

        private string sqlGetMenuItems = "SELECT food_description, food_price FROM menu";

        public MenuSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Menu> GetAllMenuItems()
        {
            List<Menu> menuItems = new List<Menu>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetMenuItems, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Menu items = new Menu();

                        items = ReaderToMenu(reader);

                        menuItems.Add(items);
                    }
                }
            }
            catch (Exception ex)
            {
                menuItems = new List<Menu>();
            }
            return menuItems;
        }

        private Menu ReaderToMenu(SqlDataReader reader)
        {
            Menu menu = new Menu();

            menu.MenuId = Convert.ToInt32(reader["menu_id"]);
            menu.FoodName = Convert.ToString(reader["food_name"]);
            menu.FoodDescription = Convert.ToString(reader["food_description"]);
            menu.FoodPrice = Convert.ToString(reader["food_price"]);

            return menu;
        }
    }
}
