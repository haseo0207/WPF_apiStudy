using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApiStudy.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _apiResponse = string.Empty;
        public IAsyncRelayCommand ApiResponseCommand { get; set; }
        public MainWindowViewModel()
        {
            ApiResponseCommand = new AsyncRelayCommand(OnApiResponse);
        }

        private async Task OnApiResponse()
        {
            ApiResponse = await App.HttpClient.GetStringAsync("https://apis.data.go.kr/1262000/NoticeService2/getNoticeList2?serviceKey=31c8d990afe2c38aab94aa316da639ad81cf5a1fa1a145d806f0e9bac3a56ccb&returnType=JSON&numOfRows=10&pageNo=1");
        }
    }
}
