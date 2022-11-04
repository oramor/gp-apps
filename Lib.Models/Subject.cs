using Lib.Models.Base;

namespace Lib.Models
{
    public enum SubjectStatus
    {
        active
    }

    public class Subject : ModelBase
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public SubjectStatus Status { get; set; }
    }
}
