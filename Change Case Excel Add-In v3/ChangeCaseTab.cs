using System.Diagnostics;
using System.Windows.Forms;
using Change_Case_Excel_Add_In_v3.Properties;
using Microsoft.Office.Tools.Ribbon;

namespace Change_Case_Excel_Add_In_v3
{
    public partial class ChangeCaseTab
    {
        private void ChangeCaseTab_Load(object sender, RibbonUIEventArgs e)
        {
            UpperCase.Label = "&" + AppStrings.UpperCase;
            LowerCase.Label = "&" + AppStrings.LowerCase;
            SentenceCase.Label = "&" + AppStrings.SentenceCase;
            ProperCase.Label = "&" + AppStrings.ProperCase;
            ToggleCase.Label = "&" + AppStrings.ToggelCase;
            AlternateCase.Label = "&" + AppStrings.AlternateCase;

            GBtnUpperCase.Label = "&" + AppStrings.UpperCase;
            GBtnLowerCase.Label = "&" + AppStrings.LowerCase;
            GBtnSentenceCase.Label = "&" + AppStrings.SentenceCase;
            GBtnProperCase.Label = "&" + AppStrings.ProperCase;
            GBtnToggleCase.Label = "&" + AppStrings.ToggelCase;
            GBtnAlternateCase.Label = "&" + AppStrings.AlternateCase;


            CbEnableShortcuts.Label = AppStrings.EnableShortcuts;
            CbFirstItemInContextMenu.Label = AppStrings.FirstItemInContextMenu;
            BtnHideTab.Label = AppStrings.HideChangeCaseTab;

            SetScreenTipsAndSuperTips();
            RefreshTabControls();



        }


        private void SetScreenTipsAndSuperTips()
        {

            UpperCase.ScreenTip = AppStrings.UpperCase;
            LowerCase.ScreenTip = AppStrings.LowerCase;
            SentenceCase.ScreenTip = AppStrings.SentenceCase;
            ProperCase.ScreenTip = AppStrings.ProperCase;
            ToggleCase.ScreenTip = AppStrings.ToggelCase;
            AlternateCase.ScreenTip = AppStrings.AlternateCase;

            UpperCase.SuperTip = AppStrings.UpperCaseSt;
            LowerCase.SuperTip = AppStrings.LowerCaseSt;
            SentenceCase.SuperTip = AppStrings.SentenceCaseSt;
            ProperCase.SuperTip = AppStrings.ProperCaseSt;
            ToggleCase.SuperTip = AppStrings.ToggleCaseSt;
            AlternateCase.SuperTip = AppStrings.AlternateCaseSt;

            BtnDonate.ScreenTip = "Donate";
            BtnDonate.SuperTip = AppStrings.DonateButtonSt;

            GrpCcSettings.DialogLauncher.SuperTip = AppStrings.SettingsDialogLauncherSt;
        }

        internal void RefreshTabControls()
        {
            var config = Settings.Default;
            CbEnableShortcuts.Checked = config.enableShortCuts;
            CbFirstItemInContextMenu.Checked = config.firstItemInContextMenu;
            ChangeCase.ShowChangeCaseTabInRibbon(config.showChangeCaseTab);
            ChangeCase.ShowChangeCaseOptionInHomeTab(config.showChangeCaseOptionInHomeTab);
        }



        private void UpperCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.UpperCase);
        }

        private void LowerCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.LowerCase);
        }

        private void SentenceCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.SentenceCase);
        }

        private void ProperCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.ProperCase);
        }

        private void ToggleCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.ToggelCase);
        }

        private void AlternateCase_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.Cc(AppStrings.AlternateCase);
        }

        private void BtnHideTab_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.ShowChangeCaseTabInRibbon(false);
        }

        private void CbEnableShortcuts_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.EnableSc(CbEnableShortcuts.Checked);
        }

        private void CbFirst_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeCase.FirstInMenu(CbFirstItemInContextMenu.Checked);
        }

        private void GrpCcSettings_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            var setWindow = new MyCcSettings();
            setWindow.ShowDialog();
        }

        private void BtnDonate_Click(object sender, RibbonControlEventArgs e)
        {
            if (InternetConnection.IsConnected())
                Process.Start(AppStrings.DonationUrl);
            else
                MessageBox.Show(Resources.NoInternetConnectionMessage, Resources.WindowTitle);
        }
    }
}
