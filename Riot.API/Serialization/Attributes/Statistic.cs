namespace RiotPls.API.Serialization.Attributes
{
    /// <summary>
    /// Attribute for tagging a property as a component of a particular statistic
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Statistic : System.Attribute
    {
        /// <summary>
        /// Statistic was parsed from the entity's description
        /// </summary>
        public bool IsFromDescription { get; set; } = false;
        /// <summary>
        /// Statistic requires no special calculations
        /// </summary>
        public bool IsGeneric { get; set; } = true;
        /// <summary>
        /// Statistic identifier
        /// </summary>
        public string Name { get; private set; } = null;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Statistic name</param>
        public Statistic(string name)
        {
            this.Name = name;
            return;
        }
    }
}
