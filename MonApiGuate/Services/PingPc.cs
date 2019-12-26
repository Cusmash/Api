using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MonApiGuate.Services
{
    public class PingPc
    {
        public bool PingHost( bool throwExceptionOnError = false)
        {
            bool pingable = false;
            using (Ping p = new Ping())
            {
                try
                {
                    PingReply pr = p.Send("192.168.0.73");
                    pingable = pr.Status == IPStatus.Success;
                }
                catch (PingException e)
                {
                    if (throwExceptionOnError) throw e;
                    pingable = false;
                }
            }
            return pingable;
        }
    }
}
