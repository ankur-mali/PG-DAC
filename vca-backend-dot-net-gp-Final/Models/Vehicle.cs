using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCA.Models
{
    public enum CompType
    {
        S, C, I, E
    }

    public enum IsConfigurable
    {
        Y, N
    }

    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("comp_type")]
        public CompType CompType { get; set; }


        [Required]
        [Column("is_configurable")]
        public IsConfigurable IsConfigurable { get; set; }

        [Required]

        public int mod_id { get; set; }
        public virtual Model Mod_ { get; set; }

        [Required]

        public int comp_id { get; set; }
        public virtual Component Comp_ { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}
