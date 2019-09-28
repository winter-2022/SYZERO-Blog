using System;
using System.Collections.Generic;
using System.Text;
using Snowflake;

namespace SyZero.Common
{
    public class SnowflakeId
    {
        private static IdWorker worker = new IdWorker(1, 1);

        public static long GetID()
        {
            return worker.NextId();
        }
    }
}
