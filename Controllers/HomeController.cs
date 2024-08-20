using Expenses.Data;
using Expenses.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Expenses.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ExpenseContext _expenseContext;

        public HomeController(ExpenseContext expenseContext)
        {
            _expenseContext = expenseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expense()
        {
            var data = _expenseContext.Expensess.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateForm(Expense model)
        {
            _expenseContext.Add(model);
            _expenseContext.SaveChanges();
            return RedirectToAction("Expense");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
