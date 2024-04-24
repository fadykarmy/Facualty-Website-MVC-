using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using The_project.Data;
using The_project.model;

namespace The_project.Controllers
{
    public class StudentCreativesController : Controller
    {
        private readonly AppDBcontext _context;
        private readonly IWebHostEnvironment _environment;


        public StudentCreativesController(AppDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: StudentCreatives
        public async Task<IActionResult> Index()
        {
              return _context.StudentCreative != null ? 
                          View(await _context.StudentCreative.ToListAsync()) :
                          Problem("Entity set 'AppDBcontext.StudentCreative'  is null.");
        }

        // GET: StudentCreatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentCreative == null)
            {
                return NotFound();
            }

            var studentCreative = await _context.StudentCreative
                .FirstOrDefaultAsync(m => m.Code == id);
            if (studentCreative == null)
            {
                return NotFound();
            }

            return View(studentCreative);
        }

        // GET: StudentCreatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentCreatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("firstName,lastName,Email")] StudentCreative studentCreative, IFormFile img_file)
        {
            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            

            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                studentCreative.studentImgae = img_file.FileName;
            }
            else
            {
                studentCreative.studentImgae = "default.jpeg"; // to save the default image path in database.
            }
            try
            {
                _context.Add(studentCreative);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }

            return View(studentCreative);



        }

        // GET: StudentCreatives/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var std = _context.StudentCreative.Where(x => x.Code == id).FirstOrDefault();
            if (std == null)
            {
                return new NotFoundResult();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(StudentCreative StudentCreative)
        {

            _context.StudentCreative.Update(StudentCreative);
            _context.SaveChanges();
            return RedirectToAction("Index");

            return View(StudentCreative);

        }

        // GET: StudentCreatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentCreative == null)
            {
                return NotFound();
            }

            var studentCreative = await _context.StudentCreative
                .FirstOrDefaultAsync(m => m.Code == id);
            if (studentCreative == null)
            {
                return NotFound();
            }

            return View(studentCreative);
        }

        // POST: StudentCreatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentCreative == null)
            {
                return Problem("Entity set 'AppDBcontext.StudentCreative'  is null.");
            }
            var studentCreative = await _context.StudentCreative.FindAsync(id);
            if (studentCreative != null)
            {
                _context.StudentCreative.Remove(studentCreative);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCreativeExists(int id)
        {
          return (_context.StudentCreative?.Any(e => e.Code == id)).GetValueOrDefault();
        }
        public IActionResult StudentS_Creativity()
        {
            return View();
        }
    }
}
