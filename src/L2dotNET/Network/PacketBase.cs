using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace L2dotNET.Network
{
    [Synchronization]
    public abstract class PacketBase
    {
        public abstract void RunImpl();
    }
}
