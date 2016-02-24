using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Interfaces
{
    interface IRiotSerializable<T>
    {
        string LocalFileName { get; } 
        string RootToken { get; }
        RiotURL URL { get; }
        T Get();
    }

}
