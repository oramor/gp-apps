namespace Lib.Models
{

    public enum SubjectStatusEnum
    {
        active
    }

    public class Subject : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public SubjectStatusEnum Status { get; set; }
    }

}