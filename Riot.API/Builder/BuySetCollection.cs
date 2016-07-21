using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RiotPls.API.Builder
{
    /// <summary>
    /// Serializable collection of buy sets which describe a shop purchases over the course of a match
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BuySetCollection
    {
        #region Types
        public delegate void BuySetCollectionDelegate(BuySetCollection collection);
        #endregion
        #region Instance Members
        #region Events
        public event BuySetCollectionDelegate Changed;
        #endregion
        #endregion
        #region Instance Properties
        /// <summary>
        /// List of buys contain in this collection
        /// </summary>               
        [JsonProperty("Buys", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private List<BuySet> BuySets { get; set; } = new List<BuySet>();
        /// <summary>
        /// Total cost of all buys combined
        /// </summary>
        public int TotalCost => this.BuySets.Select(i => i.TotalCost).Sum();
        #endregion
        #region Instance Methods
        /// <summary>
        /// Add a new buy set (list of items)
        /// </summary>
        /// <param name="set">List of items</param>
        public void Add(BuySet set)
        {
            if(set == null)
                throw new ArgumentNullException("set", "You must provide a valid BuySet");
            set.Changed += this.BuySet_Changed;
            this.BuySets.Add(set);
            if (this.Changed != null)
                this.Changed(this);
            return;
        }


        /// <summary>
        /// Check for an existing buy set
        /// </summary>
        /// <param name="set">Buy set to check for</param>
        /// <returns>True if the buy set is already present, false otherwise</returns>
        public bool Contains(BuySet set)
        {
            if (set == null)
                throw new ArgumentNullException("set", "You must provide a valid BuySet");
            return this.BuySets.Contains(set);
        }
        /// <summary>
        /// Remove the specified buy set
        /// </summary>
        /// <param name="set">Buy set to remove</param>
        public void Remove(BuySet set)
        {
            if (set == null)
                throw new ArgumentNullException("set", "You must provide a valid BuySet");
            set.Changed -= this.BuySet_Changed;
            this.BuySets.Remove(set);
            if (this.Changed != null)
                this.Changed(this);
            return;
        }
        #endregion
        #region Instance Events
        private void BuySet_Changed(BuySet set)
        {
            if (this.Changed != null)
                this.Changed(this);
            return;
        }
        #endregion
    }
}
