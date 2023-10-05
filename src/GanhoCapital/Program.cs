using GanhoCapital.Dtos;
using GanhoCapital.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Program
{
    public static  void Main(string[] args)
    {
        Console.WriteLine("---------------Ganho Capital----------------");
       

        Console.WriteLine("Insira os dados do json. Importante estar atento à quebra de linha.");

        string? text;

        if (!string.IsNullOrEmpty(text = Console.ReadLine()))
        {
            if (IsValidJson(text))
            {
                var orders = JsonConvert.DeserializeObject<AcaoDto[]>(text!);

                var taxes = OperacaoService.CalculatrTaxasAsync(orders!).Result;
                Console.WriteLine("---------------Resultado----------------");
                Console.WriteLine(JsonConvert.SerializeObject(taxes));
            }
        }

    }

    static bool IsValidJson(string jsonString)
    {
        try
        {
            //valida o json
            JToken.Parse(jsonString);
            return true;
        }
        catch (JsonReaderException ex)
        {
            // Se ocorrer uma exceção, a string JSON não é válida
            Console.WriteLine("JSON inválido. Erro: " + ex.Message);
            return false;
        }
    }
}