namespace Application.Models
{
    using System.ComponentModel.DataAnnotations;

    using Application.Models.Base;

    public class Category : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
