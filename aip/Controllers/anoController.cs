using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Sql;
namespace aip.Controllers
{
    public class anoController : Controller
    {
        //
        // GET: /ano/
        public ActionResult home()
        {
            return View();
        }
        public ActionResult studentlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult studentlogin(aip.Models.student model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from student where userid='" + model.userid + "' and pwd='" + model.pwd + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["userid"] = model.userid;

                return RedirectToAction("studenthome", "student");
            }

            else
            {
                ViewBag.msg = "invalid info";
                return View(model);

            }
        }
      
        public ActionResult facultylogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult facultylogin(aip.Models.faculty model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from faculty where userid='" + model.userid + "' and pwd='" + model.pwd + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["userid"] = model.userid;

                return RedirectToAction("facultyhome", "faculty");
            }

            else
            {
                ViewBag.msg = "invalid info";
                return View(model);
            }
        }
        public ActionResult parentlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult parentlogin(aip.Models.parent model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from parent where userid='" + model.userid + "' and pwd='" + model.pwd + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["userid"] = model.userid;

                return RedirectToAction("parenthome", "parent");
            }

            else
            {
                ViewBag.msg = "invalid info";
                return View(model);
            }
        }
        public ActionResult adminlogin()
        {
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(aip.Models.student model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into student values('" + model.userid + "','" + model.pwd + "','" + model.name + "','" + model.rollno + "','" + model.email + "','" + model.regno + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("insert into student_profile values('" + model.userid + "','','','','','','','','','','blank.jpg')", con);
                    cmd1.ExecuteNonQuery();
                    ViewBag.msg = "REGISTER SUCCESS";
                }
            }
            catch
            {
                ViewBag.msg1 = "Userid Already Exit!";
            }
            return View(model);
        }
        public ActionResult pregister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult pregister(aip.Models.parent model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into parent values('" + model.userid + "','" + model.pwd + "','" + model.name + "','" + model.email + "','" + model.regno + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ViewBag.msg = "REGISTER SUCCESS";
            }
            return View(model);
        }

        public ActionResult fregister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult fregister(aip.Models.faculty model)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into faculty values('" + model.userid + "','" + model.pwd + "','" + model.name + "','" + model.email + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ViewBag.msg = "REGISTER SUCCESS";
            }
            return View(model);
        }
     public ActionResult forgotpassword()
        {
            return View();
        }
     public ActionResult pforgotpassword()
     {
         return View();
     }
     public ActionResult fforgotpassword()
     {
         return View();
     } 
	}
}