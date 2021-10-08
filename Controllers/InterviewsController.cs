using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ahad_Project.Models;

namespace Ahad_Project.Controllers
{
    public class InterviewsController : Controller
    {
        private readonly RecruitmentDBContext _context;

        public InterviewsController(RecruitmentDBContext context)
        {
            _context = context;
        }

        // GET: Interviews
        public async Task<IActionResult> Index()
        {
            var recruitmentDBContext = _context.Interviews.Include(i => i.InterviewerOneNavigation).Include(i => i.InterviewerThreeNavigation).Include(i => i.InterviewerTwoNavigation).Include(i => i.Vac);
            return View(await recruitmentDBContext.ToListAsync());
        }

        // GET: Interviews/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interviews
                .Include(i => i.InterviewerOneNavigation)
                .Include(i => i.InterviewerThreeNavigation)
                .Include(i => i.InterviewerTwoNavigation)
                .Include(i => i.Vac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // GET: Interviews/Create
        public IActionResult Create()
        {
            ViewData["InterviewerOne"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["InterviewerThree"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["InterviewerTwo"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["VacId"] = new SelectList(_context.Vacancies, "Id", "Id");
            return View();
        }

        // POST: Interviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VacId,InterviewerOne,InterviewerTwo,InterviewerThree")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterviewerOne"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerOne);
            ViewData["InterviewerThree"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerThree);
            ViewData["InterviewerTwo"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerTwo);
            ViewData["VacId"] = new SelectList(_context.Vacancies, "Id", "Id", interview.VacId);
            return View(interview);
        }

        // GET: Interviews/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }
            ViewData["InterviewerOne"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerOne);
            ViewData["InterviewerThree"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerThree);
            ViewData["InterviewerTwo"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerTwo);
            ViewData["VacId"] = new SelectList(_context.Vacancies, "Id", "Id", interview.VacId);
            return View(interview);
        }

        // POST: Interviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,VacId,InterviewerOne,InterviewerTwo,InterviewerThree")] Interview interview)
        {
            if (id != interview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterviewExists(interview.Id))
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
            ViewData["InterviewerOne"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerOne);
            ViewData["InterviewerThree"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerThree);
            ViewData["InterviewerTwo"] = new SelectList(_context.Employees, "Id", "FirstName", interview.InterviewerTwo);
            ViewData["VacId"] = new SelectList(_context.Vacancies, "Id", "Id", interview.VacId);
            return View(interview);
        }

        // GET: Interviews/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interviews
                .Include(i => i.InterviewerOneNavigation)
                .Include(i => i.InterviewerThreeNavigation)
                .Include(i => i.InterviewerTwoNavigation)
                .Include(i => i.Vac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // POST: Interviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var interview = await _context.Interviews.FindAsync(id);
            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterviewExists(byte id)
        {
            return _context.Interviews.Any(e => e.Id == id);
        }
    }
}
