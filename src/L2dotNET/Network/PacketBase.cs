using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2dotNET.Network
{
    public abstract class PacketBase
    {
        public abstract void RunImpl();
    }
}
