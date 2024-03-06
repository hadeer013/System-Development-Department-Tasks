using System.ComponentModel.DataAnnotations.Schema;

namespace Trainee_MVCApp.Models
{
    public class Course: BaseEntity
    {
        public string Topic { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId {  get; set; }
        public Trainee? Trainee { get; set; }

    }
}
