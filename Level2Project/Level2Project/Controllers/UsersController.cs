
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

    public async Task<IActionResult> Manage(string? query)
    {
        var result = await _userService.GetAllAsync(query);
        return View(result);
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var addUserResponse = await _userService.GetByIdAsync(id);
        if (addUserResponse == null)
            return NoContent();

        var updateUserInfoDto = new UpdateUserInfoDto();
        updateUserInfoDto.GetUserInfoResponseDto = addUserResponse;
        updateUserInfoDto.AddUserResponseDto = new AddUserResponseDto();


        return View(updateUserInfoDto);
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
        var  result =  await _userService.UpdateAsync(user);
        var updateUserInfoDto = new UpdateUserInfoDto();


        updateUserInfoDto.GetUserInfoResponseDto = new GetUserInfoResponseDto(); 
         

        if (result.Status == Domains.Enums.OpStatus.Success)
        {
            var userInfo = await _userService.GetByIdAsync(user.Id);
            updateUserInfoDto.GetUserInfoResponseDto = userInfo;
            updateUserInfoDto.AddUserResponseDto = result;
        }

        return View("Update", updateUserInfoDto);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteAsync(id);
        return RedirectToAction("Manage");
    }
}

