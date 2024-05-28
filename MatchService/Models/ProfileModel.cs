namespace MatchServiceApp.Models
{
    public class ProfileModel
    {
        public ProfileModel(List<int> swipedYes, List<int> swipedNo)
        {
            SwipedYes = swipedYes ?? new List<int>();
            SwipedNo = swipedNo ?? new List<int>();
        }
        public int Id { get; set; }
        public string? Username { get; set; }
        public int PowerRanking { get; set; }
        public List<int> SwipedYes { get; set; }
        public List<int> SwipedNo { get; set; }
    }

}
