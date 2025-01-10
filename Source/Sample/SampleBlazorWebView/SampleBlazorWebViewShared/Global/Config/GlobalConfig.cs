namespace SampleBlazorWebViewShared.Global.Config;

public class GlobalConfig
{

    private string? _pageMode;
    private bool _expandOnHover;
    private string? _favorite;
    private string? _navigationStyle;

    public GlobalConfig()
    {
        
    }

    public static string PageModeKey { get; set; } = "GlobalConfig_PageMode";

    public static string NavigationStyleKey { get; set; } = "GlobalConfig_NavigationStyle";

    public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfig_ExpandOnHover";

    public static string FavoriteCookieKey { get; set; } = "GlobalConfig_Favorite";

    public EventHandler? NavigationStyleChanged { get; set; }

    public string PageMode
    {
        get => _pageMode ?? PageModes.PageTab;
        set
        {
            _pageMode = value;
        }
    }

    public string NavigationStyle
    {
        get => _navigationStyle ?? NavigationStyles.Flat;
        set
        {
            _navigationStyle = value;
            NavigationStyleChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool ExpandOnHover
    {
        get => _expandOnHover;
        set
        {
            _expandOnHover = value;
        }
    }

    public string? Favorite
    {
        get => _favorite;
        set
        {
            _favorite = value;
        }
    }
}
