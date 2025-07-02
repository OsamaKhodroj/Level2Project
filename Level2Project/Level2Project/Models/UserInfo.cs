namespace Level2Project.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserMark
    {
        public int Id { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public int UserId { get; set; }
    }


    public class UserMarkViewModel
    {
        public UserInfo User { get; set; }
        public List<UserMark> Marks { get; set; }
    }

}
