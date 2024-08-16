using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using C__Cumulative_1_AnmolVerma.Models;

namespace C__Cumulative_1_AnmolVerma.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            //Renders the page/ Views/Teacher/New.cshtml
            return View();
        }
        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(int teacherid, string teacherfname, string teacherlname, string employeenumber, DateTime hiredate, decimal salary)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method!");
            Debug.WriteLine(teacherid);
            Debug.WriteLine(teacherfname);
            Debug.WriteLine(teacherlname);
            Debug.WriteLine(employeenumber);
            Debug.WriteLine(hiredate);
            Debug.WriteLine(salary);


            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherId = teacherid;
            NewTeacher.TeacherFname = teacherfname;
            NewTeacher.TeacherLname = teacherlname;
            NewTeacher.EmployeeNumber = employeenumber;
            NewTeacher.HireDate = hiredate;
            NewTeacher.Salary = salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        public ActionResult UpdateConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        /// <summary>
        /// Receives a POST request containing information about an existing teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated teacher .
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="teacherfname">The updated first name of the teacher</param>
        /// <param name="teacherlname">The updated last name of the teacher</param>
        /// <param name="employeenumber">The updated employeeNumber of the teacher.</param>
        /// <param name="hiredate">The updated hiredate of the teacher.</param>
        /// <param name="salary">The updated salary of the teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/11
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Anmol",
        ///	"TeacherLname":"Verma",
        ///	"EmployeeNumber":"N01698122",
        ///	"HireDate":"10-03-1999",
        ///	"Salary":"50.50"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult UpdateConfirm(int id, string teacherfname, string teacherlname, string employeenumber, DateTime hiredate, decimal salary)
        {
            Teacher TeacherInfo = new Teacher();
           
            TeacherInfo.TeacherFname = teacherfname;
            TeacherInfo.TeacherLname = teacherlname;
            TeacherInfo.EmployeeNumber = employeenumber;
            TeacherInfo.HireDate = hiredate;
            TeacherInfo.Salary = salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }
    }
} 
        