using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace CrudStudy;

public partial class App : Application
{
    public static HttpClient HttpClient { get; } =new HttpClient();
}
