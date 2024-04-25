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
		catch (Exception e)	
		{
			//erro
		}
	}
	
	
  void PreencherTela()
  {
	Labeltemp.Text = resposta.results.temp.ToString();
    Labeldescription.Text = resposta.results.description.ToString();
	Labelcity.Text = resposta.results.city.ToString();
	Labelrain.Text = resposta.results.rain.ToString();
	Labelhumidity.Text =resposta.results.humidity.ToString();
	Labelsunrise.Text =resposta.results.sunrise.ToString();
    Labelsunset.Text =resposta.results.sunset.ToString();
	Labelwind_speedy.Text =resposta.results.wind_speedy.ToString();
	Labelwind_direction.Text =resposta.results.wind_direction.ToString();
	//Labelmoon_phase .Text =resposta.results.moon_phase.ToString();
	//Labelcurrently .Text =resposta.results.currently .ToString();
	//Labelcodition_code .Text =resposta.results.codition_code.ToString();
   // Labelimg_id.Text =resposta.results.img_id.ToString();
    //Labelcloudiness.Text =resposta.results.cloudiness.ToString();
    //Labelwind_cardinal.Text =resposta.results.wind_cardinal.ToString();
	//if(resposta.results.moon_phase=="full")
			//labeldafasedalua.Text = "Cheia";
		//else if(resposta.results.moon_phase=="new")
		//	labeldafasedalua.Text = "Nova";
		//else if(resposta.results.moon_phase=="growing")
			//labeldafasedalua.Text = "Crescente";
		//else if(resposta.results.moon_phase=="waning")
			//labeldafasedalua.Text = "minguante";


		if(resposta.results.currently=="dia")
		{
			if(resposta.results.rain>=10)
			imgFundo.Source="diachuvoso.png";
			else if(resposta.results.cloudiness>=10)
			imgFundo.Source="dianublado.png";
			else
			imgFundo.Source="diaensolarado";
		}
		else
		{
			if(resposta.results.rain>=10)
			 imgFundo.Source="noitechuvosa.png";
			 else if (resposta.results.cloudiness>=10)
			 imgFundo.Source="noitenublada.png";
			 else
			 imgFundo.Source="noiteestrelada.png";
		}
	
}
}
