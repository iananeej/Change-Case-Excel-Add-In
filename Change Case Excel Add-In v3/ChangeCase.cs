using System;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace Change_Case_Excel_Add_In_v3
{
    public partial class ChangeCase
    {
        #region Declarations

        private const string SubMenuTag = "AneejianChangeCaseSubMenu";
        public const string NoSc = "None";
        public static bool FirstTime;
        public Office.CommandBarButton BtnUpperCase;
        public Office.CommandBarButton BtnLowerCase;
        public Office.CommandBarButton BtnProperCase;
        public Office.CommandBarButton BtnSentenceCase;
        public Office.CommandBarButton BtnToggleCase;
        public Office.CommandBarButton BtnAlternateCase;
        public Office.CommandBarButton BtnEnableShortcuts;
        public Office.CommandBarButton BtnShowChangeCaseTab;
        public Office.CommandBarButton BtnFirstInMenu;
        public Office.CommandBarButton BtnSettings;
        public Office.CommandBarButton BtnAbout;

        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += new EventHandler(ChangeCase_Startup);
            Shutdown += new EventHandler(ChangeCase_Shutdown);
        }

        #endregion

        private void ChangeCase_Startup(object sender, EventArgs e)
        {
            //Adding Sheet Before Right Click event
            var app = Application;
            app.SheetBeforeRightClick += App_SheetBeforeRightClick;

            //Enabling or disabling shortcut feature based on settings
            EnableShortCuts(Properties.Settings.Default.enableShortCuts);
        }

        private void ChangeCase_Shutdown(object sender, EventArgs e)
        {
            //Disabling shortcut feature
            EnableShortCuts(false);
        }

        //Sheet Before Right Click event
        private void App_SheetBeforeRightClick(object sheet, Excel.Range target, ref bool cancel)
        {
            AddContextMenu();
        }

        //Method to enable or disable shortcut feature
        internal static void EnableShortCuts(bool enable)
        {
            if (enable)
            {
                KbHook.SetHook();
                var config = Properties.Settings.Default;
                if (CheckSc("U")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScUpperCase + "}", "");
                if (CheckSc("L")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScLowerCase + "}", "");
                if (CheckSc("S")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScSentenceCase + "}", "");
                if (CheckSc("P")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScProperCase + "}", "");
                if (CheckSc("T")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScToggleCase + "}", "");
                if (CheckSc("A")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScAlternateCase + "}", "");
            }
            else
            {
                KbHook.ReleaseHook();
                var config = Properties.Settings.Default;
                if (CheckSc("U")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScUpperCase + "}");
                if (CheckSc("L")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScLowerCase + "}");
                if (CheckSc("S")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScSentenceCase + "}");
                if (CheckSc("P")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScProperCase + "}");
                if (CheckSc("T")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScToggleCase + "}");
                if (CheckSc("A")) Globals.ChangeCase.Application.OnKey("+^{" + config.ScAlternateCase + "}");
            }
        }

        //Method to check whether valid shortcut key is set in settings
        private static bool CheckSc(string sctype)
        {
            var config = Properties.Settings.Default;
            switch (sctype)
            {
                case "U":
                    return config.ScUpperCase != NoSc;
                case "L":
                    return config.ScLowerCase != NoSc;
                case "S":
                    return config.ScSentenceCase != NoSc;
                case "P":
                    return config.ScProperCase != NoSc;
                case "T":
                    return config.ScToggleCase != NoSc;
                case "A":
                    return config.ScAlternateCase != NoSc;
                default:
                    return false;
            }
        }

        private void AddContextMenu()
        {
            //Removing sub menu if it already exist
            DeleteSubMenu();

            var cellBar = Application.CommandBars["Cell"];
            var menuPosition = Properties.Settings.Default.firstItemInContextMenu ? 1 : cellBar.Controls.Count;

            //Adding Change Case Sub Menu
            var changeCaseSubMenu =
                (Office.CommandBarPopup)
                    cellBar.Controls.Add(Office.MsoControlType.msoControlPopup, Temporary: true, Before: menuPosition);
            changeCaseSubMenu.Caption = "&" + AppStrings.ChangeCase;
            changeCaseSubMenu.Tag = SubMenuTag;
            changeCaseSubMenu.BeginGroup = true;

            //Adding Upper Case button
            BtnUpperCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnUpperCase.Caption = "&" + AppStrings.UpperCase;
            BtnUpperCase.Tag = AppStrings.UpperCase;
            BtnUpperCase.FaceId = 1144;

            //Adding Lower Case button
            BtnLowerCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnLowerCase.Caption = "&" + AppStrings.LowerCase;
            BtnLowerCase.Tag = AppStrings.LowerCase;
            BtnLowerCase.FaceId = 1145;

            //Adding Proper Case button
            BtnProperCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnProperCase.Caption = "&" + AppStrings.ProperCase;
            BtnProperCase.Tag = AppStrings.ProperCase;
            BtnProperCase.FaceId = 1155;

            //Adding Sentence Case button
            BtnSentenceCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnSentenceCase.Caption = "&" + AppStrings.SentenceCase;
            BtnSentenceCase.Tag = AppStrings.SentenceCase;
            BtnSentenceCase.FaceId = 1154;

            //Adding Toggle Case button
            BtnToggleCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnToggleCase.Caption = "&" + AppStrings.ToggelCase;
            BtnToggleCase.Tag = AppStrings.ToggelCase;
            BtnToggleCase.FaceId = 1148;

            //Adding Alternate Case button
            BtnAlternateCase =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnAlternateCase.Caption = "&" + AppStrings.AlternateCase;
            BtnAlternateCase.Tag = AppStrings.AlternateCase;
            BtnAlternateCase.FaceId = 1157;

            //Adding Show or Hide Change Case Tab button
            BtnShowChangeCaseTab =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnShowChangeCaseTab.BeginGroup = true;
            var showTab = Properties.Settings.Default.showChangeCaseTab;
            if (showTab)
            {
                BtnShowChangeCaseTab.Caption = AppStrings.HideChangeCaseTab;
                BtnShowChangeCaseTab.FaceId = 6850;
            }
            else
            {
                BtnShowChangeCaseTab.Caption = AppStrings.ShowChangeCaseTab;
                BtnShowChangeCaseTab.FaceId = 6852;
            }

            //Adding Enable or Disable Shortcuts button
            BtnEnableShortcuts =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            var enableShortcuts = Properties.Settings.Default.enableShortCuts;
            if (enableShortcuts)
            {
                BtnEnableShortcuts.Caption = AppStrings.DisableShortcuts;
                BtnEnableShortcuts.FaceId = 6850;
            }
            else
            {
                BtnEnableShortcuts.Caption = AppStrings.EnableShortcuts;
                BtnEnableShortcuts.FaceId = 6852;
            }

            //Adding First in menu button
            BtnFirstInMenu =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            var firstInMenu = Properties.Settings.Default.firstItemInContextMenu;
            if (firstInMenu)
            {
                BtnFirstInMenu.Caption = AppStrings.LastItemInContextMenu;
                BtnFirstInMenu.FaceId = 6850;
            }
            else
            {
                BtnFirstInMenu.Caption = AppStrings.FirstItemInContextMenu;
                BtnFirstInMenu.FaceId = 6852;
            }

            //Add Settings Button
            BtnSettings =
                (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnSettings.Caption = AppStrings.Settings;
            BtnSettings.FaceId = 943;

            //Add About Button
            BtnAbout = (Office.CommandBarButton) changeCaseSubMenu.Controls.Add(Office.MsoControlType.msoControlButton);
            BtnAbout.Caption = AppStrings.About;
            BtnAbout.FaceId = 487;

            //Setting button events
            BtnUpperCase.Click += BtnClickCc;
            BtnLowerCase.Click += BtnClickCc;
            BtnProperCase.Click += BtnClickCc;
            BtnSentenceCase.Click += BtnClickCc;
            BtnToggleCase.Click += BtnClickCc;
            BtnAlternateCase.Click += BtnClickCc;
            BtnShowChangeCaseTab.Click += BtnClickShowCcTab;
            BtnEnableShortcuts.Click += BtnClickEnableShortCuts;
            BtnFirstInMenu.Click += BtnClickFirstInMenu;
            BtnSettings.Click += BtnClickSettings;
            BtnAbout.Click += BtnClickAbout;

            FirstTime = true;
        }

        private static void DeleteSubMenu()
        {
            try
            {
                Globals.ChangeCase.Application.CommandBars["Cell"].Controls[AppStrings.ChangeCase].Delete();
            }
            catch
            {
                //ignored
            }
        }

        internal static void RestoreSettings()
        {
            Properties.Settings.Default.Reset();
        }

        internal static void RefreshControls()
        {
            var config = Properties.Settings.Default;
            ShowChangeCaseTabInRibbon(config.showChangeCaseTab);
            ShowChangeCaseOptionInHomeTab(config.showChangeCaseOptionInHomeTab);
            Globals.Ribbons.ChangeCaseTab.CbEnableShortcuts.Checked = config.enableShortCuts;
            Globals.Ribbons.ChangeCaseTab.CbFirstItemInContextMenu.Checked = config.firstItemInContextMenu;
        }



        #region Context Menu Button Events

        private static void BtnClickCc(Office.CommandBarButton control, ref bool target)
        {
            if (FirstTime)
            {
                Cc(control.Tag);
            }
            FirstTime = false;
        }

        private static void BtnClickShowCcTab(Office.CommandBarButton control, ref bool target)
        {
            ShowChangeCaseTabInRibbon(!Properties.Settings.Default.showChangeCaseTab);
        }

        private static void BtnClickEnableShortCuts(Office.CommandBarButton control, ref bool target)
        {
            EnableSc(!Properties.Settings.Default.enableShortCuts);
        }

        private static void BtnClickFirstInMenu(Office.CommandBarButton control, ref bool target)
        {
            FirstInMenu(!Properties.Settings.Default.firstItemInContextMenu);
        }

        private static void BtnClickSettings(Office.CommandBarButton control, ref bool target)
        {
            var setWindow = new MyCcSettings();
            setWindow.ShowDialog();
        }

        private static void BtnClickAbout(Office.CommandBarButton control, ref bool target)
        {
            var abtWindow = new AboutBox();
            abtWindow.ShowDialog();
        }

        #endregion

        public static void ShowChangeCaseTabInRibbon(bool show)
        {
            try
            {
                Globals.Ribbons.ChangeCaseTab.TabChangeCase.Visible = show;
            }
            catch
            {
                // ignore
            }
            Properties.Settings.Default.showChangeCaseTab = show;
            Properties.Settings.Default.Save();
        }

        public static void ShowChangeCaseOptionInHomeTab(bool show)
        {
            try
            {
                Globals.Ribbons.ChangeCaseTab.GroupCcInHome.Visible = show;
            }
            catch
            {
                // ignore
            }
            
            Properties.Settings.Default.showChangeCaseOptionInHomeTab = show;
            Properties.Settings.Default.Save();
        }

        public static void EnableSc(bool enable)
        {
            Properties.Settings.Default.enableShortCuts = enable;
            Properties.Settings.Default.Save();
            try
            {
                Globals.Ribbons.ChangeCaseTab.CbEnableShortcuts.Checked = enable;
            }
            catch
            {
                // ignore
            }

            
            EnableShortCuts(enable);
        }

        public static void FirstInMenu(bool enable)
        {
            Properties.Settings.Default.firstItemInContextMenu = enable;
            Properties.Settings.Default.Save();

            try
            {
                Globals.Ribbons.ChangeCaseTab.CbFirstItemInContextMenu.Checked = enable;
            }
            catch
            {
                // ignore
            }

            
        }

        #region Change Case Functions

        internal static void Cc(string ccFunction)
        {

            if (!Globals.ChangeCase.Application.Ready) return;
            Globals.ChangeCase.Application.ScreenUpdating = false;
            try
            {
                foreach (Excel.Range cell in Globals.ChangeCase.Application.Selection)
                {
                    if (cell.Value == null) continue;
                    var cellValue = cell.Value.ToString();
                    if (cellValue.Trim() != "")
                    {
                        cell.Value = ChangeCaseFunctions.ChangeMyCase(ccFunction, cellValue);
                    }
                }
            }
            finally
            {
                Globals.ChangeCase.Application.ScreenUpdating = true;
            }
        }

        #endregion

    }
}