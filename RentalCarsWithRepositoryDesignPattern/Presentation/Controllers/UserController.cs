using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService) 
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDto userDto)
    {
        var user = await _userService.Add(userDto);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var listUser = await _userService.GetAll();
        return Ok(listUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        if (id <= 0)
        {
            return Forbid("Id must be a positive number!");
        }
        var isDeleted = await _userService.Delete(id);

        if (isDeleted)
        {
            return Ok($"User with id: {id} was deleted correctly!");
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UserUpdateDto userDto)
    {
        if (id <= 0)
        {
            return Forbid("Id must be a positive number!");
        }
        var isUpdated = await _userService.Update(id, userDto);

        if (isUpdated)
        {
            return Ok($"User with id: {id} was updated correctly!");
        }

        return NotFound("User not found or no changes applied.");
    }
}
