using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.IRepositories;
using TwitterClone.Business.Models;
using TwitterClone.Server.API.Controllers.DTO.Tweets;
using TwitterClone.Server.Extensions;

namespace TwitterClone.Server.API.Controllers
{
    [Route("api/tweets")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetRepository tweetRepository;
        private readonly IUserRepository userRepository;
        public TweetController(ITweetRepository tweetRepository, IUserRepository userRepository)
        {
            this.tweetRepository = tweetRepository;
            this.userRepository = userRepository;
        }

        [HttpPost("create"), Authorize]
        public async Task<IActionResult> CreateAsync(TweetInput input)
        {
            if (input == null)
                return NoContent();
            var model = input.ToModel();
            model.UserId = HttpContext.GetUserId();
            var user = await userRepository.GetByIdAsync(model.UserId);
            if (user == null)
                return BadRequest();

            model.UniqueName = user.UniqueName;
            model.UserName = user.UserName;

            model = await tweetRepository.CreateAsync(model);
            return Ok(model);
            
        }

        [HttpPut("update"), Authorize]
        public async Task<IActionResult> UpdateAsync(TweetModel model)
        {
            if (model == null)
                return NoContent();

            var oldModel = await tweetRepository.GetByIdAsync(model.Id);

            if (model == oldModel)
                return Problem("Models are same");

            var newModel = tweetRepository.Update(model);
            return Ok(newModel);
        }

        [HttpDelete("delete"), Authorize]
        public IActionResult Delete(Guid id)
        {
            tweetRepository.Delete(id);
            return Ok("Object deleted");
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var model = await tweetRepository.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpGet("getAll"), Authorize]
        public async Task<IActionResult> GetAllAsync(int pageSize, int page)
        {
            var models = await tweetRepository.GetAllAsync(pageSize, page);
            return Ok(models);
        }

        [HttpGet("{userId}"), Authorize]
        public async Task<IActionResult> GetUsersTweets(Guid userId, int pageSize, int page)
        {
            var models = await tweetRepository.GetByUserIdAsync(userId, pageSize, page);
            return Ok(models);
        }
    }
}
