using Bank.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Bank.Application.Interfaces
{
    public interface ICarteiraAtivosClienteService
    {
        Task<List<CarteiraAtivosPorCliente>> InserirDadosCarteira(List<CarteiraAtivosPorCliente> ativosCliente);

        Task DeleteDadosCarteira();
    }
}
