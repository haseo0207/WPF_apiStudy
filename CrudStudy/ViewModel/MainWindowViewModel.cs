using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudStudy.Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CrudStudy.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

    [ObservableProperty]
    private ObservableCollection<PostModel> _posts = [];

    [ObservableProperty]
    private PostModel? _selectedPost;

    [ObservableProperty]
    private string _editId = string.Empty;

    [ObservableProperty]
    private string _editTitle = string.Empty;

    [ObservableProperty]
    private string _editBody = string.Empty;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public IAsyncRelayCommand GetAllCommand { get; }
    public IAsyncRelayCommand CreateCommand { get; }
    public IAsyncRelayCommand UpdateCommand { get; }
    public IAsyncRelayCommand DeleteCommand { get; }

    public MainWindowViewModel()
    {
        GetAllCommand = new AsyncRelayCommand(OnGetAll);
        CreateCommand = new AsyncRelayCommand(OnCreate);
        UpdateCommand = new AsyncRelayCommand(OnUpdate);
        DeleteCommand = new AsyncRelayCommand(OnDelete);
    }

    // 목록에서 선택 시 우측 폼에 반영
    partial void OnSelectedPostChanged(PostModel? value)
    {
        if (value is not null)
        {
            EditId = value.Id.ToString();
            EditTitle = value.Title;
            EditBody = value.Body;
        }
    }

    // GET - 전체 조회
    private async Task OnGetAll()
    {
        EditId = string.Empty;
        EditTitle = string.Empty;
        EditBody = string.Empty;
        StatusMessage = "로드중...";

        var json = await App.HttpClient.GetStringAsync(BaseUrl);
        var results = JsonSerializer.Deserialize<PostModel[]>(json);

        if (results is null)
            return;

        Posts.Clear();

        foreach (var result in results)
        {
            Posts.Add(result);
        }

        StatusMessage = "완료!";
    }

    // POST - 새 글 작성
    private async Task OnCreate()
    {
        StatusMessage = "작성중...";

        PostModel postModel = new()
        {
            Title = EditTitle,
            Body = EditBody
        };

        var json = JsonSerializer.Serialize(postModel);
        StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await App.HttpClient.PostAsync(BaseUrl, stringContent);
        var responseBody = await response.Content.ReadAsStringAsync();

        StatusMessage = responseBody;
    }

    // PUT - 글 수정
    private async Task OnUpdate()
    {
        if (String.IsNullOrEmpty(EditId))
        {
            StatusMessage = "글을 선택해 주세요.";
            return;
        }

        StatusMessage = "수정중...";

        PostModel postModel = new()
        {
            Id = Convert.ToInt32(EditId),
            Title = EditTitle,
            Body = EditBody
        };

        var json = JsonSerializer.Serialize(postModel);
        StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await App.HttpClient.PutAsync(BaseUrl + "/" + EditId, stringContent);
        var responseBody = await response.Content.ReadAsStringAsync();

        StatusMessage = responseBody;
    }

    // DELETE - 글 삭제
    private async Task OnDelete()
    {
        if (String.IsNullOrEmpty(EditId))
        {
            StatusMessage = "글을 선택해 주세요.";
            return;
        }

        StatusMessage = "삭제중...";

        var response = await App.HttpClient.DeleteAsync(BaseUrl + "/" + EditId);
        var responseBody = await response.Content.ReadAsStringAsync();

        EditId = string.Empty;
        EditTitle = string.Empty;
        EditBody = string.Empty;

        StatusMessage = responseBody;
    }
}
