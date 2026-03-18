using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace ApiStudy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HttpClient HttpClient { get; private set; } = new();

    }

}
