namespace SampleBlazorWebViewShared.Global.Nav;

public class NavHelper
{
    private List<NavModel> _navList;
    private NavigationManager _navigationManager;

    public List<NavModel> Navs { get; } = new();

    public List<NavModel> SameLevelNavs { get; } = new();

    public List<PageTabItem> PageTabItems { get; } = new();

    public string CurrentUri => _navigationManager.Uri;

    public NavHelper(List<NavModel> navList, NavigationManager navigationManager)
    {
        _navList = navList;
        _navigationManager = navigationManager;
        Initialization();
    }

    private void Initialization()
    {
        _navList.ForEach(nav =>
        {
            if (nav.Hide is false) Navs.Add(nav);

            if (nav.Children is not null)
            {
                nav.Children = nav.Children.Where(c => c.Hide is false).ToArray();

               
            }
        });

        Navs.ForEach(nav =>
        {
            SameLevelNavs.Add(nav);
            if (nav.Children is not null) SameLevelNavs.AddRange(nav.Children);
        });

        
    }

    public void NavigateTo(NavModel nav)
    {
        _navigationManager.NavigateTo(nav.Href ?? "");
    }

    public void NavigateTo(string href)
    {
        _navigationManager.NavigateTo(href);
    }
}

public record PageTabItem(string Title, string Href, string Icon);
