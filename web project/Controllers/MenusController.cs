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
	public class MenusController : Controller
	{
		private readonly web_projectContext _context;

		public MenusController(web_projectContext context)
		{
			_context = context;
		}

		// GET: Menus
		public async Task<IActionResult> Index()
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return View(await _context.Menu.ToListAsync());
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
		}

		// GET: Menus/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				if (id == null)
			{
				return NotFound();
			}

			var menu = await _context.Menu
				.FirstOrDefaultAsync(m => m.id == id);
			if (menu == null)
			{
				return NotFound();
			}

			return View(menu);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
		}

		// GET: Menus/Create
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
				return RedirectToAction("LoginAdmin", "Home");
			}
			
		}

		// POST: Menus/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("id,Image,DishName,DishDiscription,Price,DishTypee")] Menu menu)
		{
			if (HomeController.isLoggedIn)
			{ViewData["login"] = HomeController.isLoggedIn;
				if (ModelState.IsValid)
			{
				_context.Add(menu);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
				return View(menu);
				
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
			

		}

		// GET: Menus/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
					if (id == null)
			{
				return NotFound();
			}

			var menu = await _context.Menu.FindAsync(id);
			if (menu == null)
			{
				return NotFound();
			}
			return View(menu);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
		
		}

		// POST: Menus/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("id,Image,DishName,DishDiscription,Price,DishTypee")] Menu menu)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				if (id != menu.id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(menu);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MenuExists(menu.id))
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
			return View(menu);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
		}

		// GET: Menus/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;
				if (id == null)
			{
				return NotFound();
			}

			var menu = await _context.Menu
				.FirstOrDefaultAsync(m => m.id == id);
			if (menu == null)
			{
				return NotFound();
			}

			return View(menu);
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
		}

		// POST: Menus/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (HomeController.isLoggedIn)
			{
				ViewData["login"] = HomeController.isLoggedIn;var menu = await _context.Menu.FindAsync(id);
			if (menu != null)
			{
				_context.Menu.Remove(menu);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
				
			}
			else
			{
				ViewData["login"] = HomeController.isLoggedIn;
				return RedirectToAction("LoginAdmin", "Home");
			}
			
		}

		private bool MenuExists(int id)
		{
			return _context.Menu.Any(e => e.id == id);
		}
	}
}