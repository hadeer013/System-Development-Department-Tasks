namespace Trainee_MVCApp.Models
{
    public class Track: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Trainee>? Trainees { get; set; }
    }
}
