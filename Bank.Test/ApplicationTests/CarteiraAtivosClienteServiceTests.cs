using Bank.Application.Interfaces;
using Bank.Application.Services;
using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Test.ApplicationTests
{
    public class CarteiraAtivosClienteServiceTests
    {
        private readonly CarteiraAtivosClienteService carteiraAtivosClienteService;
        private readonly Mock<ICarteiraAtivosClienteRepository> carteiraAtivosClienteRepository;

        public CarteiraAtivosClienteServiceTests(CarteiraAtivosClienteService carteiraAtivosClienteService, Mock<ICarteiraAtivosClienteRepository> carteiraAtivosClienteRepository)
        {
            this.carteiraAtivosClienteService = carteiraAtivosClienteService;
            this.carteiraAtivosClienteRepository = carteiraAtivosClienteRepository;
        }

        public void DadosAtivoCarteiraCliente()
        {
            List<CarteiraAtivosPorCliente> listaCarteiraClienteEsperado = new();

            listaCarteiraClienteEsperado.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                             "CARTEIRA CLIENTE A",
                                             "Compra",
                                             "BVSP",
                                             "VALE3",
                                             "AGORA",
                                             120,
                                             400)
            );

            listaCarteiraClienteEsperado.Add(
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

            listaCarteiraClienteEsperado.Add(
                new CarteiraAtivosPorCliente(DateTime.Now,
                                             "CARTEIRA CLIENTE Y",
                                             "Compra",
                                             "BVMF",
                                             "MAGALU3",
                                             "XP",
                                             40000,
                                             220)
            );

            listaCarteiraClienteEsperado.Add(
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


        //[Fact]
        //[Trait(nameof(ICarteiraAtivosClienteService.InserirDadosCarteira), "Erro")]
        //public async Task ProcessarCarteiraAsync_Erro(It.IsAny(), )
        //{
        //    await Assert.ThrowsAnyAsync<>(async () =>
        //    {
        //        await carter.ObterFilmesAsync(new Pesquisa());
        //    });
        //}


        //[Fact]
        //public void ProcessaCarteira_IsFail()
        //{
        //    var carteiraAtivosClienteRepositorymock = new Mock<ICarteiraAtivosClienteRepository>();
        //    var texto = "0#RV";

        //    _carteiraAtivosClienteService
        //        .Setup(p => p.InserirDadosCarteira(I)
        //        .Returns(listaCarteiraEsperado)
        //        );

 
        //    string result = home.GetNameById(1);

        //    Assert.AreEqual(, result);
        //}
    }
}
