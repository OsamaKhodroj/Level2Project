namespace Level2Project.Models
{
    public class AddUserResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; } 
    }



    public enum Status
    {
        None = 0,
        Success = 1,
        Error = 2,
        Warning= 3  
    }
}
