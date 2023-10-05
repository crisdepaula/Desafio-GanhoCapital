using Newtonsoft.Json;

namespace GanhoCapital.Dtos
{
    public class AcaoDto
    {
        /// <summary>
        /// Se a transação for uma transação de compra (buy) ou venda (sell)
        /// </summary>
        [JsonProperty("operation")]
        public string Operacao { get; set; }

        /// <summary>
        /// Preço unitário da ação em uma moeda com duas casas decimais
        /// </summary>
        [JsonProperty("unit-cost")]
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        ///Preço unitário da ação em uma moeda com duas casas decimais
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantidade { get; set; }
    }
}
