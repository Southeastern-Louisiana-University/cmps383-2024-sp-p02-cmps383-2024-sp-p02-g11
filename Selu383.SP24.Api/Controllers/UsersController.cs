using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Data;
using Selu383.SP24.Api.Features.Users;

namespace Selu383.SP24.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DbSet<User> users;
    private readonly DataContext dataContext;

    public UsersController(DataContext dataContext)
    {
        this.dataContext = dataContext;
        users = dataContext.Set<User>();
    }

    [HttpGet]
    public IQueryable<UserDto> GetAllUsers()
    {
        return GetUserDto(users);
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult<UserDto> GetUserById(int id)
    {
        var result = GetUserDto(users.Where(x => x.Id == id)).FirstOrDefault();
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpPost]
    public ActionResult<UserDto> CreateUser(UserDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.UserName,
        };
        users.Add(user);
        dataContext.SaveChanges();
        dto.Id = user.Id;
        return CreatedAtAction(nameof(GetUserById), new { id = dto.Id }, dto);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<UserDto> UpdateUser(int id, UserDto dto)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.UserName = dto.UserName;

        dataContext.SaveChanges();
        dto.Id = user.Id;
        return Ok(dto);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        users.Remove(user);

        dataContext.SaveChanges();

        return Ok();
    }










    private static IQueryable<UserDto> GetUserDto(IQueryable<User> users)
    {
        return users
            .Select(x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                //Roles = x.Role,
            });
    }
}
