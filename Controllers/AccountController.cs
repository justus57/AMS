using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using AMS.Models;

namespace AMS.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection sql = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        void ConnectionString()
        {
            sql.ConnectionString = "Data Source=localhost;"+"Database = AMS; " +"Integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Login login)
        {
            ConnectionString();
            sql.Open();
            command.Connection = sql;
            command.CommandText = "Select * from Users where username ='"+login.Username +"'and password ='"+login.Password+"'";
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                sql.Close();
                return View();
            }
            else
            {
                sql.Close();
                return RedirectToAction("Register");
            } 
           
        }
        public ActionResult Register()
        {
            return View();
        }

    }
}