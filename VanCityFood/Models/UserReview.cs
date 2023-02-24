namespace VanCityFood.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestId { get; set; }
        public int ReviewNum { get; set; }
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
