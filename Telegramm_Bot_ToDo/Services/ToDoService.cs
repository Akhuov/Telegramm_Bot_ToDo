using Microsoft.EntityFrameworkCore;
using Telegramm_Bot_ToDo.DataContext;
using Telegramm_Bot_ToDo.Entities;

namespace Telegramm_Bot_ToDo.Services
{
    public class ToDoService
    {
        private static AppDbContext _context { get; set; }
        public ToDoService(AppDbContext context)
        {
            _context = context;
        }

        public static async ValueTask AddAsync(string description, long UserId)
        {

            ToDos toDo = new ToDos();
            toDo.Description = description;
            toDo.Date = DateTime.Now;
            toDo.UserId = UserId;

            await _context.ToDo.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public static async ValueTask<IEnumerable<ToDos>> GetAllAsync()
        {

            IEnumerable<ToDos> todos = await _context.ToDo.Where(x => x.Date.DayOfYear - DateTime.Now.DayOfYear > -3).ToListAsync();

            return todos;
        }
        public static async ValueTask<IEnumerable<ToDos>> Archive()
        {

            IEnumerable<ToDos> todos = await _context.ToDo.Where(x => x.Date.DayOfYear - DateTime.Now.DayOfYear < -3).ToListAsync();

            return todos;
        }
    }
}
