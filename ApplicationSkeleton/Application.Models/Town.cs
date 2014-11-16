namespace Application.Models
{
    using System.ComponentModel.DataAnnotations;

    using Application.Models.Base;

    public class Town : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
