using Application.LogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController: ControllerBase
{
    private readonly IPostLogic PostLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.PostLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreationDto dto)
    {
        try
        {
            Post created = await PostLogic.CreateAsync(dto);
            return Created($"/posts/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
        [FromQuery] string? contextContains, [FromQuery] string? titleContains, [FromQuery] int? postId )
    {
        try
        {
            SearchPostParametersDto parameters = new(userName, userId, contextContains, titleContains, postId);
            var todos = await PostLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}