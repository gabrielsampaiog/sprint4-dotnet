using TAQUI.Model;
using TAQUI.Model.DTO.Request;

namespace TAQUI.Service.ClienteViewService
{
    public interface IClienteViewService
    {

        void AddClienteView(ClienteViewRequest clienteViewRequest);

        Task<IEnumerable<ClienteView>> GetClienteViews();
    }
}
