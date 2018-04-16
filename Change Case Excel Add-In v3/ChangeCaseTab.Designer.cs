namespace Change_Case_Excel_Add_In_v3
{
    partial class ChangeCaseTab : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ChangeCaseTab()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.TabChangeCase = this.Factory.CreateRibbonTab();
            this.GrpCc = this.Factory.CreateRibbonGroup();
            this.UpperCase = this.Factory.CreateRibbonButton();
            this.LowerCase = this.Factory.CreateRibbonButton();
            this.SentenceCase = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.ProperCase = this.Factory.CreateRibbonButton();
            this.ToggleCase = this.Factory.CreateRibbonButton();
            this.AlternateCase = this.Factory.CreateRibbonButton();
            this.GrpCcSettings = this.Factory.CreateRibbonGroup();
            this.CbEnableShortcuts = this.Factory.CreateRibbonCheckBox();
            this.CbFirstItemInContextMenu = this.Factory.CreateRibbonCheckBox();
            this.BtnHideTab = this.Factory.CreateRibbonButton();
            this.BtnHelp = this.Factory.CreateRibbonButton();
            this.GroupDonate = this.Factory.CreateRibbonGroup();
            this.BtnDonate = this.Factory.CreateRibbonButton();
            this.TabHome = this.Factory.CreateRibbonTab();
            this.GroupCcInHome = this.Factory.CreateRibbonGroup();
            this.GalleryChangeCase = this.Factory.CreateRibbonGallery();
            this.GBtnUpperCase = this.Factory.CreateRibbonButton();
            this.GBtnLowerCase = this.Factory.CreateRibbonButton();
            this.GBtnSentenceCase = this.Factory.CreateRibbonButton();
            this.GBtnProperCase = this.Factory.CreateRibbonButton();
            this.GBtnToggleCase = this.Factory.CreateRibbonButton();
            this.GBtnAlternateCase = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.TabChangeCase.SuspendLayout();
            this.GrpCc.SuspendLayout();
            this.GrpCcSettings.SuspendLayout();
            this.GroupDonate.SuspendLayout();
            this.TabHome.SuspendLayout();
            this.GroupCcInHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabChangeCase
            // 
            this.TabChangeCase.Groups.Add(this.GrpCc);
            this.TabChangeCase.Groups.Add(this.GrpCcSettings);
            this.TabChangeCase.Groups.Add(this.GroupDonate);
            this.TabChangeCase.Label = "Change Case";
            this.TabChangeCase.Name = "TabChangeCase";
            // 
            // GrpCc
            // 
            this.GrpCc.Items.Add(this.UpperCase);
            this.GrpCc.Items.Add(this.LowerCase);
            this.GrpCc.Items.Add(this.SentenceCase);
            this.GrpCc.Items.Add(this.separator1);
            this.GrpCc.Items.Add(this.ProperCase);
            this.GrpCc.Items.Add(this.ToggleCase);
            this.GrpCc.Items.Add(this.AlternateCase);
            this.GrpCc.Label = "Change Case";
            this.GrpCc.Name = "GrpCc";
            // 
            // UpperCase
            // 
            this.UpperCase.KeyTip = "U";
            this.UpperCase.Label = "UPPER CASE";
            this.UpperCase.Name = "UpperCase";
            this.UpperCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.UpperCase_Click);
            // 
            // LowerCase
            // 
            this.LowerCase.Label = "lower case";
            this.LowerCase.Name = "LowerCase";
            this.LowerCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.LowerCase_Click);
            // 
            // SentenceCase
            // 
            this.SentenceCase.Label = "Sentence case.";
            this.SentenceCase.Name = "SentenceCase";
            this.SentenceCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SentenceCase_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // ProperCase
            // 
            this.ProperCase.Label = "Capitalize Each Word";
            this.ProperCase.Name = "ProperCase";
            this.ProperCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProperCase_Click);
            // 
            // ToggleCase
            // 
            this.ToggleCase.Label = "tOOGLE cASE";
            this.ToggleCase.Name = "ToggleCase";
            this.ToggleCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ToggleCase_Click);
            // 
            // AlternateCase
            // 
            this.AlternateCase.Label = "aLtErNaTiNg CaSe";
            this.AlternateCase.Name = "AlternateCase";
            this.AlternateCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AlternateCase_Click);
            // 
            // GrpCcSettings
            // 
            ribbonDialogLauncherImpl1.ScreenTip = "More Settings";
            ribbonDialogLauncherImpl1.SuperTip = "Click to launch more settings.";
            this.GrpCcSettings.DialogLauncher = ribbonDialogLauncherImpl1;
            this.GrpCcSettings.Items.Add(this.CbEnableShortcuts);
            this.GrpCcSettings.Items.Add(this.CbFirstItemInContextMenu);
            this.GrpCcSettings.Items.Add(this.BtnHideTab);
            this.GrpCcSettings.Items.Add(this.BtnHelp);
            this.GrpCcSettings.Label = "Settings";
            this.GrpCcSettings.Name = "GrpCcSettings";
            this.GrpCcSettings.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GrpCcSettings_DialogLauncherClick);
            // 
            // CbEnableShortcuts
            // 
            this.CbEnableShortcuts.Label = "Enable Shortcuts";
            this.CbEnableShortcuts.Name = "CbEnableShortcuts";
            this.CbEnableShortcuts.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CbEnableShortcuts_Click);
            // 
            // CbFirstItemInContextMenu
            // 
            this.CbFirstItemInContextMenu.Label = "First in context menu";
            this.CbFirstItemInContextMenu.Name = "CbFirstItemInContextMenu";
            this.CbFirstItemInContextMenu.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CbFirst_Click);
            // 
            // BtnHideTab
            // 
            this.BtnHideTab.Label = "Hide this tab";
            this.BtnHideTab.Name = "BtnHideTab";
            this.BtnHideTab.OfficeImageId = "HideDetails";
            this.BtnHideTab.ShowImage = true;
            this.BtnHideTab.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnHideTab_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.Label = "Help";
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.OfficeImageId = "Help";
            this.BtnHelp.ShowImage = true;
            this.BtnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnHelp_Click);
            // 
            // GroupDonate
            // 
            this.GroupDonate.Items.Add(this.BtnDonate);
            this.GroupDonate.Name = "GroupDonate";
            // 
            // BtnDonate
            // 
            this.BtnDonate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BtnDonate.Label = "Donate";
            this.BtnDonate.Name = "BtnDonate";
            this.BtnDonate.OfficeImageId = "AccountingFormat";
            this.BtnDonate.ShowImage = true;
            this.BtnDonate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnDonate_Click);
            // 
            // TabHome
            // 
            this.TabHome.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabHome.ControlId.OfficeId = "TabHome";
            this.TabHome.Groups.Add(this.GroupCcInHome);
            this.TabHome.Label = "TabHome";
            this.TabHome.Name = "TabHome";
            // 
            // GroupCcInHome
            // 
            this.GroupCcInHome.Items.Add(this.GalleryChangeCase);
            this.GroupCcInHome.Name = "GroupCcInHome";
            this.GroupCcInHome.Position = this.Factory.RibbonPosition.AfterOfficeId("GroupFont");
            // 
            // GalleryChangeCase
            // 
            this.GalleryChangeCase.Buttons.Add(this.GBtnUpperCase);
            this.GalleryChangeCase.Buttons.Add(this.GBtnLowerCase);
            this.GalleryChangeCase.Buttons.Add(this.GBtnSentenceCase);
            this.GalleryChangeCase.Buttons.Add(this.GBtnProperCase);
            this.GalleryChangeCase.Buttons.Add(this.GBtnToggleCase);
            this.GalleryChangeCase.Buttons.Add(this.GBtnAlternateCase);
            this.GalleryChangeCase.Label = " ";
            this.GalleryChangeCase.Name = "GalleryChangeCase";
            this.GalleryChangeCase.OfficeImageId = "ChangeCase";
            this.GalleryChangeCase.ScreenTip = "Change Case";
            this.GalleryChangeCase.ShowImage = true;
            this.GalleryChangeCase.SuperTip = "Change selected cell(s) content to uppercase, lowercase or other common capitaliz" +
    "ations.";
            // 
            // GBtnUpperCase
            // 
            this.GBtnUpperCase.Label = "UPPERCASE";
            this.GBtnUpperCase.Name = "GBtnUpperCase";
            this.GBtnUpperCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.UpperCase_Click);
            // 
            // GBtnLowerCase
            // 
            this.GBtnLowerCase.Label = "lowercase";
            this.GBtnLowerCase.Name = "GBtnLowerCase";
            this.GBtnLowerCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.LowerCase_Click);
            // 
            // GBtnSentenceCase
            // 
            this.GBtnSentenceCase.Label = "Sentence case.";
            this.GBtnSentenceCase.Name = "GBtnSentenceCase";
            this.GBtnSentenceCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SentenceCase_Click);
            // 
            // GBtnProperCase
            // 
            this.GBtnProperCase.Label = "Capitalize Each Word";
            this.GBtnProperCase.Name = "GBtnProperCase";
            this.GBtnProperCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProperCase_Click);
            // 
            // GBtnToggleCase
            // 
            this.GBtnToggleCase.Label = "tOOGLE cASE";
            this.GBtnToggleCase.Name = "GBtnToggleCase";
            this.GBtnToggleCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ToggleCase_Click);
            // 
            // GBtnAlternateCase
            // 
            this.GBtnAlternateCase.Label = "aLtErNaTiNg CaSe";
            this.GBtnAlternateCase.Name = "GBtnAlternateCase";
            this.GBtnAlternateCase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AlternateCase_Click);
            // 
            // button1
            // 
            this.button1.Label = "";
            this.button1.Name = "button1";
            // 
            // ChangeCaseTab
            // 
            this.Name = "ChangeCaseTab";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabChangeCase);
            this.Tabs.Add(this.TabHome);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ChangeCaseTab_Load);
            this.TabChangeCase.ResumeLayout(false);
            this.TabChangeCase.PerformLayout();
            this.GrpCc.ResumeLayout(false);
            this.GrpCc.PerformLayout();
            this.GrpCcSettings.ResumeLayout(false);
            this.GrpCcSettings.PerformLayout();
            this.GroupDonate.ResumeLayout(false);
            this.GroupDonate.PerformLayout();
            this.TabHome.ResumeLayout(false);
            this.TabHome.PerformLayout();
            this.GroupCcInHome.ResumeLayout(false);
            this.GroupCcInHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabChangeCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpCc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton UpperCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton LowerCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SentenceCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ProperCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ToggleCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlternateCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpCcSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox CbEnableShortcuts;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox CbFirstItemInContextMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnHideTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabHome;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GroupCcInHome;
        internal Microsoft.Office.Tools.Ribbon.RibbonGallery GalleryChangeCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnUpperCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnLowerCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnSentenceCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnProperCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnToggleCase;
        private Microsoft.Office.Tools.Ribbon.RibbonButton GBtnAlternateCase;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GroupDonate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnDonate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnHelp;
    }

    partial class ThisRibbonCollection
    {
        internal ChangeCaseTab ChangeCaseTab
        {
            get { return this.GetRibbon<ChangeCaseTab>(); }
        }
    }
}
