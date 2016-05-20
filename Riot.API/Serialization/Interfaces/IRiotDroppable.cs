using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API.Serialization.Interfaces
{
    public interface IRiotDroppable : ICloneable
    {
        Bitmap Image { get; }
        int LevelObtained { get; set; }
        string Name { get; }
    }
}
