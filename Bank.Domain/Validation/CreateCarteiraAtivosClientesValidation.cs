using Bank.Domain.Entities;
using FluentValidation;

namespace Bank.Domain.Validation
{
    public class CreateCarteiraAtivosClientesValidation : AbstractValidator<CarteiraAtivosPorCliente>
    {

        private readonly List<string> _corretorasValidas = new() { "AGORA" };

        private readonly List<string> _clienteCarteiras = new() { "CARTEIRA CLIENTE A", "CARTEIRA CLIENTE B", "CARTEIRA CLIENTE C" };

        private readonly List<string> _bolsasValidas = new() { "BVSP" };

        private readonly List<string> _ativosValidos = new() { "VALE3", "PETR4" };

        private readonly List<string> _tipoOperacoesValidas = new() { "COMPRA", "VENDA" };

        public CreateCarteiraAtivosClientesValidation()
        {
            RuleFor(x => x.CodigoClienteCarteira)
                .NotNull().WithMessage("Codigo do Cliente Carteira é obrigatorio")
                .MaximumLength(100).WithMessage("Tamanho do conteúdo do campo excedente")
                .Must(x => _clienteCarteiras.Contains(x.ToUpper()))
                .WithMessage("{PropertyName} com valor : {PropertyValue} é inválido.");

            RuleFor(x => x.CodigoAtivo)
                .NotNull().WithMessage("Codigo do ativo é obrigatorio")
                .MaximumLength(10).WithMessage("Tamanho do conteúdo do campo excedente")
                .Must(x => _ativosValidos.Contains(x.ToUpper()))
                .WithMessage("{PropertyName} com valor : {PropertyValue} é inválido.");


            RuleFor(x => x.DataOperacao)
                .NotNull().WithMessage("Data Operação é obrigatoria");
                
            RuleFor(x => x.TipoOperacao)
                .NotNull().WithMessage("Tipo de Operação é obrigatorio")
                .MaximumLength(20).WithMessage("Tamanho do conteúdo do campo excedente")
                .Must(x => _tipoOperacoesValidas.Contains(x.ToUpper()))
                .WithMessage("{PropertyName} com valor : {PropertyValue} é inválido.");

            RuleFor(x => x.IdBolsa)
                .NotNull().WithMessage("Id da Bolsa é obrigatório")
                .MaximumLength(10).WithMessage("Tamanho do conteúdo do campo excedente")
                .Must(x => _bolsasValidas.Contains(x.ToUpper()))
                .WithMessage("{PropertyName} com valor : {PropertyValue} é inválido.");

            RuleFor(x => x.Corretora) 
                .NotNull().WithMessage("Corretora é obrigatoria")
                .MaximumLength(20).WithMessage("Tamanho do conteúdo do campo excedente")
                .Must(x => _corretorasValidas.Contains(x.ToUpper()))
                .WithMessage("{PropertyName} com valor : {PropertyValue} é inválido.");


            RuleFor(x => x.Quantidade)
                .NotNull().WithMessage("Quantidade é obrigatoria")
                .GreaterThan(0).WithMessage("Necessário informar valor para quantidade positivo");

            RuleFor(x => x.PrecoUnitario)
                .NotNull().WithMessage("Preço unitário é obrigatorio")
                .GreaterThan(0).WithMessage("Necessário informar valor para preco unitário positivo");

        }
    }
}