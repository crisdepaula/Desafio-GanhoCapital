namespace GanhoCapital.Entity
{
    public class ProcessarAcao
    {
        public int TotalAcoes { get; set; }
        public decimal MediaPonderada { get; set; }
        public decimal TotalLucroOrPeda { get; set; }

        public void CalculaMediaPonderadaAsync(decimal precoUnitario, int quantidadeDeAcoesNegociadas)
        {
            MediaPonderada = ((TotalAcoes * MediaPonderada) + (precoUnitario * quantidadeDeAcoesNegociadas)) / (TotalAcoes + quantidadeDeAcoesNegociadas);
        }

        public async Task<Taxa> ComprarAcoesAsync(decimal precoUnitario, int quantidadeDeAcoesNegociadas)
        {
            CalculaMediaPonderadaAsync(precoUnitario, quantidadeDeAcoesNegociadas);

            TotalAcoes += quantidadeDeAcoesNegociadas;

            return new Taxa();
        }

        public async Task<decimal> CalcularLucroAsync(decimal precoUnitario, decimal quantidade)
        {
            return (quantidade * precoUnitario) - (quantidade * MediaPonderada);
        }

        private async Task<bool> PossuiLucroAsync(decimal lucro, decimal precoUnitario)
        {
            return (TotalLucroOrPeda + lucro) > 0 && MediaPonderada <= precoUnitario;
        }

        public decimal CalcularLucro(decimal quantidade, decimal precoUnitario)
        {
            return (quantidade * precoUnitario) - (quantidade * MediaPonderada);
        }

        public decimal CalcularTotalOperacao(decimal quantidade, decimal precoUnitario)
        {
            return precoUnitario * quantidade;
        }

        public async Task<Taxa> VenderAcoesAsync(decimal precoUnitario, int quantidade)
        {
            var taxa = new Taxa();

            TotalAcoes -= quantidade;

            var lucro = CalcularLucro(quantidade, precoUnitario);

            var temLucro = await PossuiLucroAsync(lucro, precoUnitario);

            if (!temLucro)
            {
                TotalLucroOrPeda += lucro;
                return taxa;
            }

            var totalOperacao = CalcularTotalOperacao(quantidade, precoUnitario);

            if (TotalLucroOrPeda < 0)
                lucro += TotalLucroOrPeda;

            taxa.CalcularTaxa(totalOperacao, lucro);

            TotalLucroOrPeda += lucro;
            return taxa;
        }
    }
}
