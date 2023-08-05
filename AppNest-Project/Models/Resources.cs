using System.ComponentModel.DataAnnotations.Schema;

namespace AppNest_Project.Models
{
    public class Resources
    {
        public int Id{ get; set; }
        public int Water { get; set; }
        public int Clothes { get; set; }
        public int Toy { get; set; }
        public int Medicine { get; set; }
        public int Food { get; set; }
       
    }
}
