using System.ComponentModel.DataAnnotations;

namespace MVCViewDemo_DeGuzman.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }

        [Required, StringLength(30)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Course { get; set; }

        public string YearLevel { get; set; }

        public bool IsEnrolled { get; set; }

        public List<string> SelectedCourses { get; set; }
    }
}
