
using Domains.Entities;
using Level2Project.Models;
using Services;
using System.Threading.Tasks;

namespace Level2Project.Controllers;

public class UsersController : Controller
{
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {
        UserService userService = new UserService();
        await userService.AddAsync(user);

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> UpdateUser(User user)
    {
        UserService userService = new UserService();
        await userService.UpdateAsync(user);

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        UserService userService = new UserService();
        await userService.DeleteAsync(id);

        return View();
    }
}

