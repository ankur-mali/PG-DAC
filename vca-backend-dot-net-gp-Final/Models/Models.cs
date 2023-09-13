using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCA.Models
{
    [Table("models")]
    public class Model
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Segment")]
        [Column("seg_id")]
        public int SegId { get; set; }
        public Segment Segment { get; set; }

        [ForeignKey("Manufacturer")]
        [Column("manu_id")]
        public int? ManuId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        [Required]
        [Column("mod_name")]
        public string? ModName { get; set; }

        [Required]
        [Column("price")]
        public int Price { get; set; }

        [DefaultValue(5)]
        [Column("safety_rating")]
        public int SafetyRating { get; set; }

        [Required]
        [Column("image_path")]
        public string? ImagePath { get; set; }

        [Column("min_qty")]
        public int MinQty { get; set; }


        public ICollection<AlternateComponent>? alternateComponents { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}
