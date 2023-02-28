using Microsoft.EntityFrameworkCore;

namespace VanCityFood.Models
{
    public interface IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }

        public void DenoteUserModified(User user);
        public void DenoteRestaurantModified(Restaurant rest);
        public void DenoteUserReviewModified(UserReview userRev);
        public Task CommitChangesAsync();
    }
}
