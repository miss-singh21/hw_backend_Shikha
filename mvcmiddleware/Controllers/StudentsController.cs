using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Middlware.Models;

namespace Middlware.Controllers
{
    [HandleError]
    public class StudentsController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                IEnumerable<StudentModel> stdObj;
                HttpResponseMessage response = GlobalVariables.apiClient.GetAsync("Students").Result;
                stdObj = response.Content.ReadAsAsync<IEnumerable<StudentModel>>().Result;
                return View(stdObj);
            }catch(Exception ex)
            {
                return View("Error.cshtml");
            }
        }
        public ActionResult PutStudent(int id=0)
        {
            if (id == 0)
            {
                return View(new StudentModel());
            }
            else
            {
                HttpResponseMessage respo = GlobalVariables.apiClient.GetAsync("Students/"+id.ToString()).Result;
                return View(respo.Content.ReadAsAsync<StudentModel>().Result);
             }
        }
       [HttpPost]
       public ActionResult PutStudent(StudentModel std)
        {
            IEnumerable<StudentModel> stdObj;
            HttpResponseMessage response = GlobalVariables.apiClient.GetAsync("Students").Result;
            stdObj = response.Content.ReadAsAsync<IEnumerable<StudentModel>>().Result;
            if (!stdObj.Any(x=>x.ID==std.ID)) {
                HttpResponseMessage res = GlobalVariables.apiClient.PostAsJsonAsync("Students", std).Result;
           }
            else
            {
                HttpResponseMessage res = GlobalVariables.apiClient.PutAsJsonAsync("Students/" + std.ID, std).Result;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
                HttpResponseMessage response = GlobalVariables.apiClient.DeleteAsync("Students/" + id).Result;
                return RedirectToAction("Index");
        }
    }
}
