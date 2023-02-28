using Microsoft.EntityFrameworkCore;

namespace VanCityFood.Models
{
    public class Context :DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }

        public void DenoteUserModified(User user)
        {
            Entry(user).State = EntityState.Modified;
        }

        public void DenoteRestaurantModified(Restaurant rest)
        {
            Entry(rest).State = EntityState.Modified;
        }

        public void DenoteUserReviewModified(UserReview userRev)
        {
            Entry(userRev).State = EntityState.Modified;
        }

        public Task CommitChangesAsync()
        {
            return SaveChangesAsync();
        }

    }
}
