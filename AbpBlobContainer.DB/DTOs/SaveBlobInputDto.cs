using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBlobContainer.DB.DTOs
{

    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
