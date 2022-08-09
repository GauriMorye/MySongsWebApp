using System.ComponentModel.DataAnnotations;

namespace MySongsWebApp.Models
{
    public class MySongs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Artist { get; set; }
        [Range(1,10,ErrorMessage ="The song duration cannot be negative or more than 10 mins")]
        public double Duration { get; set; }
    }
}
