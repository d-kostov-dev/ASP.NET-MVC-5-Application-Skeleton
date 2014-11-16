namespace Application.Models
{
    using System.ComponentModel.DataAnnotations;

    using Application.Models.Base;

    public class Image : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
