using IntroApiDotnetMusicas.Models;

namespace IntroApiDotnetMusicas.Filtros;

internal class LinqOrder
{
    public static void ExibirListaPorArtistaOrdenado(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(musicas => musicas.Artista)
            .Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine("Lista de Artista ordenados");
        
        foreach(var artista in artistasOrdenados) 
        {
            Console.WriteLine($"- {artista}");
        }
    }
}