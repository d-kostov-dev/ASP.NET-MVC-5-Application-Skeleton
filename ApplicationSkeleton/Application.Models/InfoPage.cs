namespace Application.Models
{
    using System.ComponentModel.DataAnnotations;

    using Application.Models.Base;

    public class InfoPage : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SeoUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int Order { get; set; }
    }
}
