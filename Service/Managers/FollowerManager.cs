using Microsoft.EntityFrameworkCore;
using Service.Database;
using Service.Types;

namespace Service.Managers
{
    public class FollowerManager
    {
        public static List<Follower> Load(bool includeChildren = false)
        {
            using var context = new MyDbContext();
            var data = context.Followers.AsQueryable();
            if (includeChildren)
            {
                data = data.Include(f => f.FollowerA).Include(f => f.FollowerB);
            }

            return [.. data];
        }

        public static Follower? Load(Guid id)
        {
            using var context = new MyDbContext();
            return context.Followers.FirstOrDefault(follower => follower.Id == id);
        }

        public static bool Exists(Follower follower)
        {
            using var context = new MyDbContext();
            return context.Followers.Any(f => f.FollowerId == follower.FollowerId && f.FolloweeId == follower.FolloweeId);
        }

        public static List<Follower> Find(Guid personId)
        {
            using var context = new MyDbContext();
            return [.. context.Followers.Where(f => f.FollowerId == personId).Include(f => f.FollowerB)];
        }

        public static Follower Save(Follower follower)
        {
            Follower result = follower;

            if (follower.FolloweeId == follower.FollowerId)
            {
                throw new Exception("Error: Person can not follow self.");
            }
            /*else if (!PersonManager.Exists(follower.FollowerId))
            {
                throw new Exception("Error: Invalid followerId.");
            }
            else if (!PersonManager.Exists(follower.FolloweeId))
            {
                throw new Exception("Error: Invalid followeeId.");
            }*/
            else if (Exists(follower))
            {
                throw new Exception("Error: FollowerId is already following FolloweeId.");
            }
            else
            {
                using var context = new MyDbContext();
                context.Followers.Add(follower);
                context.SaveChanges();

                // Include child records in the result.
                result.FollowerA = PersonManager.Load(result.FollowerId);
                result.FollowerB = PersonManager.Load(result.FolloweeId);

                return result;
            }
        }

        public static void Remove(Guid id)
        {
            var follower = Load(id);
            if (follower != null)
            {
                using var context = new MyDbContext();
                context.Followers.Remove(follower);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid id.");
            }
        }
    }
}