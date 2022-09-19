namespace av3.Models;

public class Loja
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Email { get; set; }
    public string Tipo { get; set; }
    public int Id { get; set; }
    public int Piso { get; set; }

    public Loja(string nome, string descricao, string email, string tipo, int id, int piso)
    {
        Nome = nome;
        Descricao = descricao;
        Email = email;
        Tipo = tipo;
        Id = id;
        Piso = piso;
    }

}