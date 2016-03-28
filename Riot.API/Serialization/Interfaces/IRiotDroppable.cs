using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API.Serialization.Interfaces
{
    public enum DataType : uint
    {
        Champion = 0,
        Item = 1
    };
    public interface IRiotDroppable
    {
        Bitmap Image { get; }
        string Name { get; }
        DataType Type { get; }
    }
}
