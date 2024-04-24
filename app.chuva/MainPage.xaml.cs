using Windows.ApplicationModel.AppService;

namespace app.chuva;

public partial class MainPage : ContentPage
{


const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=1c17155a";
Resposta resposta;.
	public MainPage()
	{
		InitializeComponent();
		PreencherTela();
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
	Labelmoon_phase .Text =resposta.results.moon_phase.ToString();
	Labelcurrently .Text =resposta.results.currently .ToString();
	Labelcodition_code .Text =resposta.results.codition_code.ToString();
    Labelimg_id.Text =resposta.results.img_id.ToString();
    Labelcloudiness.Text =resposta.results.cloudiness.ToString();
    Labelwind_cardinal.Text =resposta.results.wind_cardinal.ToString();


	if(resposta.results.currently=="dia")
      {
		if (resposta.results.rain>=10)
		ImgFundo.Source="diachuva.jpg";
		else if (resposta.results.cloudiness>=10)
		ImgFundo.Source="dianublado.jpg";
		else
		ImgFundo.Source="diasol.jpg";
	  }




  }


	
}
