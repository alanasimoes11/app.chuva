using System.Text.Json;

namespace app.chuva;

public partial class MainPage : ContentPage
{

const string url="https://api.hgbrasil.com/weather?woeid=455927&key=1c17155a";

Resposta resposta;

	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();
	}


async void AtualizaTempo() 
	{
		try
		{
			var navegador = new HttpClient();
			var response = await navegador.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}

			PreencherTela();
		}
		catch (Exception)	
		{
			//erro
		}
	}
	
	
  void PreencherTela()
  {
	Labeltemp.Text = resposta.results.temp.ToString();
    Labeldescription.Text = resposta.results.description;
	Labelcity.Text = resposta.results.city;
	Labelrain.Text = resposta.results.rain.ToString();
	Labelhumidity.Text =resposta.results.humidity.ToString();
	Labelsunrise.Text =resposta.results.sunrise;
    Labelsunset.Text =resposta.results.sunset;
	Labelwind_speedy.Text =resposta.results.wind_speedy;
	Labelwind_direction.Text =resposta.results.wind_direction.ToString();
	Labelmoon_phase.Text =resposta.results.moon_phase;
	//Labelcurrently .Text =resposta.results.currently;
	//Labelcodition_code .Text =resposta.results.codition_code.ToString();
   // Labelimg_id.Text =resposta.results.img_id.ToString();
   //Labelcloudiness.Text =resposta.results.cloudiness.ToString();
    //Labelwind_cardinal.Text =resposta.results.wind_cardinal.ToString();
	if(resposta.results.moon_phase=="full")
		 Labelmoon_phase.Text = "Cheia";
		else if(resposta.results.moon_phase=="new")
		 Labelmoon_phase.Text = "Nova";
		else if(resposta.results.moon_phase=="growing")
			Labelmoon_phase.Text = "Crescente";
		else if(resposta.results.moon_phase=="waning")
			Labelmoon_phase.Text = "minguante";


		if(resposta.results.currently=="dia")
		{
			if(resposta.results.rain>=10)
			imgFundo.Source="diachuva.jpg";
			else if(resposta.results.cloudiness>=10)
			imgFundo.Source="dianublado.jpg";
			else
			imgFundo.Source="diasol.jpg";
		}
		else
		{
			if(resposta.results.rain>=10)
			 imgFundo.Source="noitechuvosa.jpg";
			 else if (resposta.results.cloudiness>=10)
			 imgFundo.Source="noitenublada.jpg";
			 else
			 imgFundo.Source="noiteestrelada.jpg";
		}
	
}
}
