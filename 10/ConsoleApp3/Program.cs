using System;

// Продукт - HTML-страница
class HTMLPage
{
    public string Content { get; set; }

    public void DisplayPage()
    {
        Console.WriteLine(Content);
    }
}

// Интерфейс строителя
interface IHTMLBuilder
{
    void BuildHeader();
    void BuildBody();
    void BuildFooter();
    HTMLPage GetPage();
}

// Конкретный строитель для создания базовой HTML-страницы
class BasicHTMLBuilder : IHTMLBuilder
{
    private HTMLPage _page = new HTMLPage();

    public void BuildHeader()
    {
        _page.Content += "<header>This is a basic header</header>\n";
    }

    public void BuildBody()
    {
        _page.Content += "<body>This is a basic body</body>\n";
    }

    public void BuildFooter()
    {
        _page.Content += "<footer>This is a basic footer</footer>\n";
    }

    public HTMLPage GetPage()
    {
        return _page;
    }
}

// Конкретный строитель для создания HTML-страницы с Bootstrap
class BootstrapHTMLBuilder : IHTMLBuilder
{
    private HTMLPage _page = new HTMLPage();

    public void BuildHeader()
    {
        _page.Content += "<header class='bootstrap-header'>This is a Bootstrap header</header>\n";
    }

    public void BuildBody()
    {
        _page.Content += "<body class='bootstrap-body'>This is a Bootstrap body</body>\n";
    }

    public void BuildFooter()
    {
        _page.Content += "<footer class='bootstrap-footer'>This is a Bootstrap footer</footer>\n";
    }

    public HTMLPage GetPage()
    {
        return _page;
    }
}

// Конкретный строитель для создания HTML-страницы с Material UI
class MaterialUIHTMLBuilder : IHTMLBuilder
{
    private HTMLPage _page = new HTMLPage();

    public void BuildHeader()
    {
        _page.Content += "<header class='material-ui-header'>This is a Material UI header</header>\n";
    }

    public void BuildBody()
    {
        _page.Content += "<body class='material-ui-body'>This is a Material UI body</body>\n";
    }

    public void BuildFooter()
    {
        _page.Content += "<footer class='material-ui-footer'>This is a Material UI footer</footer>\n";
    }

    public HTMLPage GetPage()
    {
        return _page;
    }
}

class Program
{
    static void Main()
    {
        HTMLPage page;
        IHTMLBuilder builder;

        // Строитель для базовой HTML-страницы
        builder = new BasicHTMLBuilder();
        builder.BuildHeader();
        builder.BuildBody();
        builder.BuildFooter();
        page = builder.GetPage();
        Console.WriteLine("Basic HTML Page:");
        page.DisplayPage();

        // Строитель для HTML-страницы с Bootstrap
        builder = new BootstrapHTMLBuilder();
        builder.BuildHeader();
        builder.BuildBody();
        builder.BuildFooter();
        page = builder.GetPage();
        Console.WriteLine("\nHTML Page with Bootstrap:");
        page.DisplayPage();

        // Строитель для HTML-страницы с Material UI
        builder = new MaterialUIHTMLBuilder();
        builder.BuildHeader();
        builder.BuildBody();
        builder.BuildFooter();
        page = builder.GetPage();
        Console.WriteLine("\nHTML Page with Material UI:");
        page.DisplayPage();
    }
}