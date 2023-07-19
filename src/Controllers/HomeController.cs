using Microsoft.AspNetCore.Mvc;
using MyTube.Models;

namespace MyTube.Controllers;

public class HomeController : Controller
{
    private const string RootPath = "wwwroot/video";

    public IActionResult Index()
        => RedirectToAction("Explorer", new { path = RootPath });

    public IActionResult Explorer(string path)
    {
        var model = GetNodes(path);
        return View(model);
    }

    public IActionResult Player(string path) => View(model: path);

    private static IEnumerable<Node> GetNodes(string path)
    {
        var result = new List<Node>();

        foreach (var directory in Directory.GetDirectories(path))
        {
            result.Add(new Node
            {
                Name = Path.GetFileName(directory),
                Path = directory,
                Type = NodeType.Directory
            });
        }

        foreach (var file in Directory.GetFiles(path))
        {
            if (!Path.GetExtension(file).EndsWith(".mp4")) continue;

            result.Add(new Node
            {
                Name = Path.GetFileNameWithoutExtension(file),
                Path = file.Replace("wwwroot", ""),
                Type = NodeType.File
            });
        }

        return result.ToArray();
    }
}
