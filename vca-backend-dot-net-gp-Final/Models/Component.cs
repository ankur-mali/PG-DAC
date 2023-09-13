using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VCA.Models
{
    [Table("components")]

    public class Component
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("comp_name")]
        [JsonPropertyName("comp_name")]
        public string CompName { get; set; }
        public ICollection<AlternateComponent> AlternateComponents { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
    /*    public class Component
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public string CompName { get; set; }

            *//*        public virtual ICollection<AlternateComponent> CompId { get; set; }
                    public virtual ICollection<AlternateComponent> AltCompId { get; set; }*//*
            public ICollection<AlternateComponent> AlternateComponents { get; set; }

        }*/
}

