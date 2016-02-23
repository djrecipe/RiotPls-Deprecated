using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Champions;

namespace RiotPls.Builder
{
    public abstract class BuildManager
    {
        public delegate void BuildChangedDelegate(int index);

        public static BuildChangedDelegate BuildChanged;
        private static List<Build> builds = new List<Build>();
        static BuildManager()
        {
            BuildManager.builds.Add(new Build(0));   
        }
        public static ChampionInfo GetChampion(int index)
        {
            return BuildManager.builds.FirstOrDefault(b => b.Index == index)?.Champion;
        }
        public static bool SetChampion(int index, string name)
        {
            Build build = BuildManager.builds.FirstOrDefault(b => b.Index == index);
            if (build == null)
                return false;
            ChampionInfo champion = API.Engine.GetChampion(name);
            if (champion == null)
                return false;
            build.Champion = champion;
            BuildManager.FireUpdate(index);
            return true;
        }
        private static void FireUpdate(int index)
        {
            if (BuildManager.BuildChanged != null)
                BuildManager.BuildChanged(index);
            return;
        }
    }
}
