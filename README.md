# DeryaBilisim.Services.BiBayim.Integration
Derya Bilişim affiliate sistemi(BiBayim) için uygulama entegrasyonu nuget paketi.

## BiBayim Nedir?
BiBayim affiliate sistemi, şirketlerin [BiBayim](https://bibayim.azurewebsites.net) portalı üzerinden üye olarak, sisteme ekleyecekleri ürünleri, Bayi(Dealer) dediğimiz hesaplar üzerinden linkerinin çeşitli mecralarda paylaşılarak, kendi sistemleri ile entegre edilerek satış gerçekleşmesi durumunda Bayi(Dealer) ve diğer sistem paydaşlarına belirlenen komisyon miktarında ücret yazılması ve ödeme takibi yapılabilmesini sağlayan bir sistemdir.

[Buraya Şema Gelecek]

## Gereksinimler
API sistemi BiBayim affiliate sisteminde şirket hesapları içindir. Şirketlerin ürünlerinin linklerini sisteme eklemeleri için Şirket hesabı açmaları gerekmektedir. Ardından **Ayarlar -> Token Üret** adımından sonra gelen ekranda bir erişim anahtarı oluşturmalısınız. Bu erişim anahtarı ile bu nuget paketini projenize ekleyerek ürün satışı ile bibayim sistemine satışı bildirmeniz gerekmektedir.

## Kullanım

### Endpoints
Test Endpoint : https://bibayim-test.azurewebsites.net/

Prod Endpoint : https://bibayim.azurewebsites.net/


**appsettings.json**
```javascript
{
  "BiBayimIntegration": {
    "Endpoint": "https://bibayim-test.azurewebsites.net/",
    "Token": "<<Your-Access-Token>>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

**Startup.cs**
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    var biBayimServiceSettingsSection = Configuration.GetSection("BiBayimIntegration");
    var biBayimServiceEndpoint = biBayimServiceSettingsSection.GetValue<string>("Endpoint");
    var biBayimServiceToken = biBayimServiceSettingsSection.GetValue<string>("Token");
    services.AddBiBayimService(biBayimServiceEndpoint, biBayimServiceToken);
}
```


**HomeController.cs**
```csharp
using DeryaBilisim.BiBayim.Integration.Standart;
using DeryaBilisim.BiBayim.SampleCompanyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DeryaBilisim.BiBayim.SampleCompanyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BiBayimService _biBayimService;

        public HomeController(ILogger<HomeController> logger, BiBayimService biBayimService)
        {
            _logger = logger;
            _biBayimService = biBayimService;
        }

        public IActionResult Index()
        {
            var response = _biBayimService.AddCommissionToDealer(new CommissionApiModel
            {
                ReferalCode = "ASLPLS123",
                ProductId = "295D7988-292B-4E99-831D-2F612E0CAAE1"
            });

            return View();
        }
    }
}
```
