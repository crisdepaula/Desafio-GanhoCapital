using Newtonsoft.Json;

namespace GanhoCapital.Dtos
{
    public class TaxaDto
    {
        [JsonProperty("taxa")]
        public decimal Taxa { get; set; }

        public TaxaDto()
        {
            Taxa = 0;
        }

        public TaxaDto(decimal taxa)
        {
            Taxa = taxa;
        }
    }
}
