namespace BlogProject.ViewModels;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// ViewModel per la creazione di un commento associato a un Post
/// </summary>
public class CommentCreateViewModel
{
    [Required]
    public int PostId { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Il contenuto del commento è obbligatorio")]
    [StringLength(500, ErrorMessage = "Il commento non può superare i 500 caratteri")]
    public required string Content { get; set; }
}