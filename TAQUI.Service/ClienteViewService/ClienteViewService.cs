using TAQUI.Model;
using TAQUI.Repository;

namespace TAQUI.Service.ClienteViewService
{
    public class ClienteViewService(IRepository<ClienteView> clienteViewRepository) : IClienteViewService
    {
        private readonly IRepository<ClienteView> _clienteViewRepository = clienteViewRepository;

        public void AddClienteView(ClienteView clienteView)
        {
            _clienteViewRepository.Add(clienteView);
        }

        public async Task<IEnumerable<ClienteView>> GetClienteViews()
        {
            return await _clienteViewRepository.GetAll();
        }
    }
}
