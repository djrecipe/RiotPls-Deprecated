using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Interfaces
{
    /// <summary>
    /// A generic serializable collection of data, cached locally
    /// </summary>
    /// <typeparam name="T">Root object type to serialize/deserialize</typeparam>
    interface IRiotSerializable<T>
    {
        /// <summary>
        /// Local filename where cache is stored
        /// </summary>
        string LocalFileName { get; } 
        /// <summary>
        /// Root JSON token from which the serializable data will be extracted
        /// </summary>
        string RootToken { get; }
        /// <summary>
        /// A Riot URL from which the data is originally obtained
        /// </summary>
        RiotURL URL { get; }
        /// <summary>
        /// Dynamically retrieves deserialized object data, either from the remote URL or local cache
        /// </summary>
        /// <param name="remote_retrieval">Output variable specifying whether the data was retrieved from a remote source</param>
        /// <returns>Deserialized object data</returns>
        T Get(out bool remote_retrieval);
    }

}
