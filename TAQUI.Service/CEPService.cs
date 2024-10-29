using Newtonsoft.Json;
using TAQUI.Model.DTO.Response;

namespace TAQUI.Service
{
    public class CEPService : ICEPService
    {
        public async Task<AddressResponse> GetAddress(string cep)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://viacep.com.br/");

            HttpResponseMessage response = await client.GetAsync($"ws/{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                var addressResponse = JsonConvert.DeserializeObject<AddressResponse>(json);

                //Verifica se o CEP possui dados, se não possuir a API VIACEP retornará um error:"true"
                if (addressResponse?.Erro == "true")
                {
                    return null;
                }

                return addressResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
