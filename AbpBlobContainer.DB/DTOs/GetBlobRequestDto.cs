using System.ComponentModel.DataAnnotations;

namespace AbpBlobContainer.DB.DTOs
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }

}
