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

        public IActionResult Delete(int id)
        {
            var expenseInDp = _expenseContext.Expensess.SingleOrDefault(expenses => expenses.ExpenseId == id);
            _expenseContext.Expensess.Remove(expenseInDp);
            _expenseContext.SaveChanges();
            return RedirectToAction("Expense");
        }

        public IActionResult Create(int? id)

        {
            if (id != null)
            {
                var expenseInDp = _expenseContext.Expensess.SingleOrDefault(expenses => expenses.ExpenseId == id);
                return View(expenseInDp);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateForm(Expense model)
        {
            if (model.ExpenseId == 0)
            {
                //create
                _expenseContext.Add(model);
            }
            else
            {
                _expenseContext.Update(model);
            }
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
