using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Champions;
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
        private Dictionary<string, ChampionInfo> champions = new Dictionary<string, ChampionInfo>();
        private BindingList<ChampionInfo> source = null;
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
            this.Worker.RunWorkerCompleted += this.BackgroundWorker_RunWorkerCompleted;
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
            this.SelectedItem = Engine.CleanseChampionName(this.champions, champion_name);
            ChampionInfo champion_info = this.champions[this.SelectedItem];
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
            this.Worker.RunWorkerAsync();
            return;
        }

        public object UpdateFilter(string selected_item, string search_text)
        {
            if (this.champions == null || this.Worker.IsBusy)
                return null;
            if (selected_item == null || search_text.Length < 1)
                return this.source;
            else
            {
                switch (selected_item)
                {
                    case "Free":
                        if (search_text == "Any")
                            return this.source;
                        else
                        {
                            bool free_to_play = search_text == "Free";
                            return new BindingList<ChampionInfo>(this.source.Where(info =>
                                info.FreeToPlay == free_to_play).ToList<ChampionInfo>());
                        }
                    case "Name":
                        return new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.Name.ToUpper().Contains(search_text.ToUpper())).ToList<ChampionInfo>());
                    case "Tags":
                        return new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.TagList.ToUpper().Contains(search_text.ToUpper())).ToList<ChampionInfo>());
                    case "Title":
                        return new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.Title.ToUpper().Contains(search_text.ToUpper())).ToList<ChampionInfo>());
                    default:
                        return this.source;
                }
            }
        }
        #endregion
        #region Instance Events   
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.champions = Engine.GetChampionInfo();
            this.source = new SortableBindingList<ChampionInfo>(this.champions.Values.OrderBy(champ => champ.Name).ToList());
            e.Result = this.source;
            return;
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.DataUpdateFinished != null)
                this.DataUpdateFinished(this, e.Result);
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
            this.UpdateBuildChampion(index, item.Checked ? Engine.GetChampion(this.SelectedItem) : null);
            return;
        }
        #endregion
    }
}
