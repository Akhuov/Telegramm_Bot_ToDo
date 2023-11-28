using Microsoft.EntityFrameworkCore;
using Telegramm_Bot_ToDo.DataContext;
using Telegramm_Bot_ToDo.DTOs;
using Telegramm_Bot_ToDo.Entities;

namespace Telegramm_Bot_ToDo.Services
{
    public class UserService
    {
        public static async ValueTask AddAsync(UserDto model)
        {
            AppDbContext context = new AppDbContext();

            var check = await context.Users.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (check == null)
            {
                User user = new User();
                user.UserId = model.UserId;
                user.firstName = model.firstName;

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

        }
    }
}
