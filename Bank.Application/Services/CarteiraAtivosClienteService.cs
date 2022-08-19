using Bank.Application.Enums;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Bank.Application.Services
{
    public class CarteiraAtivosClienteService : ICarteiraAtivosClienteService
    {
        private readonly List<string> _clienteCarteiras = new() { "CARTEIRA CLIENTE A", "CARTEIRA CLIENTE B", "CARTEIRA CLIENTE C" };

        private readonly IValidator<CarteiraAtivosPorCliente> _validator;

        private readonly ICarteiraAtivosClienteRepository _carteiraAtivosClienteRepository;

        public CarteiraAtivosClienteService(IValidator<CarteiraAtivosPorCliente> validator
            , ICarteiraAtivosClienteRepository carteiraAtivosClienteRepository)
        {
            _validator = validator;
            _carteiraAtivosClienteRepository = carteiraAtivosClienteRepository;
        }

        public async Task<List<CarteiraAtivosPorCliente>> InserirDadosCarteira(List<CarteiraAtivosPorCliente> ativosCliente)
        {
            List<CarteiraAtivosPorCliente> listaCarteiraProcessada = new();

            foreach (var carteira in ativosCliente)
            {
                CarteiraAtivosPorCliente carteiraProcessada = new();

                ValidationResult result = await _validator.ValidateAsync(carteira);

                carteiraProcessada = carteira;

                if (!result.IsValid)
                {
                    carteiraProcessada.StatusBoleto = StatusBoleto.Erro.ToString();
                    carteiraProcessada.MensagemValidacaoErro = string.Join(", ", result.Errors.Select(s => s.ErrorMessage).ToList());

                }
                else
                {
                    carteiraProcessada.StatusBoleto = StatusBoleto.Ok.ToString(); ;
                    carteiraProcessada.MensagemValidacaoErro = "";
                }

                listaCarteiraProcessada.Add(carteiraProcessada);

            }

            var listaSalvar = CalculaDesconto(listaCarteiraProcessada);

            _carteiraAtivosClienteRepository.AddRange(listaSalvar);

            return listaCarteiraProcessada;
        }

        public Task DeleteDadosCarteira()
        {
             _carteiraAtivosClienteRepository.DeleteAll();
            return Task.CompletedTask;  
        }


        private List<CarteiraAtivosPorCliente> CalculaDesconto(List<CarteiraAtivosPorCliente> listaCarteiraProcessada)
        {
            List<CarteiraAtivosPorCliente>? carteirasCliente = new();

            foreach (var clienteCarteira in _clienteCarteiras)
            {

                var carteirasClienteOk = listaCarteiraProcessada
                    .Where(w => w.CodigoClienteCarteira == clienteCarteira &&
                         w.StatusBoleto == StatusBoleto.Ok.ToString())
                    .OrderByDescending(o => o.ValorFinanceiroOperacao)
                    .ToList();

                carteirasClienteOk[0].ValorDescontoOperacao = carteirasClienteOk[0].ValorFinanceiroOperacao * .1M;
                carteirasCliente.AddRange(carteirasClienteOk);
            }

            carteirasCliente.AddRange(listaCarteiraProcessada.Where(w => w.StatusBoleto == StatusBoleto.Erro.ToString()).ToList());

            return carteirasCliente;

        }
    }
}
