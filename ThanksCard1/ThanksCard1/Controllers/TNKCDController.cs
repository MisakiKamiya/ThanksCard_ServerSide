using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCard1.Models;

namespace ThanksCard1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TNKCDController : ControllerBase
    {
        private readonly ThanksCardContext _context;

        public TNKCDController(ThanksCardContext context)
        {
            _context = context;
        }

        #region GetThanksCards
        // GET: api/ThanksCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNKCD>>> GetThanksCards()
        {
            // Include を指定することで From, To (Userモデル) を同時に取得する。
            return await _context.TNKCDs
                                    .Include(ThanksCard => ThanksCard.EmployeeFrom)
                                    .Include(ThanksCard => ThanksCard.EmployeeTo)
                                    .Include(ThanksCard => ThanksCard.Work)
                                    .ToListAsync();
        }
        #endregion

        // POST api/ThanksCard
        [HttpPost]
        public async Task<ActionResult<TNKCD>> Post([FromBody] TNKCD thanksCard)
        {
            // From, To には既に存在しているユーザが入るため、更新の対象から外す。
            _context.Employees.Attach(thanksCard.EmployeeFrom);
            _context.Employees.Attach(thanksCard.EmployeeTo);

            _context.TNKCDs.Add(thanksCard);
            await _context.SaveChangesAsync();
            // TODO: Error Handling
            return thanksCard;
        }
    }
}
