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
        public RulesSubRulesPage(List<Models.SocietyRulesListResponse> societyRulesList, string societyName)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new RulesSubRulesPageViewModel(this.Navigation);
            viewModel.SocietyRulesList = societyRulesList;
            lblSocietyName.Text = societyName;
        }

        private void OnRuleTapped(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.SocietyRulesListResponse societyRules = label.BindingContext as Models.SocietyRulesListResponse;
            societyRules.IsShowSubRules = !societyRules.IsShowSubRules;
            if (societyRules.IsShowSubRules)
                societyRules.RuleBg = Color.FromHex("#242A37");
            else
                societyRules.RuleBg = Color.FromHex("#181A1F");
        }
    }
}