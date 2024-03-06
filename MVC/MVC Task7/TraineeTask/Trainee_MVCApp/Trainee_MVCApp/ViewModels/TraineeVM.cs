using System.ComponentModel.DataAnnotations.Schema;
using Trainee_MVCApp.Helper;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.ViewModels
{
    public class TraineeVM
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateOnly Birthdate { get; set; }
        public string TrackName { get; set; }
        
    }
}
