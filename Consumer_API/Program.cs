using Consumer_API.Modelo;
using System.Net.Http.Json;
using System.Text.Json;

var urlGet = "https://localhost:7002/ListarCarros";
var urlPost = "https://localhost:7002/AdicionaCarro";
JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };//Tanto maiúsculas ou minúsculas

using (var httpClient = new HttpClient())
{
    //Get
    var respostaGet = await httpClient.GetAsync(urlGet);
    if (respostaGet.IsSuccessStatusCode)
    {
        Console.WriteLine("Busca de dados Projeto_API");

        var contexto = await respostaGet.Content.ReadAsStringAsync();
        var carros = JsonSerializer.Deserialize<List<Carros>>(contexto, options);

        foreach (var item in carros)
        {
            Console.WriteLine($"ID:{item.Id} Nome:{item.Nome} Marca:{item.Marca} Placa:{item.Placa} ");
        }
    }

    //// Post
    //Console.WriteLine("Inserindo dados Projeto_API");
    //var respostaPost = await httpClient.PostAsJsonAsync(urlPost, new Carros { Nome = "Prisma", Marca = " Chevrolet", Placa = "PRIS-9999" });

    //if (respostaPost.IsSuccessStatusCode)
    //    Console.WriteLine("Carro Adicionado");
    //else
    //    Console.WriteLine("Error");


    Console.ReadLine();
}
