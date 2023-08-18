using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using Newtonsoft.Json;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGameSearchController : ControllerBase
{

    private readonly ILogger<BoardGameSearchController> _logger;

    public BoardGameSearchController(ILogger<BoardGameSearchController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBoardGameSearch")]
    public async Task<string> Get()
    {
        var searchQuery = "arknova";
        var searchResult = WebParse(searchQuery);
        return searchResult;
    }
    public string WebParse(string search)
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load($"https://www.lautapelit.fi/search/?q={search}");
        var title = document.DocumentNode.SelectNodes("//*[@id=\"45539\"]/div[3]");
        //TODO heivaa title looppina normi listaan
        //List<HtmlAgilityPack.HtmlNodeCollection> getTitle = title.ToList();
        //var searchList = title.Cast<string>().ToList();
        List<HtmlAgilityPack.HtmlNodeCollection> searchList = new List<BoardGameSearch>().Cast<HtmlAgilityPack.HtmlNodeCollection>().ToList();
        _logger.LogInformation($"Teksti: {title}");
        var myData = new
        {
            Title = "arknova",
            Price = "70",
        };
        string jsonData = JsonConvert.SerializeObject(myData);

        return jsonData;
    }
}
