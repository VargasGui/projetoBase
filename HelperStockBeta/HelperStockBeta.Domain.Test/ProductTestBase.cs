
using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Teste;
public class ProductTestBase
{
    #region Testes positivos
    [Fact(DisplayName = "Product no present id parameter")]
    public void CreateProduct_ParametersLess_ResultValid()
    {
        Action action = () => new Product("Teclado", "Descrição do Teclado", 80, 20, "http://StringImage");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    [Fact(DisplayName = "Product properties is not null")]
    public void CreateProduct_WithParameters_ResultValid()
    {
        Action action = () => new Product(1, "Teclado", "Descrição do Teclado", 80, 20, "http://StringImage");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    #endregion
    #region Testes Negativos
    [Fact(DisplayName = "Product Id negative exception")]
    public void CreateProduct_NegativeId_ResultException()
    {
        Action action = () => new Product(-1, "Teclado", "Descrição do Teclado", 80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for id.");
    }
    [Fact(DisplayName = "Product name null exception")]
    public void CreateProduct_NameParameterNull_ResultException()
    {
        Action action = () => new Product(1, null, "Descrição do Teclado", 80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
    }
    [Fact(DisplayName = "Product name short exception")]
    public void CreateProduct_NameParameterShort_ResultException()
    {
        Action action = () => new Product(1, "gu", "Descrição do Teclado", 80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short names, minimum 3 characteres.");
    }
    [Fact(DisplayName = "Product description null exception")]
    public void CreateProduct_DescriptionParameterNull_ResultException()
    {
        Action action = () => new Product(1, "Teclado", null, 80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, description is required.");
    }
    [Fact(DisplayName = "Product description short exception")]
    public void CreateProduct_DescriptionParameterShort_ResultException()
    {
        Action action = () => new Product(1, "Teclado", "desc", 80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short descriptions, minimum 5 characters.");
    }
    [Fact(DisplayName = "Product price negative exception")]
    public void CreateProduct_NegativePrice_ResultException()
    {
        Action action = () => new Product(1, "Teclado", "description", -80, 20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for price.");
    }
    [Fact(DisplayName = "Product stock neagtive exception")]
    public void CreateProduct_NegativeStock_ResultException()
    {
        Action action = () => new Product(1, "Teclado", "description", 80, -20, "http://StringImage");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for stock.");
    }
    [Fact(DisplayName = "Product image long exception")]
    public void CreateProduct_LongImage_ResultException()
    {
        Action action = () => new Product(1, "Teclado", "description", 80, 20, "https://www.example.com/abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLM");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid long URL, maximum 250 characteres.");
    }
    #endregion

}

