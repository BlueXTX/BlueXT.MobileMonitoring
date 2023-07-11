using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Localization;
using Volo.Abp.OpenIddict.Applications;

namespace BlueXT.MobileMonitoring.Pages;

/// <summary>
/// Модель страницы Index.
/// </summary>
public class IndexModel : AbpPageModel
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="openIdApplicationRepository">Репозиторий OpenId.</param>
    /// <param name="languageProvider">Провайдер языка.</param>
    public IndexModel(IOpenIddictApplicationRepository openIdApplicationRepository, ILanguageProvider languageProvider)
    {
        OpenIdApplicationRepository = openIdApplicationRepository;
        LanguageProvider = languageProvider;
    }

    /// <summary>
    /// Список приложений OpenIddict.
    /// </summary>
    public List<OpenIddictApplication>? Applications { get; protected set; }

    /// <summary>
    /// Языки.
    /// </summary>
    public IReadOnlyList<LanguageInfo>? Languages { get; protected set; }

    /// <summary>
    /// Текущий язык.
    /// </summary>
    public string? CurrentLanguage { get; protected set; }

    /// <summary>
    /// Репозиторий приложений OpenIddict.
    /// </summary>
    protected IOpenIddictApplicationRepository OpenIdApplicationRepository { get; }

    /// <summary>
    /// Провайдер языка.
    /// </summary>
    protected ILanguageProvider LanguageProvider { get; }

    /// <summary>
    /// Входящий http get запрос.
    /// </summary>
    /// <returns>Задача.</returns>
    public async Task OnGetAsync()
    {
        Applications = await OpenIdApplicationRepository.GetListAsync();

        Languages = await LanguageProvider.GetLanguagesAsync();
        CurrentLanguage = CultureInfo.CurrentCulture.DisplayName;
    }
}
