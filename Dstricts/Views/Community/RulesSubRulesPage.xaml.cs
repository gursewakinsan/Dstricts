using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RulesSubRulesPage : ContentPage
    {
        RulesSubRulesPageViewModel viewModel;
        public RulesSubRulesPage(List<Models.SocietyRulesListResponse> societyRulesList)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new RulesSubRulesPageViewModel(this.Navigation);
            viewModel.SocietyRulesList = societyRulesList;
        }
    }
}