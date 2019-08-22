using DataAccessLayer;
using MySomething.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MySomething.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
           
            UserViewModel model = new UserViewModel();
           
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel usr)
        {

            if (!ModelState.IsValid)
            {
                return View(usr);
            }
            //User userDataModel = new User();
            //userDataModel.CreateDate = usr.CreateDate;
            //userDataModel.IsDeleted =false;
            //userDataModel.Name = usr.Name;
            //userDataModel.Password = usr.Password;
            //userDataModel.Surname = usr.Surname;
            //userDataModel.Type = usr.Type;
            //userDataModel.UserName = usr.Username;

            User userDataModel = new User();
            string serializedStr = JsonConvert.SerializeObject(usr);
            userDataModel = JsonConvert.DeserializeObject<User>(serializedStr);

            UserRepository rep = new UserRepository();
            rep.Add(userDataModel);
            return RedirectToAction("Index");
            
        }
    }
}