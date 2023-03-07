using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanCityFood.Models
{
    [Table("UserReviews")]
    public class UserReview
    {
        [Key,Column("ReviewId")]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("RestId")]
        public int RestId { get; set; }

        [Column("ReviewNum")]
        public int ReviewNum { get; set; }

        [Column("UserComment")]
        public string? UserComment { get; set; }

        public UserReview(){}
        public UserReview(int id, int userId, int restId, int reviewNum, string userComment)
        {
            Id = id;
            UserId = userId;
            RestId = restId;
            ReviewNum = reviewNum;
            UserComment = userComment;
        }

        public UserReview(int userId, int restId, int reviewNum)
        {
            UserId = userId;
            RestId=restId;
            ReviewNum=reviewNum;
        }


    }
}
