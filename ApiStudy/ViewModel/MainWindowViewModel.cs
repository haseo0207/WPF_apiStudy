using ApiStudy.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ApiStudy.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ItemModel> _items = [];

        [ObservableProperty]
        private ItemModel? _selectedItem;

        public IAsyncRelayCommand ApiResponseCommand { get; set; }

        public MainWindowViewModel()
        {
            ApiResponseCommand = new AsyncRelayCommand(OnApiResponse);
        }

        private async Task OnApiResponse()
        {
            var json = await App.HttpClient.GetStringAsync("https://apis.data.go.kr/1262000/NoticeService2/getNoticeList2?serviceKey=31c8d990afe2c38aab94aa316da639ad81cf5a1fa1a145d806f0e9bac3a56ccb&returnType=JSON&numOfRows=10&pageNo=1");
            var result = JsonSerializer.Deserialize<JsonResponseModel>(json);

            Items.Clear();
            if (result?.Response.BodyItem.Items.Item is List<ItemModel> items)
            {
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
        }
    }
}
