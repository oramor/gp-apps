using Lib.Core;

namespace Lib.Models
{
    public enum SubjectRoleId
    {
        Buyer = 2
    }

    public class SubjectRole : IEntity<SubjectRoleId>
    {
        private string _title = string.Empty;

        public SubjectRoleId Id { get; init; }
        public string Title { get => _title; set => _title = value; }
    }
}
