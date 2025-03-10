using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class FornecedorValidation : AbstractValidator<Fornecedor>
{
    public FornecedorValidation()
    {
        RuleFor(f => f.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
        {
            RuleFor(f => f.Documento.Length).Equal(ValidacaoDocs.CpfValidacao.TamanhoCpf).WithMessage(
                "O campo Documento precisa ter {ComparisionValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(f => ValidacaoDocs.CpfValidacao.Validar(f.Documento)).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        });

        When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
        {
            RuleFor(f => f.Documento.Length).Equal(ValidacaoDocs.CnpjValidacao.TamanhoCnpj).WithMessage(
                "O campo Documento precisa ter {ComparisionValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(f => ValidacaoDocs.CnpjValidacao.Validar(f.Documento)).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        });
    }
}