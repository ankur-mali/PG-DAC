using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCA.Models
{
    [Table("invoices")]
    public class Invoice
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Model")]
        [Column("mod_id")]
        public int ModelId { get; set; }
        public Model? Model { get; set; }


        [Column("alt_comp_id")]
        [ForeignKey("AlternateComponent")]
        public int? AltCompId { get; set; }
        public AlternateComponent? AlternateComponent { get; set; }




        [Required]
        [Column("price")]
        public double Price { get; set; }




        [ForeignKey("Registration")]
        [Column("auth_id")]
        public int? AuthId { get; set; }
        public Registration? Registration { get; set; }



        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }


    }
}
