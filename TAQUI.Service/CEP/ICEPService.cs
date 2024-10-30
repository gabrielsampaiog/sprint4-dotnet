using TAQUI.Model.DTO.Response;

namespace TAQUI.Service.CEP
{
    public interface ICEPService
    {
        Task<AddressResponse> GetAddress(string cep);

    }
}
