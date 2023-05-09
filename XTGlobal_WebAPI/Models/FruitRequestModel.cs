using System.ComponentModel.DataAnnotations;

namespace XTGlobalWebAPI.Models
{
    public class FruitRequestModel
    {
        [Required]
        public string FruitFamily { get; set; }
    }
}
