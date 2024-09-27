using System.ComponentModel.DataAnnotations;

namespace ToolStore.WebApi.Dtos.Tool
{
    public class ToolEditDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }


        public float Price { get; set; }

    }
}