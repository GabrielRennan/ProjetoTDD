using Calculadora.Services;
namespace CalculadoraTests;

public class UnitTest1
{
    private CalculadoraImp _calc;

    public UnitTest1()
    {
        _calc = new CalculadoraImp();
    }


    [Theory]
    [InlineData (1 , 2 , 3)]
    [InlineData (4 , 5 , 9)]
    public void TestSomar(int val1,int val2, int resultEsperado)
    {
        int resultado =_calc.Somar(val1,val2);

        Assert.Equal(resultEsperado,resultado);
    }

    [Theory]
    [InlineData (3 , 2 , 1)]
    [InlineData (6 , 3 , 3)]
    public void TestSubtrair(int val1,int val2, int resultEsperado)
    {
        int resultado =_calc.Subtrair(val1,val2);

        Assert.Equal(resultEsperado,resultado);
    }

    [Theory]
    [InlineData (6 , 2 , 3)]
    [InlineData (20 , 5 , 4)]
    public void TestDividir(int val1,int val2, int resultEsperado)
    {
        int resultado =_calc.Dividir(val1,val2);

        Assert.Equal(resultEsperado,resultado);
    }

    [Theory]
    [InlineData (1 , 2 , 2)]
    [InlineData (3 , 4 , 12)]
    public void TestMultiplicar(int val1,int val2, int resultEsperado)
    {
        int resultado =_calc.Multiplicar(val1,val2);

        Assert.Equal(resultEsperado,resultado);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
       Assert.Throws<DivideByZeroException>(()=>_calc.Dividir(3,0));
    }

    [Fact]
    public void TestarHistorico()
    {
        _calc.Somar(1,2);
        _calc.Somar(10,3);
        _calc.Somar(5,5);
        _calc.Somar(4,2);

        var lista =_calc.Historico;

        Assert.NotEmpty(lista());
        Assert.Equal(3 , lista().Count);
    }
}