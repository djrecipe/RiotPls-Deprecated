using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls.API.Serialization.Items
{
    /// <summary>
    /// Parses item descriptions in order to retrieve stats which are not represented in the main stats structure
    /// </summary>
    public abstract class ItemDescriptionParser
    {
        #region Static Members       
        private static readonly DescriptionDetails.ItemDataTable CustomStats = new DescriptionDetails.ItemDataTable();
        private static readonly Dictionary<string, string> Stats = new Dictionary<string, string>()
        {
            { "FlatArmorPen", @"(> *\+?(?<FlatArmorPen>\d+) *<a href='FlatArmorPen)"},
            { "FlatMagicPen", @"(> *\+?(?<FlatMagicPen>\d+) *<a href='FlatMagicPen)"},
            { "PercArmorPen",  @"(> *\+?(?<PercArmorPen>\d+) *%? *<a href='BonusArmorPen)"},
            { "PercMagicPen",  @"(> *\+?(?<PercMagicPen>\d+) *%? *<a href='TotalMagicPen)"},
            { "CooldownReduction",  @"(> *\+?(?<CooldownReduction>\d+) *%? *Cooldown Reduction)"}
        };
        #endregion
        #region Static Properties
        private static string CustomStatsPath => Path.Combine(Tools.Paths.AppData, "ItemDescriptionStats.rpxml");
        #endregion
        #region Static Methods
        static ItemDescriptionParser()
        {
            if (File.Exists(ItemDescriptionParser.CustomStatsPath))
            {
                ItemDescriptionParser.CustomStats.ReadXml(ItemDescriptionParser.CustomStatsPath);
                foreach (DescriptionDetails.ItemRow row in ItemDescriptionParser.CustomStats)
                {
                    if (ItemDescriptionParser.Stats.ContainsKey(row.Name))
                        ItemDescriptionParser.Stats.Remove(row.Name);
                    ItemDescriptionParser.Stats.Add(row.Name, row.RegEx);
                }
            }
            else
                ItemDescriptionParser.CustomStats.WriteXml(ItemDescriptionParser.CustomStatsPath);
            return;
        }
        internal static ItemStatsInfo Parse(string description)
        {
            ItemStatsInfo info = new ItemStatsInfo();
            if (string.IsNullOrWhiteSpace(description))
                return info;
            foreach (KeyValuePair<string, string> pair in ItemDescriptionParser.Stats)
            {
                string value = ItemDescriptionParser.ParseSection(pair.Key, pair.Value, description);
                int value_int = 0;
                if (string.IsNullOrWhiteSpace(value) || !int.TryParse(value, out value_int))
                    continue;
                switch (pair.Key)
                {
                    case "CooldownReduction":
                        info.CooldownReduction += value_int;
                        break;
                    case "FlatArmorPen":
                        info.ArmorPenFlat += value_int;
                        break;
                    case "FlatMagicPen":
                        info.MagicPenFlat += value_int;
                        break;
                    case "PercArmorPen":
                        info.ArmorPenPerc += value_int;
                        break;
                    case "PercMagicPen":
                        info.MagicPenPerc += value_int;
                        break;
                }
            }
            return info;
        }
        private static string ParseSection(string name, string regex, string text)
        {
            Regex rx = null;
            try
            {
                rx = new Regex(regex, RegexOptions.ExplicitCapture);
            }
            catch (Exception e)
            {
                return null;
            }
            List<string> group_names = rx.GetGroupNames().ToList();
            int group_index = group_names.IndexOf(name);
            if (group_index < 0)
                return null;
            MatchCollection matches = rx.Matches(text);
            if (matches.Count < 1)
                return null;
            return matches[0]?.Groups[group_index].Value;
        }
        #endregion
    }
}
