namespace MyHome
{
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
