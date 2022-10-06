using Blazor.Modals;
using BlazorBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var user = await _dataContext.USers.ToListAsync();
            return Ok(user);
        }
        [HttpGet("comic")]
        public async Task<ActionResult<Comic>> GetComic()
        {
            var comics = await _dataContext.Comics.ToListAsync();
            return Ok(comics);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetOnlyOneUser(int id)
        {
            var oneUser = await _dataContext.USers.FirstOrDefaultAsync(h => h.Id == id);
            if (oneUser == null)
            {
                return NotFound("sorry! Data is null!");
            }
            return Ok(oneUser);
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateNewUser(User user)
        {
            user.Commic = null;
            _dataContext.USers.Add(user);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDbUsers());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var updateDb = await _dataContext.USers.Include(sh => sh.Commic).FirstOrDefaultAsync(h => h.Id == user.Id);
            if (updateDb == null)
            {
                return NotFound("Sorry! Data is null");
            }
            updateDb.FirstName = user.FirstName;
            updateDb.LastName = user.LastName;
            updateDb.Email = user.Email;
            updateDb.ComicId = user.ComicId;

            await _dataContext.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var deleteUser = await _dataContext.USers.Include(sh => sh.Commic).FirstOrDefaultAsync(h => h.Id == id);
            if (deleteUser == null)
            {
                return NotFound("Not found!");
            }
            _dataContext.USers.Remove(deleteUser);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDbUsers());
        }
        private async Task<List<User>> GetDbUsers()
        {
            return await _dataContext.USers.Include(h => h.Commic).ToListAsync();
        }
    }
}
