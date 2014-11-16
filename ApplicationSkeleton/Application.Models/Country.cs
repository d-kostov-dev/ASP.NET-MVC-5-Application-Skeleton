namespace Application.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Application.Models.Base;

    public class Country : AuditInfo
    {
        private ICollection<Town> towns;

        public Country()
        {
            this.towns = new HashSet<Town>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns
        {
            get { return this.towns; }
            set { this.towns = value; }
        }
    }
}
