using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Change_Case_Excel_Add_In_v3.Properties;

namespace Change_Case_Excel_Add_In_v3
{
    public partial class MyCcSettings : Form
    {
        private static readonly List<string> Alphabets = new List<string>(Enumerable.Range('A', 26).Select(x => ((char)x).ToString()).ToList());

        public MyCcSettings()
        {
            InitializeComponent();
            
            LoadCurrentSettings();
        }


        private void LoadCurrentSettings()
        {
            SetCbItems(GetScArray());
            //setting shortcut values
            var config = Settings.Default;
            CbUc.SelectedItem = config.ScUpperCase;
            CbLc.SelectedItem = config.ScLowerCase;
            CbSc.SelectedItem = config.ScSentenceCase;
            CbPc.SelectedItem = config.ScProperCase;
            CbTc.SelectedItem = config.ScToggleCase;
            CbAc.SelectedItem = config.ScAlternateCase;

            //Adding combo box selection changed event
            CbUc.SelectionChangeCommitted += CbSelectionChanged;
            CbLc.SelectionChangeCommitted += CbSelectionChanged;
            CbSc.SelectionChangeCommitted += CbSelectionChanged;
            CbPc.SelectionChangeCommitted += CbSelectionChanged;
            CbTc.SelectionChangeCommitted += CbSelectionChanged;
            CbAc.SelectionChangeCommitted += CbSelectionChanged;

            //Setting control values based on current settings
            CbxEnableShortcuts.Checked = config.enableShortCuts;
            CbxFirstInContenxtMenu.Checked = config.firstItemInContextMenu;
            CbxShowInHome.Checked = config.showChangeCaseOptionInHomeTab;
            CbxShowTab.Checked = config.showChangeCaseTab;
            groupBoxShortcuts.Enabled = CbxEnableShortcuts.Checked;
        }


        //Combo box selection changed event
        private void CbSelectionChanged(object sender, EventArgs e)
        {
            SetCbItems(GetScArray(false), true);
        }



        private void SetCbItems(IReadOnlyList<string> currentSc, bool preserveSetValue = false)
        {
            CbUc.Tag = 1;
            CbLc.Tag = 2;
            CbSc.Tag = 3;
            CbPc.Tag = 4;
            CbTc.Tag = 5;
            CbAc.Tag = 6;
            var comboBoxes = tableLayoutPanelShortCuts.Controls.OfType<ComboBox>().OrderBy(x => x.Tag);
            var i = 0;
            foreach (var cb in comboBoxes)
            {
                var selValue = cb.SelectedItem;
                cb.Items.Clear();
                cb.Items.Add("None");
                foreach (var a in Alphabets)
                {
                    if (currentSc.Contains(a) && a != ChangeCase.NoSc && a != currentSc[i]) continue;
                    cb.Items.Add(a);
                }
                i++;
                if (preserveSetValue) cb.SelectedItem = selValue;
            }
        }

        private string[] GetScArray(bool fromSettings = true)
        {
            if (fromSettings)
            {
                var config = Settings.Default;
                string[] scArray = { config.ScUpperCase, config.ScLowerCase, config.ScSentenceCase, config.ScProperCase, config.ScToggleCase, config.ScAlternateCase };
                return scArray;
            }
            else
            {
                string[] scArray = { CbUc.SelectedItem.ToString(), CbLc.SelectedItem.ToString(), CbSc.SelectedItem.ToString(), CbPc.SelectedItem.ToString(), CbTc.SelectedItem.ToString(), CbAc.SelectedItem.ToString() };
                return scArray;
            }
        }

        private void MyCcSettings_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ChangeCase.EnableShortCuts(false);

            var config = Settings.Default;
            config.enableShortCuts = CbxEnableShortcuts.Checked;
            config.firstItemInContextMenu = CbxFirstInContenxtMenu.Checked;
            config.showChangeCaseOptionInHomeTab = CbxShowInHome.Checked;
            config.showChangeCaseTab = CbxShowInHome.Checked;

            config.ScUpperCase = CbUc.SelectedItem.ToString();
            config.ScLowerCase = CbLc.SelectedItem.ToString();
            config.ScSentenceCase = CbSc.SelectedItem.ToString();
            config.ScProperCase = CbPc.SelectedItem.ToString();
            config.ScToggleCase = CbTc.SelectedItem.ToString();
            config.ScAlternateCase = CbAc.SelectedItem.ToString();

            config.Save();

            ChangeCase.EnableShortCuts(config.enableShortCuts);

            MessageBox.Show(Resources.SettingsSaved, Resources.ProductName);
            ChangeCase.RefreshControls();
            Close();
        }

        private void MyCcSettings_Load(object sender, EventArgs e)
        {
            Text = Resources.WindowTitle;
        }

        private void CbxEnableShortcuts_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxShortcuts.Enabled = CbxEnableShortcuts.Checked;
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            var restoreConfirmation = MessageBox.Show(Resources.MyCcSettings_BtnDefault_Click_Confirmation, Resources.WindowTitle, MessageBoxButtons.YesNo);
            if (restoreConfirmation != DialogResult.Yes) return;
            ChangeCase.RestoreSettings();
            MessageBox.Show(Resources.SettingsRestored, Resources.WindowTitle);
            ChangeCase.RefreshControls();
            Close();
        }
    }
}
