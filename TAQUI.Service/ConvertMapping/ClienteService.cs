using TAQUI.Model;
using TAQUI.Model.DTO.Request;
using TAQUI.Model.DTO.Response;
using TAQUI.Service.CEP;

namespace TAQUI.Service.ConvertMapping
{
    public class ClienteService
    {
        private readonly CEPService _cepService = new CEPService();

        //Métodos de conversão
        public async Task<Cliente> requestToClienteAsync(ClienteRequest clienteRequest)
        {
            AddressResponse addressResponse = await _cepService.GetAddress(clienteRequest.NrCep);
            Cliente cliente = new Cliente();

            cliente.DsUser = clienteRequest.DsUser;
            cliente.DsSenha = clienteRequest.DsSenha;
            cliente.DsEmail = clienteRequest.DsEmail;
            cliente.DsCpf = clienteRequest.DsCpf;
            cliente.NrCep = clienteRequest.NrCep;

            if (addressResponse != null) {
                cliente.NmLogradouro = addressResponse.Logradouro;
                cliente.NmBairro = addressResponse.Bairro;
                cliente.Localidade = addressResponse.Localidade;
                cliente.SgEstado = addressResponse.Uf;
                cliente.NmEstado = addressResponse.Estado;
                return cliente;
            }

            cliente.NmLogradouro = "";
            cliente.NmBairro = "";
            cliente.Localidade = "";
            cliente.SgEstado = "";
            cliente.NmEstado = "";

            return cliente;
        }

        public ClienteResponse clienteToResponse(Cliente cliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();
            clienteResponse.Id = cliente.Id;
            clienteResponse.DsUser = cliente.DsUser;
            clienteResponse.DsEmail = cliente.DsEmail;
            clienteResponse.NmLogradouro = cliente.NmLogradouro;
            clienteResponse.NrCep = cliente.NrCep;
            clienteResponse.NmBairro= cliente.NmBairro;
            clienteResponse.Localidade= cliente.Localidade;
            clienteResponse.SgEstado= cliente.SgEstado;
            clienteResponse.NmEstado= cliente.NmEstado;

            return clienteResponse;
        }

        public IEnumerable<ClienteResponse> clientesToResponseIEnumerable(IEnumerable<Cliente> clientes)
        {
            var clienteResponses = clientes.Select(cliente => new ClienteResponse
            {
                Id = cliente.Id,
                DsUser = cliente.DsUser,
                DsEmail = cliente.DsEmail,
                NmLogradouro= cliente.NmLogradouro ?? string.Empty,
                NrCep= cliente.NrCep ?? string.Empty,
                NmBairro= cliente.NmBairro ?? string.Empty,
                Localidade= cliente.Localidade ?? string.Empty,
                SgEstado= cliente.SgEstado ?? string.Empty,
                NmEstado= cliente.NmEstado ?? string.Empty

            });

            return clienteResponses;
        }

    }
}
