using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using av3.Models;


namespace av3.Controllers;

public class HomeController : Controller
{
    private static List<Loja> lojas = new List<Loja>();


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.lojas = lojas;
        return View();
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Cadastrar([FromForm] int id, [FromForm] int piso, [FromForm] string nome, [FromForm] string email, [FromForm] string descricao, [FromForm] string tipo)
    {
        foreach (Loja loja in lojas)
        {
            if (loja.Id == id || loja.Nome == nome)
            {
                return Content("Loja já cadastrado");
            }
        }
        lojas.Add(new Loja(nome, descricao, email, tipo, id, piso));
        return View("Cadastro");
    }

    public IActionResult Gerenciamento()
    {
        ViewBag.lojas = lojas;
        return View();
    }

    public IActionResult Remover([FromForm] int id)
    {
        foreach (Loja loja in lojas)
        {
            if (loja.Id == id)
            {
                lojas.Remove(loja);
                return Content("Loja removido com sucesso");
            }
        }

        return Content("Não foi possível remover");
    }

    public IActionResult Detalhes([FromForm] int id)
    {
        foreach (Loja loja in lojas)
        {
            if (loja.Id == id)
            {
                return View(loja);
            }
        }

        return Content("Não foi possível mostrar os detalhes");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
