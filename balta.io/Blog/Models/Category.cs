using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]       
        [MaxLength(80)]
        [Column("Name", TypeName ="VARCHAR")]
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}