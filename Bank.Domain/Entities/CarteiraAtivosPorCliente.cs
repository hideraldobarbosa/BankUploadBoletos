using Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class CarteiraAtivosPorCliente : BaseEntity, IAggregateRoot
    {
        public CarteiraAtivosPorCliente(DateTime dataOperacao, string codigoClienteCarteira, string tipoOperacao, string idBolsa, string codigoAtivo, string corretora, int quantidade, decimal precoUnitario)
        {
            DataOperacao = dataOperacao;
            CodigoClienteCarteira = codigoClienteCarteira;
            TipoOperacao = tipoOperacao;
            IdBolsa = idBolsa;
            CodigoAtivo = codigoAtivo;
            Corretora = corretora;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            ValorFinanceiroOperacao = Quantidade * PrecoUnitario;
        }

        public CarteiraAtivosPorCliente()
        {
            ValorFinanceiroOperacao = Quantidade * PrecoUnitario;
        }

        public DateTime DataOperacao { get; private set; }
        public string  CodigoClienteCarteira { get; private set; }
        public string TipoOperacao { get; private set; }
        public string IdBolsa { get; private set; }
        public string CodigoAtivo { get; private set; }
        public string Corretora { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal? ValorDescontoOperacao { get; set; }
        public string? StatusBoleto { get; set; }
        public string? MensagemValidacaoErro { get; set; }
        public decimal? ValorFinanceiroOperacao { get; set;  }

    }
}
