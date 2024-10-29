using TAQUI.Model.DTO.Response;

namespace TAQUI.Service
{
    public interface ICEPService
    {
        Task<AddressResponse> GetAddress(string cep); 

    }
}
