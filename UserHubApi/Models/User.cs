using System.ComponentModel.DataAnnotations;

namespace UserHubApi.Models
{
    public class User
    {
        public int? id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string birthDate { get; set; }
    }
}
