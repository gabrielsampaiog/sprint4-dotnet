using MongoDB.Bson;


namespace TAQUI.Model.DTO.Response
{
    public class ClienteResponse
    {
        //DTO criado excluindo a senha e o CPF por conta da sensibilidade dos dados.

        public ObjectId Id { get; set; }

        public string DsUser { get; set; }

        public string DsEmail { get; set; }

        public string? NmLogradouro { get; set; }

        public string? NrCep { get; set; }

        public string? NmBairro { get; set; }

        public string? Localidade { get; set; }

        public string? SgEstado { get; set; }

        public string? NmEstado { get; set; }
    }
}
