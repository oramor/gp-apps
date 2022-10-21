using LibCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibModels
{
    public enum SubjectStatus
    {
       active
    }

    public class Subject : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public SubjectStatus Status { get; set; }
    }
}
