using System.Text.Json;
namespace IntroApiDotnetMusicas.Models;

internal class MusicasPreferidas
{
    public string Nome { get; set; }
    public List<Musica> ListaDeMusicasFavoristas { get; }

    public MusicasPreferidas(string nome) 
    {
        Nome = nome;
        ListaDeMusicasFavoristas = new List<Musica>();
    }

    public void AdcionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoristas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas de - {Nome}");
        foreach(var musica in  ListaDeMusicasFavoristas) 
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaDeMusicasFavoristas
        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";
        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"Json gerado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
    }
}
