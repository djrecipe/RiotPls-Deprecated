using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.DataManagers;
using RiotPls.API.Serialization.Champions;
using RiotPls.Binding;
using RiotPls.Tools;
using RiotPls.UI.Interfaces;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formChampions
    /// </summary>
    /// <seealso cref="formChampions"/>
    public class formChampionsModel : IBuildModifier
    {
        #region Instance Members
        private ChampionInfoBindingList binding = null;
        #region Events               
        /// <summary>
        /// Data update is about to start
        /// </summary>
        public event VoidDelegate DataUpdateStarted;
        /// <summary>
        /// Data has finished updating
        /// </summary>
        public event EventHandler<object> DataUpdateFinished;
        #endregion
        #endregion
        #region Instance Properties
        /// <summary>
        /// Set of builds which may be modified
        /// </summary>
        public BuildCollection Builds { get; set; }
        /// <summary>
        /// Currently selected champion
        /// </summary>
        public string SelectedItem { get; set; } = null;
        /// <summary>
        /// Worker for updating data
        /// </summary>
        public BackgroundWorker Worker { get; private set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public formChampionsModel()
        {
            this.Worker = new BackgroundWorker();
            this.Worker.DoWork += this.BackgroundWorker_DoWork;
            return;
        }
        public List<ToolStripMenuItem> GetBuildMenuItems()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            for (int i = 0; i < this.Builds.Count; i++)
            {
                Build build = this.Builds[i];
                if (build == null)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem(build.Name)
                {
                    CheckOnClick = true,
                    Checked = build.Champion?.Name == this.SelectedItem,
                };
                item.CheckedChanged += this.itmSelectedForBuild_CheckedChanged;
                items.Add(item);
            }
            return items;
        } 
        public void GetTooltipText(string champion_name, string column_name, out string text, out string subtitle)
        {
            this.SelectedItem = champion_name;
            ChampionInfo champion_info = this.binding.Retrieve(this.SelectedItem);
            text = "???";
            subtitle = column_name;
            switch (column_name)
            {

                case "Attack":
                    text = champion_info.RatingInfo.Attack.ToString() + " / 10";
                    break;
                case "Defense":
                    text = champion_info.RatingInfo.Defense.ToString() + " / 10";
                    break;
                case "Difficulty":
                    text = champion_info.RatingInfo.Difficulty.ToString() + " / 10";
                    break;
                case "Magic":
                    text = champion_info.RatingInfo.Magic.ToString() + " / 10";
                    break;
                case "Passive":
                    text = "     " + champion_info.PassiveDescription;
                    subtitle = champion_info.PassiveName + " (Passive)";
                    break;
                //
                case "Q":
                    text = "     " + champion_info.SpellDescriptionQ;
                    subtitle = champion_info.SpellNameQ + " (Q)";
                    break;
                case "W":
                    text = "     " + champion_info.SpellDescriptionW;
                    subtitle = champion_info.SpellNameW + " (W)";
                    break;
                case "E":
                    text = "     " + champion_info.SpellDescriptionE;
                    subtitle = champion_info.SpellNameE + " (E)";
                    break;
                case "R":
                    text = "     " + champion_info.SpellDescriptionR;
                    subtitle = champion_info.SpellNameR + " (R)";
                    break;
                //
                case "Image":
                    text = champion_info.SkinList;
                    subtitle = "Skins";
                    break;
                case "Free":
                    text = champion_info.FreeToPlay.ToString();
                    subtitle = "Free to Play?";
                    break;
                case "Name":
                    text = champion_info.LoreSummary;
                    subtitle = "Lore Summary";
                    break;
                case "Tags":
                    text = champion_info.TagList;
                    break;
                case "Title":
                    text = champion_info.LoreSummary;
                    subtitle = "Lore Summary";
                    break;
            }
            return;
        }
        public void UpdateBuildChampion(int index, ChampionInfo champion)
        {
            Build build = this.Builds[index];
            if (build == null)
                return;
            build.SetChampion(champion);
            return;
        }

        public void UpdateData()
        {
            if (this.Worker.IsBusy)
                return;
            if (this.DataUpdateStarted != null)
                this.DataUpdateStarted();
            this.Worker.RunWorkerAsync(Engine.Champions);
            return;
        }

        public void SetFilter(string selected_item, string search_text)
        {
            if (this.binding == null || this.Worker.IsBusy)
                return;
            this.binding.SetFilter(new List<string>() { selected_item }, search_text);
            return;
        }

        public void SetFilterAndUpdate(string selected_item, string search_text)
        {
            this.SetFilter(selected_item, search_text);
            this.UpdateData();
            return;
        }
        #endregion
        #region Instance Events   
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.binding == null) 
            {
                // only instantiate once, but instantiate on worker thread to keep UI responsive
                this.binding = new ChampionInfoBindingList(e.Argument as ChampionDataManager);
                // assign event handler BEFORE calling Update()
                this.binding.DataUpdateFinished += this.ChampionInfoBindingList_DataUpdateFinished;
            }
            // update and wait for callback
            this.binding.UpdateFilter();
            return;
        }

        private void ChampionInfoBindingList_DataUpdateFinished()
        {
            if (this.DataUpdateFinished != null)
                this.DataUpdateFinished(this, this.binding.Binding);
            return;
        }

        private void itmSelectedForBuild_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            ToolStripMenuItem parent = item.OwnerItem as ToolStripMenuItem;
            int index = parent.DropDownItems.IndexOf(item);
            if (index < 0)
                return;
            this.UpdateBuildChampion(index, item.Checked ? Engine.Champions.Get(this.SelectedItem) : null);
            return;
        }
        #endregion
    }
}
