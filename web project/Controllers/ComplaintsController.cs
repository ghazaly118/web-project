using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_project.Data;
using web_project.Models;

namespace web_project.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly web_projectContext _context;
       

        public ComplaintsController(web_projectContext context)
        {
            _context = context;
        }

        // GET: Complaints
        public async Task<IActionResult> Index()
        {
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
                return View(await _context.Complaints.ToListAsync());
			
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
        }

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				if (id == null)
            {
                return NotFound();
            }

            var complaints = await _context.Complaints
                .FirstOrDefaultAsync(m => m.id == id);
            if (complaints == null)
            {
                return NotFound();
            }

            return View(complaints);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
        }

        // GET: Complaints/Create
        public IActionResult Create()
        {
            if (HomeController.isLoggedIn)
            {
                ViewData["login"] = HomeController.isLoggedIn;

                return View();
            }
            else
            {
                ViewData["login"] = HomeController.isLoggedIn;
                return View();


            }
        }
        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Email,Number,Complaint,City")] Complaints complaints)
        {
            if (complaints.FirstName != null )
            {
                if (complaints.FirstName.Length < 3) {
                ModelState.AddModelError("FirstName", "First name must contain more than three characters.");
            } }
            else
            {
                complaints.FirstName = "";
                ModelState.AddModelError("FirstName", "First name must contain more than three characters.");
            }
            if (complaints.LastName != null)
            {
                if (complaints.LastName.Length < 3)
                {
                    ModelState.AddModelError("LastName", "last name must contain more than three characters.");
                }
            }
            else
            {
                complaints.LastName = "";
                ModelState.AddModelError("LastName", "last name must contain more than three characters.");
            }
            if (complaints.Complaint != null )
            {
                if (complaints.Complaint.Length < 10)
                {


                    ModelState.AddModelError("Complaint", "Complainte must contain more than three characters.");
                } }
            else
            {
                complaints.Complaint = "";
                ModelState.AddModelError("Complaint", "Complaint must contain more than ten characters.");
            }
            if (complaints.City != null )
            {
                if (complaints.City.Length < 4) {
                    ModelState.AddModelError("City", "City must contain more than four characters.");
                }
            }
            else
            {
                complaints.City = "";
                ModelState.AddModelError("City", "City must contain more than three characters.");
            }
            if (ModelState.IsValid)
            {
                _context.Add(complaints);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            return View(complaints);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				if (id == null)
				{
					return NotFound();
				}

				var complaints = await _context.Complaints.FindAsync(id);
				if (complaints == null)
				{
					return NotFound();
				}
				return View(complaints);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
		
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Email,Number,Complaint,City")] Complaints complaints)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
			if (id != complaints.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaints);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintsExists(complaints.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(complaints);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
if (id == null)
            {
                return NotFound();
            }

            var complaints = await _context.Complaints
                .FirstOrDefaultAsync(m => m.id == id);
            if (complaints == null)
            {
                return NotFound();
            }

            return View(complaints);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var complaints = await _context.Complaints.FindAsync(id);
            if (complaints != null)
            {
                _context.Complaints.Remove(complaints);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintsExists(int id)
        {
            return _context.Complaints.Any(e => e.id == id);
        }
    }
}
