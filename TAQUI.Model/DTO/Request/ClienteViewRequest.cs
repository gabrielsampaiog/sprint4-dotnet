
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TAQUI.Model.DTO.Request
{
    public class ClienteViewRequest
    {
        [MinLength(24, ErrorMessage = "O id do cliente deve conter no minimo 24 caracteres.")]
        [MaxLength(24, ErrorMessage = "O id do cliente deve conter no máximo 24 caracteres.")]
        [Required(ErrorMessage = "O id do cliente é obrigatório.")]
        public string ClienteId { get; set; }

        [MinLength(24, ErrorMessage = "O id do produto deve conter no minimo 24 caracteres.")]
        [MaxLength(24, ErrorMessage = "O id do produto deve conter no máximo 24 caracteres.")]
        [Required(ErrorMessage = "O id do produto é obrigatório.")]
        public string ProdutoId { get; set; }

        [NotMapped]
        public DateTime ViewedAt { get; set; } = DateTime.Now;


    }
}
