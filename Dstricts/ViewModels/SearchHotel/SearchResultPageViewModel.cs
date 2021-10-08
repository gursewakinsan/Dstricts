using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class SearchResultPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchResultPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SearchInfoList = new ObservableCollection<SearchInfo>();
			for (int i = 0; i < 10; i++)
			{
				SearchInfoList.Add(new SearchInfo()
				{
					Url= "https://www.pngtosvg.com/wp-content/uploads/2018/08/pngtosvghome.jpg",
					Name = $"Name {i}",
					Details = $"Details {i}"
				});
			}
		}
		#endregion

		#region Search Result Command.
		private ICommand searchResultCommand;
		public ICommand SearchResultCommand
		{
			get => searchResultCommand ?? (searchResultCommand = new Command(async () => await ExecuteSearchResultCommand()));
		}
		private async Task ExecuteSearchResultCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public ObservableCollection<SearchInfo> SearchInfoList { get; set; }
		#endregion
	}
}

public class SearchInfo
{
	public string Url { get; set; }
	public string Name { get; set; }
	public string Details { get; set; }
}
