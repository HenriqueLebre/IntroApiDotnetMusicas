using IntroApiDotnetMusicas.Models;
using System.Text.Json;
using IntroApiDotnetMusicas.Models;
using IntroApiDotnetMusicas.Filtros;

using (HttpClient client = new HttpClient())
{
	try
	{

		string resposta = await client.GetStringAsync
			("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

		var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

		//LinqFilter.FiltraTodosGenerosMusicais(musicas);
		//LinqOrder.ExibirListaPorArtistaOrdenado(musicas);
		//LinqFilter.FiltrarArtistaPorGeneroMusical(musicas, "blues");
		//LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Michael Jackson");

		var musicasPreferidas = new MusicasPreferidas("Prefs");
		musicasPreferidas.AdcionarMusicasFavoritas(musicas[1]);
        musicasPreferidas.AdcionarMusicasFavoritas(musicas[3]);
        musicasPreferidas.AdcionarMusicasFavoritas(musicas[9]);
        musicasPreferidas.AdcionarMusicasFavoritas(musicas[1000]);
        musicasPreferidas.AdcionarMusicasFavoritas(musicas[500]);

		musicasPreferidas.ExibirMusicasFavoritas();
		musicasPreferidas.GerarArquivoJson();


    }
	catch (Exception ex)
	{

        Console.WriteLine($"Obtivemos um erro na requisição da API, valide as informações: {ex.Message}");
    }

}