using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Attachment : BaseEntity
    {
        [Key]
        public string AttachmentID { get; set; }
        public string Filename { get; set; }
        public string FileExt { get; set; }
        public byte[] FileData { get; set; }
    }
}
