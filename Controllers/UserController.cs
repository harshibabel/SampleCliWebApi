
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleCliWebApi.Models;

namespace SampleCliWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User1> user = new List<User1> {
            new User1
            {
                firstname= "Access",
                lastname= "Token"
            },
            new User1
            {
                firstname= "JWT",
                lastname= "Token"
            },
            new User1
            {
                firstname= "OpenID",
                lastname= "Token"
            }
        };

        //new code
        [HttpGet]
        public ActionResult<List<User1>> Get()
        {
            return Ok(User);
        }

        [HttpGet]
        [Route("{firstname}")]
        public ActionResult<User1> Get(string firstname)
        {
            var userItem = user.Find(item =>
                    item.firstname.Equals(firstname, StringComparison.InvariantCultureIgnoreCase));

            if (userItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userItem);
            }
        }

        //[HttpGet]
        //public User Get(int id)
        //{
        //    SqlDataReader reader = null;
        //    SqlConnection sqlconn = new SqlConnection();
        //    sqlconn.ConnectionString = @"Data Source=ADV-DEV-SQL;Initial Catalog=Harshi;User ID=harshi;Password=pass@word2";

        //    SqlCommand sqlCmd = new SqlCommand();
        //    sqlCmd.CommandType = CommandType.Text;
        //    sqlCmd.CommandText = "Select * from UserDetails where user_id=" + id + "";
        //    sqlCmd.Connection = sqlconn;
        //    sqlconn.Open();
        //    reader = sqlCmd.ExecuteReader();
        //    User user = null;
        //    while (reader.Read())
        //    {
        //        user = new User();
        //        user.user_id = Convert.ToInt32(reader.GetValue(0));
        //        user.firstname = reader.GetValue(1).ToString();
        //        user.lastname = reader.GetValue(2).ToString();
        //        user.username = reader.GetValue(3).ToString();
        //    }

        //    sqlconn.Close();
        //    return user;
        //}
    }
}