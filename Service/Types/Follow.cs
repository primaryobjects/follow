using System.ComponentModel.DataAnnotations;
using Service.Attributes;

namespace Service.Types
{
    public class Follow
    {
        [Required]
        [ValidFollowerId]
        public Guid FollowerId { get; set; }
        [Required]
        [ValidFollowerId]
        public Guid FolloweeId { get; set; }

        public Follow()
        {
        }

        public Follow(Guid followerId, Guid followeeId)
            : this()
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }
    }
}