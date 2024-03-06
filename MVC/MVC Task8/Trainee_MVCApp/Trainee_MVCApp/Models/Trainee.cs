using System.ComponentModel.DataAnnotations.Schema;
using Trainee_MVCApp.Helper;

namespace Trainee_MVCApp.Models
{
    public class Trainee:BaseEntity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateOnly Birthdate { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }
        public Track? Track { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }

    }
}
