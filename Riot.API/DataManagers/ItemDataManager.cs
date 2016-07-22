using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Items;

namespace RiotPls.API.DataManagers
{
    public class ItemDataManager : DataManagerBase<ItemInfo>
    {
        public ItemDataManager(APIKey key) : base(key)
        {
        }
        public List<ItemInfo> GetItemComponents(string name)
        {
            List<ItemInfo> components = new List<ItemInfo>();
            ItemInfo item = this.infos.Values.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                foreach (string component_id in item.ComponentIDs.Where(id => this.infos.ContainsKey(id)))
                {
                    ItemInfo item_component = this.infos[component_id];
                    if (item_component != null)
                        components.Add(item_component);
                    // TODO: 07/21/16 recurse through components of components
                }
            }
            return components;

        }
        public override void Update()
        {
            // champions
            ItemInfoSet items = new ItemInfoSet(this.apiKey);
            this.infos = items.Get();
            return;
        }

    }
}
