
using Domains.Dtos;
using Domains.Entities;
using Domains.Interfaces;
using Services;
using System.Threading.Tasks;

namespace Level2Project.Controllers;

public class UsersController : Controller
{
    private readonly IUser _userService;

    public UsersController(IUser userService)
    {
        _userService = userService;
    }

    public IActionResult Add()
    {
        var addUserResponse = new AddUserResponseDto();
        return View(addUserResponse);
    }

    public async Task<IActionResult> Manage()
    {
        var result = await _userService.GetAllAsync();
        return View(result);
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var addUserResponse = await _userService.GetByIdAsync(id);
        if (addUserResponse == null)
            return NoContent();

        return View(addUserResponse);
    }


    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserRequestDto request)
    {
        var response = await _userService.AddAsync(request);
        return View("Add", response);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateUser(User user)
    {
        await _userService.UpdateAsync(user);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteAsync(id);
        return View();
    }
}

