using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCA.Models
{
    [Table("manufacturers")]
    public class Manufacturer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("manu_name")]
        public string Name { get; set; }

        [ForeignKey("Segment")]
        [Required]
        [Column("seg_id")]
        public int SegId { get; set; }
        public virtual Segment Segment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}
