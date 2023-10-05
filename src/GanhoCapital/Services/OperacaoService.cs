using GanhoCapital.Dtos;
using GanhoCapital.Entity;

namespace GanhoCapital.Services
{
    public static class OperacaoService
    {
        public static async Task<List<TaxaDto>> CalculatrTaxasAsync(IList<AcaoDto> acoes)
        {
            var carteira = new ProcessarAcao();
            var taxas = new List<TaxaDto>();

            if (acoes is null)
                return new List<TaxaDto>();

            foreach (var acao in acoes)
            {
                Taxa taxa;

                if (acao.Operacao == "buy") 
                {
                    taxa = await carteira.ComprarAcoesAsync(acao.PrecoUnitario, acao.Quantidade);
                }
                else
                {
                    taxa = await carteira.VenderAcoesAsync(acao.PrecoUnitario, acao.Quantidade);
                }

                taxas.Add(UpdateTaxa(taxa));
            }

            return taxas;
        }

        private static TaxaDto UpdateTaxa(Taxa taxa)
        {
            return new TaxaDto(taxa.ValorTaxa);
        }
    }
}
