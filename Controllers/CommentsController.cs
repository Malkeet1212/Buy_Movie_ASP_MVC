using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using Buy_Movies_MVC.Models;

namespace Buy_Movies_MVC.Controllers
{
    //Manages customer comments.
    public class CommentsController : Controller
    {
        private readonly Buy_Movies_MVCDatabaseContext _context;

        public CommentsController(Buy_Movies_MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: Comments
        //Gets all customer commenst using a lamda query.
        public IActionResult Index()
        {
            var buy_Movies_MVCDatabaseContext = _context.Comment.Include(c => c.Customer);
            return View( buy_Movies_MVCDatabaseContext.ToList());
        }

        // GET: Comments/Details/5
        //Gets details of a comment using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment =  _context.Comment
                .Include(c => c.Customer)
                .FirstOrDefault(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        //Gets the create comment form.
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a comment to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CustomerId,CommentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName", comment.CustomerId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        //Gets the comment for udpdate using a linq query. 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = (from comments in _context.Comment
                           where comments.Id == id
                           select comments).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName", comment.CustomerId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the comment on database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CustomerId,CommentText")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName", comment.CustomerId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        //Gets a comment for delete using a llamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment =  _context.Comment
                .Include(c => c.Customer)
                .FirstOrDefault(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        //Deletes a comment uses a linq query to select the comment.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = (from comments in _context.Comment
                           where comments.Id == id
                           select comments).FirstOrDefault();
            _context.Comment.Remove(comment);
           _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the comments using a lamda query.
        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
