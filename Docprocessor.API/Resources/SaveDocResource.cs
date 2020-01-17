using System.ComponentModel.DataAnnotations;

namespace Docprocessor.API.Resources
{
    public class SaveDocResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
