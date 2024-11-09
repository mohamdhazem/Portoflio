using System.ComponentModel.DataAnnotations.Schema;

namespace DepiMvcTask1.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string? image { get; set; }
        public string link { get; set; }

        [NotMapped]
        public IFormFile? realImage { get; set; }
    }
}
