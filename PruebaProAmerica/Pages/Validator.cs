using System.ComponentModel.DataAnnotations;

namespace PruebaProAmerica.Pages
{
    public class Validator
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string user_name { get; set; }

        [Required]
        [MinLength(10)]
        public string passwordus { get; set; }


    }
}
