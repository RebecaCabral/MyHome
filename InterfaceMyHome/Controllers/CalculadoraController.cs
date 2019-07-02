using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceMyHome.Controllers
{
    public class CalculadoraController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal salarioDoVitor, decimal salarioDaRebeca, decimal valorDoAluguel)
        {
            var resultadoDoPagamento = RatearValorParaPagarAluguel(salarioDoVitor, salarioDaRebeca, valorDoAluguel);

            return View(resultadoDoPagamento);
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

    public class ResultadoDoPagamento
    {

        private decimal SobrouDoVitor;

        public void setSobrouDoSalarioDoVitor(decimal valor)
        {
            SobrouDoVitor = valor;
        }

        public decimal getSobrouDoSalarioDoVitor()
        {
            return SobrouDoVitor;
        }



        private decimal VitorDeu;
        public void setVitorDeu(decimal valor)
        {
            VitorDeu = valor;
        }


        public decimal getVitordeu()
        {
            return VitorDeu;
        }



        private decimal SobrouDaRb;
        public decimal getSobrouDoSalarioDaRebeca()
        {
            return SobrouDaRb;
        }

        public void setSobrouDoSalarioDaRebeca(decimal valor)
        {
            SobrouDaRb = valor;
        }



        private decimal RebecaDeu;
        public void setRebecaDeu(decimal valor)
        {
            RebecaDeu = valor;
        }

        public decimal getRebecaDeu()
        {
            return RebecaDeu;
        }


    }
}