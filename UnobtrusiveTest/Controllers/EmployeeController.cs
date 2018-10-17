using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnobtrusiveTest.Models.Employee;

namespace UnobtrusiveTest.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly Dictionary<string, string> initialForms = new Dictionary<string, string>() {
        //    { "Name", "_nameform"},
        //    { "Address", "_addressform"},
        //    { "Additional", "_additionalform"}
        //};


        //private readonly string[,] initialForms = new string[3, 2] {
        //    { "Name", "_nameform"},
        //    { "Address", "_addressform"},
        //    { "Additional", "_additionalform"}
        //};



        //public Dictionary<string, string> NextForm { get; set; }
        //public Dictionary<string, string> PrevieousForm { get; set; }


        LinkedList<FormViewData> initialForms = new LinkedList<FormViewData>();
        







        private FormViewData NextForm(string currentForm)
        {
            var formValue = initialForms.FirstOrDefault(f => f.FormName == currentForm);
            var current = initialForms.Find(formValue);

            var nextRow = current.Next;

            // See if at last of linked list
            if (nextRow != null)
            {
                var priorRow = initialForms.Find(nextRow.Value);
                var peekRow = priorRow.Next;
                nextRow.Value.Last = peekRow == null ? true : false;
            }

            return nextRow != null ? nextRow.Value : current.Value;

            //return current.Value;
        }


        private FormViewData PreviousForm(string currentForm)
        {

            var formValue = initialForms.FirstOrDefault(f => f.FormName == currentForm);
            var current = initialForms.Find(formValue);

            var prevRow = current.Previous;

            // See if at first of linked list
            if (prevRow != null)
            {
                var priorRow = initialForms.Find(prevRow.Value);
                var peekRow = priorRow.Previous;
                prevRow.Value.First = peekRow == null ? true : false;
            }

            return prevRow != null ? prevRow.Value : current.Value;
        }



        public EmployeeController()
        {
            //string nextForm = NextForm("Address");

            // Load Linked List
            initialForms.AddLast(new FormViewData() { FormName = "Name", ViewName = "_nameView"});
            initialForms.AddLast(new FormViewData() { FormName = "Address", ViewName = "_addressView" });
            initialForms.AddLast(new FormViewData() { FormName = "Additional", ViewName = "_additionalView" });

            //TODO  set First and Last row to "True";

            FormViewData nextRow = NextForm("Address");
            nextRow = NextForm(nextRow.FormName);
            nextRow = NextForm(nextRow.FormName);

            nextRow = PreviousForm(nextRow.FormName);
            nextRow = PreviousForm(nextRow.FormName);
            nextRow = PreviousForm(nextRow.FormName);


        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult _PartialName(Employee employee)
        {
            //...
            //db.BookMasters.Add(one);
            //db.SaveChanges();

            //if (!ModelState.IsValid)
            //{
            //    //return PartialView("Index");
            //    return PartialView("Index", employee);
            //}


            return PartialView("_PartialAddress", employee);
        }

        [HttpPost]
        public PartialViewResult _PartialAddress(string button, string next, string prev, Employee employee)
        {


            switch (button)
            {
                case "Start PREV":
                    break;
                case "Additional Info NEXT":
                    break;
                default:
                    break;
            }

            //...
            //db.Publisher.Add(two);
            //db.SaveChanges();
            return PartialView("_PartialAdditional");
        }

        [HttpPost]
        public ActionResult _PartialAdditional(Employee employee)
        {
            //...
            //db.Students.Add(Three);
            //db.SaveChanges();
            return RedirectToAction("Index", "Home");   //done
        }
    }



    public class FormViewData
    {
        public string FormName { get; set; }

        public string ViewName { get; set; }


        public bool First { get; set; }
        public bool Last { get; set; }
    }


}