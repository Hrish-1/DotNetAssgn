using AssignmentMVC1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC1.Controllers
{
    public class UserController : Controller
    {
       //HttpCookie cookie; 
        static string s = ConfigurationManager.ConnectionStrings["DBCS2"].ConnectionString;
        SqlConnection sql = new SqlConnection(s);
       
        public ActionResult Login()
        {
            //User user = new User();
            return View();
        }
        // GET: User
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                sql.Open();
                //user = new User();
                Debug.WriteLine("value of i");
                SqlCommand cmd = new SqlCommand("select * from Users where UserName=@userName and Password=@password", sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", user.userName);
                cmd.Parameters.AddWithValue("@password", user.password);

                //int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                //Debug.WriteLine("value of i"+i);
                if (dr.Read())
                {
                    user = new User { userName = dr["UserName"].ToString(), emailId = dr["EmailId"].ToString(), phoneNumber = dr["PhoneNo"].ToString(), cityId = Convert.ToInt32(dr["CityId"])};
                    
                        HttpCookie cookie = new HttpCookie("user");
                        cookie.Expires = DateTime.Now.AddMinutes(5);
                        cookie.Value = user.userName;
                        Response.Cookies.Add(cookie);
                        //cookie.Values["password"] = user.password;
                    
                    Session["user"] = user;
                    sql.Close();
                    
                }
                return RedirectToAction("Home");
            }
            catch(Exception ex)
            {
                sql.Close();
                Debug.WriteLine(ex.Message);
                return RedirectToAction("CD");
            }
            
        }
        // GET: User/Details/5
        public ActionResult Home()
        {
            if (Session["user"] != null)
            {
                User u = (User)Session["user"];
                return View(u);
            }else if(Request.Cookies["user"] != null)
            {
                HttpCookie cookie = Request.Cookies["user"];
                User u = null;
                sql.Open();

                SqlCommand cmd = new SqlCommand("select * from Users where UserName=@userName", sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName",cookie.Value);
  

                //int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                //Debug.WriteLine("value of i"+i);
                if (dr.Read())
                {
                    u = new User { userName = dr["UserName"].ToString(), emailId = dr["EmailId"].ToString(), phoneNumber = dr["PhoneNo"].ToString(), cityId = Convert.ToInt32(dr["CityId"]) };
                    sql.Close();

                }

                return View(u);
            }
                
            else return RedirectToAction("Login");
        }

        // GET: User/Register/1
        public ActionResult Register()
        {
            User u = new User();
            List<SelectListItem> li = new List<SelectListItem>();
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from cities",sql);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                li.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });
            }
            u.Cities = li;
            sql.Close();
            return View(u);
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("insert into Users values (@UserName,@Password,@EmailId,@PhoneNo,@CityId)",sql);
                cmd.Parameters.AddWithValue("@UserName", user.userName);
                cmd.Parameters.AddWithValue("@Password", user.password);
                cmd.Parameters.AddWithValue("@EmailId", user.emailId);
                cmd.Parameters.AddWithValue("@CityId", user.cityId);
                cmd.Parameters.AddWithValue("@PhoneNo", user.phoneNumber);
                cmd.ExecuteNonQuery();
                return RedirectToAction("Login");
            }
            catch 
            {
                return View();
            }
            finally
            {
                sql.Close();
            }
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies["user"].Expires = DateTime.Now.AddMinutes(-10);
            return RedirectToAction("Login");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
