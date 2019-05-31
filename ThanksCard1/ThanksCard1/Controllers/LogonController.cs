using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThanksCard1.Models;

namespace ThanksCard1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private readonly ThanksCardContext _context;

        public LogonController(ThanksCardContext context)
        {
            _context = context;
            if (_context.Employees.Count() == 0)
            {
                // Usersテーブルが空なら初期データを作成するyo。
                _context.Employees.Add(new Employee { Name = "admin", Password = "admin" });
                _context.Employees.Add(new Employee { Name = "user", Password = "user"});
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            var authorizedUser = _context.Employees.SingleOrDefault(x => x.Name == employee.Name && x.Password == employee.Password);

            if (authorizedUser == null)
            {
                return NotFound();
            }

            return authorizedUser;
        }

    }
}
