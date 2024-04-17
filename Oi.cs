
public class Personagem
{
    protected double temperatura = 0.1;
    protected double chuva = 20;
    protected double vento = 50.2;

    public string Nome = "Joao";

    public bool Morto = false;

    public Briquendo toy = new Briquendo();
}

public class Brinquedo
{
    public string Name {get; set;} = "Bolinha";
    public string Cor {get;set;} = "#ff0000";
}



JSON
-------------

{
    "temperatura": 0.1,
    "chuva": 20,
    "nome": "Joao",
    "morto": true,
    "data": "2024-12-02",
    "toy":
    {
        "name": "Bolinha",
        "cor": "#ff0000"
    }
}