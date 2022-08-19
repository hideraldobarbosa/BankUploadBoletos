using Bank.Application.Services;
using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Moq;

namespace Bank.Test.ApplicationTests
{
    public class CarteiraAtivosClienteServiceTests
    {
        private readonly CarteiraAtivosClienteService _carteiraAtivosClienteService;
        private readonly Mock<ICarteiraAtivosClienteRepository> _carteiraAtivosClienteRepositoryMock;

        public CarteiraAtivosClienteServiceTests(CarteiraAtivosClienteService carteiraAtivosClienteService,
            Mock<ICarteiraAtivosClienteRepository> carteiraAtivosClienteRepositoryMock)
        {
            _carteiraAtivosClienteService = carteiraAtivosClienteService;
            _carteiraAtivosClienteRepositoryMock = carteiraAtivosClienteRepositoryMock;
        }

        public void DadosCarteiraAtivosClientes()
        {
            List<CarteiraAtivosPorCliente> listaCarteiraCliente = new();

            listaCarteiraCliente.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                             "CARTEIRA CLIENTE A",
                                             "Compra",
                                             "BVSP",
                                             "VALE3",
                                             "AGORA",
                                             120,
                                             400)
            );

            listaCarteiraCliente.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                            "CARTEIRA CLIENTE B",
                                            "Compra",
                                            "BVSP",
                                            "VALE3",
                                            "AGORA", 
                                            320, 
                                            150)
            );


            List<CarteiraAtivosPorCliente> listaCarteiraClienteInvalidos = new();

            listaCarteiraClienteInvalidos.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                             "CARTEIRA CLIENTE Y",
                                             "Compra",
                                             "BVMF",
                                             "MAGALU3",
                                             "XP",
                                             40000,
                                             220)
            );

            listaCarteiraClienteInvalidos.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                            "CARTEIRA CLIENTE X",
                                            "Compra",
                                            "BVSP",
                                            "VALE45",
                                            "AGORA",
                                            180,
                                            130)
            );
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_FalhaValidacao()
        {


        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_SucessoValidacao()
        {
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_FalhaDesconto()
        {
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_SucessoDesconto()
        {
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_FalhaUpload()
        {
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_SucessoUpload()
        {

        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_FalhaDelete()
        {
        }

        [Fact]
        public async Task InseirDadosCarteiraAsync_SucessoDelete()
        {
        }
    }
}
