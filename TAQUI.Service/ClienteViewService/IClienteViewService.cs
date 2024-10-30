using TAQUI.Model;

namespace TAQUI.Service.ClienteViewService
{
    public interface IClienteViewService
    {

        void AddClienteView(ClienteView clienteView);

        Task<IEnumerable<ClienteView>> GetClienteViews();
    }
}
