using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Categories;
public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(80)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(80)]
    public string Slug { get; set; }
}