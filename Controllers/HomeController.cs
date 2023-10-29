using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoogleOIDCNetCore.Models;

using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;

namespace GoogleOIDCNetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [GoogleScopedAuthorize(DriveService.ScopeConstants.DriveReadonly)]
    public async Task<IActionResult> Index([FromServices] IGoogleAuthProvider auth)
    {
        GoogleCredential cred = await auth.GetCredentialAsync();
        var service = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = cred
        });
        var files = await service.Files.List().ExecuteAsync();
        var fileNames = files.Files.Select(f => f.Name).ToList();
        return View(new HomeViewModel() { FileNames = fileNames});
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