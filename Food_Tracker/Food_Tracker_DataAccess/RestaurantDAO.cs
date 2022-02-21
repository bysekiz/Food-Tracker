using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Tracker_DataAccess
{
    public class RestaurantDAO
    {

        public List<dynamic> GetUsersByRestaurantNameOrCity(string restaurantName, string city)
        {
            var list = new List<dynamic>();

            SqlCommand cmd = new SqlCommand();  

            string sql = @"Select u.Name,u.Id,u.Adress,p.PhoneNumber,u.Bio,u.CategoryId,u.Since,u.City,p.CategoryName,p.Id
                            FROM tblRestaurant u INNER JOIN tblCategory p on u.CategoryId = p.Id  WHERE u.Name LIKE @restaurantName OR u.City LIKE @city";

            using (SqlDataReader dr = cmd.ExecuteReader(sql, new SqlParameter("restaurantName", $"%{restaurantName}%"), new SqlParameter("city", $"%{city}%")))
            {
                while (dr.Read())
                {
                    var restaurant = new
                    {
                        Name = dr["Name"],
                        Id = dr["Id"],
                        Adress = dr["Adress"],
                        PhoneNumber = dr["PhoneNumber"],
                        Bio = dr["Bio"],
                        CategoryName = dr["CategoryName"],
                        Since = dr["Since"],
                        City = dr["City"],
                        District = dr["District"],
                        SubscriptionEndDate = dr["SubscriptionEndDate"],



                    };
                    list.Add(restaurant);

                }
            }
            return list;

        }
    }
}
