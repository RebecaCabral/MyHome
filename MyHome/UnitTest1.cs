using System;
using Xunit;

namespace MyHome
{
    public class UnitTest1
    {
        [Fact]
        public void TestarRateioDeValoresParaPagamentoDeAluguel()
        {
            var SalarioVitor = 5000;
            var SalarioRebeca = 1950;
            var ValorDoAluguel = 1000;

            var resultadoDoPagamento = RatearValorParaPagarAluguel(SalarioVitor, SalarioRebeca, ValorDoAluguel);

            var sobrouDoSalarioDoVitor = resultadoDoPagamento.getSobrouDoSalarioDoVitor();
            var sobrouDoSalarioDaRebeca = resultadoDoPagamento.getSobrouDoSalarioDaRebeca ();

            Assert.True(sobrouDoSalarioDoVitor + sobrouDoSalarioDaRebeca + ValorDoAluguel == SalarioVitor + SalarioRebeca);
        }

        public ResultadoDoPagamento RatearValorParaPagarAluguel(decimal SalarioVitor, decimal SalarioRebeca, decimal ValorDoAluguel)
        {

            decimal rendimentoDaCasa = SalarioVitor + SalarioRebeca;
            var percentualSalarioDoVitorNoRendimentoDaCasa = SalarioVitor * 100 / rendimentoDaCasa;

            percentualSalarioDoVitorNoRendimentoDaCasa = decimal.Round(percentualSalarioDoVitorNoRendimentoDaCasa, 2);

            var valorPercentualSalarioDoVitorNoAluguel = percentualSalarioDoVitorNoRendimentoDaCasa / 100 * ValorDoAluguel;

            valorPercentualSalarioDoVitorNoAluguel = decimal.Round(valorPercentualSalarioDoVitorNoAluguel, 2);

            var restanteDoAluguel = ValorDoAluguel - valorPercentualSalarioDoVitorNoAluguel;
            var restanteDoSalarioDoVitor = SalarioVitor - valorPercentualSalarioDoVitorNoAluguel;
            var restanteDoSalarioDaRebeca = SalarioRebeca - restanteDoAluguel;

            ResultadoDoPagamento resultado = new ResultadoDoPagamento();
            resultado.setSobrouDoSalarioDaRebeca(restanteDoSalarioDaRebeca);
            resultado.setSobrouDoSalarioDoVitor(restanteDoSalarioDoVitor);
            resultado.setVitorDeu(SalarioVitor - restanteDoSalarioDoVitor);
            resultado.setRebecaDeu(SalarioRebeca - restanteDoSalarioDaRebeca);

            return resultado;
        }

    }




    ///Cenário: rateio de valores de pagamento de aluguel
    ///Dado que o vitor de uma quantia em dinheiro
    ///E a rebeca de uma quantia em dinheiro
    ///Quando eles forem pagar o aluguel
    ///Entao cada um tem que dar o mesmo percentual do seu dinheiro para pagar o aluguel
    ///
}
