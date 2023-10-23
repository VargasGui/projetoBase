using HelperStockBeta.Domain.Entities;
using FluentAssertions;

namespace HelperStockBeta.Domain.Test
{
    public class CategoryUnitTestBase
    {
        #region Casos de Testes Positivos

        [Fact(DisplayName = "Category name is not null")]
        public void CreateCategory_WithValidParameters_ResultValid()
        {
            Action action = () => new Category(1, "Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Category no present id parameter.")]
        public void CreateCategory_IdParameterLess_ResultValid()
        {
            Action action = () => new Category("Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Casos de Testes Negativos
        [Fact(DisplayName = "Id negative exception")]
        public void CreateCategory_NegativeParametersId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria Teste");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Identification is positive values!");
        }
        [Fact(DisplayName = "Name in Category null ")]
        public void CreateCategory_NameParametersNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }
        [Fact(DisplayName = "Name in Category is short")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1, "Gu");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is minimum 3 characters");
        }
        #endregion

    }
}