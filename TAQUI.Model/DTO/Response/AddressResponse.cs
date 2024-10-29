using Newtonsoft.Json;

namespace TAQUI.Model.DTO.Response
{
    public class AddressResponse
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }


        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("erro")]
        public string? Erro { get; set; }

        public static implicit operator Task<object>(AddressResponse v)
        {
            throw new NotImplementedException();
        }
    }

    
}
