using System;
using TesteUnitarioDesafio;
using Xunit;

namespace TesteUnitarioDesafioTestes
{
    public class UnitTest1
    {
        public Calculadora construirClasse()
        {
            string data = "30/04/2024";
            Calculadora calc = new Calculadora(data);
            return calc;
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = construirClasse();
            int resultado = calc.somar(val1,val2);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = construirClasse();
            int resultado = calc.multiplicar(val1, val2);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(2, 2, 0)]
        [InlineData(5, 4, 1)]
        public void TesteSubtrair(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = construirClasse();
            int resultado = calc.subtrair(val1, val2);
            Assert.Equal(resultadoEsperado, resultado);
        }


        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(25, 5, 5)]
        public void TesteDividir(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calc = construirClasse();
            int resultado = calc.dividir(val1, val2);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TesteDividirPorZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(() => calc.dividir(3,0));
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();
            calc.somar(1,2);
            calc.somar(2,3);
            calc.somar(4,7);
            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }


    }
}
