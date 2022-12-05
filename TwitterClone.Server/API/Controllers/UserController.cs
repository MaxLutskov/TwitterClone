using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Extension;
using TwitterClone.Business.IRepositories;
using TwitterClone.Business.Models;
using TwitterCloneMSSQL.Repositories;

namespace TwitterClone.Server.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository!;
        }

        [HttpPost("create"), Authorize]
        public async Task<IActionResult> CreateAsync(UserModel model)
        {
            if (model != null) {
                await repository.CreateAsync(model);
                return Ok(model);
            }
            return NoContent();
        }

        [HttpPut("update"), Authorize]
        public async Task<IActionResult> UpdateAsync(UserModel model)
        {
            if (model == null)
                return new JsonResult(NoContent());

            var oldModel = await repository.GetByIdAsync(model.Id);
            if (model == oldModel)
                return new JsonResult(Problem("Models are same"));

            repository.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("delete"), Authorize]
        public IActionResult Delete(Guid id)
        {
            repository.Delete(id);
            return Ok("Object deleted");
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var model = await repository.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpGet("getAll"), Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await repository.GetAllAsync();
            return Ok(models);
        }
    }
}
