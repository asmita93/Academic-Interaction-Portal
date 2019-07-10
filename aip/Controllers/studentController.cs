using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace aip.Controllers
{
    
    public class studentController : Controller
    {
        //
        // GET: /student/
        public ActionResult studenthome()
        {
           
            return View();
        }
        public ActionResult profile()
        {

            List<aip.Models.student> imd = new List<aip.Models.student>();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student_profile where userid='"+Session["userid"]+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                imd.Add(new aip.Models.student
                {
                    userid = dr[0].ToString(),
                    img = dr[10].ToString()

                });
            }
            return View(imd);

            
        }
        [HttpPost]
        public ActionResult profile(HttpPostedFileBase file)
        {
            string img = Session["userid"]+".jpg";
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/studentimage"),
                                               Path.GetFileName(img));
                    file.SaveAs(path);

                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update student_profile set img='"+img+"' where userid='" + Session["userid"] + "'", con);
                    cmd.ExecuteNonQuery();

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.msg= "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.msg = "You have not specified a file.";
            }
            profile();
            return View();
        }

        public ActionResult inbox()
        {
            return View();
        }
        [HttpPost]
        public ActionResult inbox(aip.Models.scompose model)
        {
            string dt = DateTime.Now.ToShortDateString();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select senderid,subjects,msg from cmessage where userid='"+Session["userid"]+"'", con);
            int i = cmd1.ExecuteNonQuery();
            
            return View(model);


        }
        public ActionResult sentitem()
        {
            return View();
        }
        public ActionResult compose()
        {
            return View();
        }
        [HttpPost]
        public ActionResult compose(aip.Models.scompose model)
        {
            string dt = DateTime.Now.ToShortDateString();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kiit"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("insert into cmessage values('"+Session["userid"]+"','" + model.receiverid + "','" + model.subjects + "','" + model.msg + "','"+dt+"')", con);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                ViewBag.msg1 = "YOUR MESSAGE SENT SUCCESSFULLY";
            }
            return View(model);
           
        }
        public ActionResult dailyreport()
        {
            return View();
        }
        public ActionResult logout()
        {
            return RedirectToAction("studentlogin","ano");
        }

     
	}
}