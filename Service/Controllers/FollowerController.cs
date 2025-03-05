using Microsoft.AspNetCore.Mvc;
using Service.Managers;
using Service.Types;

namespace Followers2.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowerController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Index(bool? includeDetails)
        {
            var followers = FollowerManager.Load(includeDetails.GetValueOrDefault());
            return new JsonResult(followers);
        }

        [HttpGet("{personId}")]
        public IActionResult Index(Guid personId)
        {
            var followers = FollowerManager.Find(personId);
            return new JsonResult(followers);
        }

        [HttpPost()]
        public IActionResult Index(Follow follow)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Follower follower = new Follower(follow.FollowerId, follow.FolloweeId);
                    return new JsonResult(FollowerManager.Save(follower));
                }
                catch (Exception excep)
                {
                    return BadRequest(excep.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                FollowerManager.Remove(id);
                return new JsonResult(id);
            }
            catch (Exception excep)
            {
                return NotFound(excep.Message);
            }
        }
    }
}