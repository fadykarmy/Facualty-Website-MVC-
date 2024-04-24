using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using The_project.Data;
using The_project.model;
using The_project.Models;

namespace The_project.Controllers
{

    public class HomeController : Controller
    {
        private  AppDBcontext db;
        public HomeController(AppDBcontext db)
        {
           this.db = db;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet] 
        public IActionResult student()
        {
            return View(new Student());
        }
        [HttpPost]
        public IActionResult student(Student src)
        {
            
                db.Students.Add(src);
                db.SaveChanges();
                return RedirectToAction("services" ,"Home");
            
            return View(src);
        }

        [HttpGet]
        public IActionResult Enrollment()
        {
            return View(new Enrollment());
        }
        [HttpPost]
        public IActionResult Enrollment(Enrollment src)
        {
            

                db.Enrollments.Add(src);
                db.SaveChanges();
                return RedirectToAction("services", "Home");
            
            return View(src);
           
        }
        [HttpGet]
        public IActionResult Department()
        {
            return View(new Department()); 
        }
        [HttpPost]
        public IActionResult Department(Department src)
        {
           

                db.Departments.Add(src);
                db.SaveChanges();
                return RedirectToAction("services", "Home");
            
            return View(src);
        }
        public IActionResult show_student()
        {
            List<Student> st = db.Students.ToList();

            return View(st);
        }
        public IActionResult show_Enrollment()
        {
            List<Enrollment> st = db.Enrollments.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Enrollment(int id)
        {
            var std = db.Enrollments.Where(x => x.EnrollmentID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Enrollment(Enrollment Enrollment)
        {

            db.Enrollments.Update(Enrollment);
            db.SaveChanges();
            return RedirectToAction("show_Enrollment");

            return View(Enrollment);

        }
        public IActionResult Delete_Enrollment(int id)
        {
            var std = db.Enrollments.Where(x => x.EnrollmentID == id).FirstOrDefault();
            db.Enrollments.Remove(std);
            db.SaveChanges();
            return RedirectToAction("show_Enrollment");
        }
        [HttpGet]
        public IActionResult Edit_student(int id)
        {
            var std = db.Students.Where(x => x.Student_ID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_student(Student student)
        {
            
                db.Students.Update(student);
                db.SaveChanges();
                return RedirectToAction("show_student");
            
            return View(student);

        }
        public IActionResult Delete_student(int id)
        {
            var std = db.Students.Where(x => x.Student_ID == id).FirstOrDefault();
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("show_student");
        }

            public IActionResult show_Department()
        {
            List<Department> st = db.Departments.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Department(int id)
        {
            var std = db.Departments.Where(x => x.Department_ID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Department(Department Department)
        {

            db.Departments.Update(Department);
            db.SaveChanges();
            return RedirectToAction("show_Department");

            return View(Department);

        }
        public IActionResult Delete_Department(int id)
        {
            var std = db.Departments.Where(x => x.Department_ID == id).FirstOrDefault();
            db.Departments.Remove(std);
            db.SaveChanges();
            return RedirectToAction("show_Department");
        }
        public IActionResult about()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add_course()
        {
            return View(new Course());
        }
        [HttpPost]
        public IActionResult Add_course(Course str)
        {


            db.Courses.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        public IActionResult course()
        {
            List < Course> st = db.Courses.ToList();
            return View(st);
        }
        public IActionResult course_1()
        {
            List<Course> st = db.Courses.ToList();
            return View(st);
        }
        public IActionResult course_2()
        {
            List<Course> st = db.Courses.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_course(int id)
        {
            var std = db.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_course(Course Course)
        {

            db.Courses.Update(Course);
            db.SaveChanges();
            return RedirectToAction("course");

            return View(Course);

        }
        public IActionResult Delete_course(int id)
        {
            var std = db.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            db.Courses.Remove(std);
            db.SaveChanges();
            return RedirectToAction("course");
        }

        public IActionResult services()
        {
            var username = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult Admin_services()
        {
            var useradmin = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(useradmin))
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Add_Engineer()
        {
            return View(new Engineer());
        }
        [HttpPost]
        public IActionResult Add_Engineer(Engineer str)
        {


            db.Engineers.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        public IActionResult Engineer()
        {
            List<Engineer> st = db.Engineers.ToList();
            return View(st);
        }
        public IActionResult Engineer_1()
        {
            List<Engineer> st = db.Engineers.ToList();
            return View(st);
        }
        public IActionResult Engineer_2()
        {
            List<Engineer> st = db.Engineers.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Engineer(int id)
        {
            var std = db.Engineers.Where(x => x.Engineer_ID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Engineer(Engineer Engineer)
        {

            db.Engineers.Update(Engineer);
            db.SaveChanges();
            return RedirectToAction("show_Engineer");

            return View(Engineer);

        }
        public IActionResult Delete_Engineer(int id)
        {
            var std = db.Engineers.Where(x => x.Engineer_ID == id).FirstOrDefault();
            db.Engineers.Remove(std);
            db.SaveChanges();
            return RedirectToAction("show_Engineer");
        }
      
        [HttpGet]
        public IActionResult Add_Lecture()
        {
            return View(new Lecture());
        }
        [HttpPost]
        public IActionResult Add_Lecture(Lecture str)
        {


            db.Lectures.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        public IActionResult Lecture_1()
        {
            List<Lecture> st = db.Lectures.ToList();
            return View(st);
        }
        public IActionResult Lecture_2()
        {
            List<Lecture> st = db.Lectures.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Lecture(int id)
        {
            var std = db.Lectures.Where(x => x.LectureID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Lecture(Lecture Lecture)
        {

            db.Lectures.Update(Lecture);
            db.SaveChanges();
            return RedirectToAction("Lecture");

            return View(Lecture);

        }
        public IActionResult Delete_Lecture(int id)
        {
            var std = db.Lectures.Where(x => x.LectureID == id).FirstOrDefault();
            db.Lectures.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Lecture");
        }
        public IActionResult Lecture()
        {
            List<Lecture> st = db.Lectures.ToList();
            return View(st);
        }
        public IActionResult Professor_1()
        {
            List<Professor> st = db.Professors.ToList();
            return View(st);
        }
        public IActionResult Professor_2()
        {
            List<Professor> st = db.Professors.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Professor(int id)
        {
            var std = db.Professors.Where(x => x.ProfessorID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Professor(Professor Professor)
        {

            db.Professors.Update(Professor);
            db.SaveChanges();
            return RedirectToAction("Professor");

            return View(Professor);

        }
        public IActionResult Delete_Professor(int id)
        {
            var std = db.Professors.Where(x => x.ProfessorID == id).FirstOrDefault();
            db.Professors.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Professor");
        }
        [HttpGet]
        public IActionResult Add_Professor()
        {
            return View(new Professor());
        }
        [HttpPost]
        public IActionResult Add_Professor(Professor str)
        {


            db.Professors.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        public IActionResult Professor()
        {
            List<Professor> st = db.Professors.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Add_Section()
        {
            return View(new Section());
        }
        [HttpPost]
        public IActionResult Add_Section(Section str)
        {


            db.Sections.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        public IActionResult Section_1()
        {
            List<Section> st = db.Sections.ToList();
            return View(st);
        }
        public IActionResult Section_2()
        {
            List<Section> st = db.Sections.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Edit_Section(int id)
        {
            var std = db.Sections.Where(x => x.SectionID == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit_Section(Section Section)
        {

            db.Sections.Update(Section);
            db.SaveChanges();
            return RedirectToAction("Section");

            return View(Section);

        }
        public IActionResult Delete_Section(int id)
        {
            var std = db.Sections.Where(x => x.SectionID == id).FirstOrDefault();
            db.Sections.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Section");
        }
        public IActionResult Section()
        {
            List<Section> st = db.Sections.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Add_Lab()
        {
            return View(new Lab());
        }
        [HttpPost]
        public IActionResult Add_Lab(Lab str)
        {


            db.Labs.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }
        [HttpGet]
        public IActionResult Add_Coliseum()
        {
            return View(new Coliseum());
        }
        [HttpPost]
        public IActionResult Add_Coliseum(Coliseum str)
        {


            db.Coliseums.Add(str);
            db.SaveChanges();
            return RedirectToAction("Admin_services", "Home");

            return View(str);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}