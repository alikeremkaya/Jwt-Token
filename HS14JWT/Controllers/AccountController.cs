using HS14JWT.DTOs;
using HS14JWT.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HS14JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Register([FromServices] UserManager<IdentityUser>userManager,RegisterDTO registerDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = new IdentityUser()
        {
            Email = registerDTO.Email,
            UserName = registerDTO.Password,

        };
        var identityCreateResult= await userManager.CreateAsync(user,registerDTO.Password);
        if (!identityCreateResult.Succeeded)
        {
            return BadRequest(new AccountResult
            {
                IsSuccess = false,
                Message=identityCreateResult.ToString()
            });
              
                   

        }
        return Ok(new AccountResult
        { 
            IsSuccess = true, 
            Message="Kullanıcı Oluşturma Başarılı"
        
        });

    }
    
}
