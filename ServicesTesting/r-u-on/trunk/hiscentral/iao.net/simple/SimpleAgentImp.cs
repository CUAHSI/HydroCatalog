// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;

namespace Ruon
{
    internal class SimpleAgentImp : Agent
    {
        private SimpleAgent sa;

        internal SimpleAgentImp(string agentType, SimpleAgent sa, string accountId, string proxyUser,
                                string proxyPassword)
            : base(agentType, "1.00", accountId, -1, proxyUser, proxyPassword)
        {
            this.sa = sa;
        }

        protected override void Uninstall()
        {
            sa.Uninstall();
        }
    }
}