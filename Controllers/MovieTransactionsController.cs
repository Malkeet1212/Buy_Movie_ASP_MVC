using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using Buy_Movies_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Buy_Movies_MVC.Controllers
{

    //Movie transactions management using authorization 
    [Authorize]
    public class MovieTransactionsController : Controller
    {
        private readonly Buy_Movies_MVCDatabaseContext _context;

        public MovieTransactionsController(Buy_Movies_MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: MovieTransactions
        //Gets all movie transactions using a lamda query.
        public IActionResult Index()
        {
            var buy_Movies_MVCDatabaseContext = _context.MovieTransaction.Include(m => m.Customer).Include(m => m.Movie);
            return View( buy_Movies_MVCDatabaseContext.ToList());
        }

        // GET: MovieTransactions/Details/5
        //Gets transaction  details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTransaction =  _context.MovieTransaction
                .Include(m => m.Customer)
                .Include(m => m.Movie)
                .FirstOrDefault(m => m.Id == id);
            if (movieTransaction == null)
            {
                return NotFound();
            }

            return View(movieTransaction);
        }

        // GET: MovieTransactions/Create
        //Gets create transaction form.
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName");
            return View();
        }

        // POST: MovieTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  a transaction to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieId,CustomerId")] MovieTransaction movieTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieTransaction);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", movieTransaction.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName", movieTransaction.MovieId);
            return View(movieTransaction);
        }

        // GET: MovieTransactions/Edit/5
        //Gets a transaction for update. using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTransaction = (from transaction in _context.MovieTransaction
                                    where transaction.Id == id
                                    select transaction).FirstOrDefault();
            if (movieTransaction == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", movieTransaction.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName", movieTransaction.MovieId);
            return View(movieTransaction);
        }

        // POST: MovieTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the transaction.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,MovieId,CustomerId")] MovieTransaction movieTransaction)
        {
            if (id != movieTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieTransaction);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieTransactionExists(movieTransaction.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", movieTransaction.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName", movieTransaction.MovieId);
            return View(movieTransaction);
        }

        // GET: MovieTransactions/Delete/5
        //Gets the transaction for delete using a lamda query
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTransaction =  _context.MovieTransaction
                .Include(m => m.Customer)
                .Include(m => m.Movie)
                .FirstOrDefault(m => m.Id == id);
            if (movieTransaction == null)
            {
                return NotFound();
            }

            return View(movieTransaction);
        }

        // POST: MovieTransactions/Delete/5
        //Deletes the transaction uses a linq query to select the transaction.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movieTransaction = (from transaction in _context.MovieTransaction
                                    where transaction.Id == id
                                    select transaction).FirstOrDefault();
            _context.MovieTransaction.Remove(movieTransaction);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the transaction using a lamda query.
        private bool MovieTransactionExists(int id)
        {
            return _context.MovieTransaction.Any(e => e.Id == id);
        }
    }
}
