using System.ComponentModel.DataAnnotations.Schema;
using Service.Attributes;

namespace Service.Types
{
    public class Follower
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FolloweeId { get; set; }

        [ForeignKey("FollowerId")]
        public Person FollowerA { get; set; }

        [ForeignKey("FolloweeId")]
        public Person FollowerB { get; set; }

        public Follower()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Follower(Guid followerId, Guid followeeId)
            : this()
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }
        public Follower(Person follower, Person followee)
            : this(follower.Id, followee.Id)
        {
        }
    }
}