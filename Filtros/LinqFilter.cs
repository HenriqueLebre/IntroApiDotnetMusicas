using IntroApiDotnetMusicas.Models;

namespace IntroApiDotnetMusicas.Filtros;

internal class LinqFilter
{
    public static void FiltraTodosGenerosMusicais(List<Musica> musicas)
    {
        var Generos = musicas.Select(generos => 
        generos.Genero).Distinct().ToList();

        foreach(var genero in Generos) 
        {
            Console.WriteLine($"- {genero}");
        }

    } 

    public static void FiltrarArtistaPorGeneroMusical(List<Musica> musicas,
        string genero)
    {
        var artistasPorGeneroMusical = musicas.
            Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista)
            .Distinct().ToList();
        Console.WriteLine($"Exibindo os artistas por genero musical -> {genero}");
        foreach(var artista in artistasPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string 
        nomeDoArtista) 
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine($"Artista - {nomeDoArtista}");
        foreach(var musica in musicasDoArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

}
