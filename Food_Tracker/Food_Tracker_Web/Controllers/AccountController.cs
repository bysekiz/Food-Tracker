using Food_Tracker_DataAccess;
using Food_Tracker_Model;
using Food_Tracker_Web.Code;
using Food_Tracker_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food_Tracker_Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(UserModel model, FormCollection form)
        {
            string empty = "";

            if (form["Email"].Trim() != empty && form["ProfileName"].Trim() != empty)
            {
                tblUser user = new tblUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Password = model.Password;
                user.UserName = model.UserName;



                UserDAO dao = new UserDAO();
                dao.UserRegister(user);
                TempData["UserSaveSuccess"] = true;
                Session["user"] = model.UserName;
                return View();
            }

            else
            {
                if (form["UserName"].Trim() == empty && form["Email"].Trim() == empty)
                {
                    ViewBag.Error = "Kullanıcı adı ve Email boş bıralamaz.";
                }
                
                if (form["Email"].Trim() == empty && ViewBag.Error == null)
                {
                    ViewBag.Error = "Kullanıcı adı boş bıralamaz.";
                }


                return View();
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginModel model)
        {
            if (model.Email != null && model.Password !=null)
            {
                UserDAO dao = new UserDAO();
                tblUser item = dao.GetUser(model.Email,model.Password);
                if (item != null)
                {
                    Session["email"] = item.Email;
                    

                    if (item.UserName != null)
                    {
                        Session["user"] = item.UserName;
                    }
                    else
                    {
                        Session["user"] = "";
                    }

                    

                    return RedirectToAction("Home", "Index");
                }
                else
                {
                    Session["email"] = "";
                    Session["user"] = "";
                    return RedirectToAction("AddUser", "Account");

                }
            }
            else
            {
                return RedirectToAction("Home", "Index");
            }

         
        }



        public ActionResult Logout()
        {
            SessionUtil.Ins.User = null;
            return RedirectToAction("Index", "Home");
        }



        
    }
    public class SearchUserParam
    {
        public string Text { get; set; }
    }
}