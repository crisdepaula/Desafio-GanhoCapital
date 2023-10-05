namespace GanhoCapital.Entity
{
    public class Taxa
    {
        public const decimal MAX_TAXA = 20000;
        public const decimal TAXA = 0.2M; 
        public decimal ValorTaxa { get; set; }

        public void CalcularTaxa(decimal totalOperacao, decimal lucro)
        {
            ValorTaxa = 0;

            if (totalOperacao > Taxa.MAX_TAXA)
            {
                ValorTaxa = lucro * TAXA;
            }
        }
    }
}
