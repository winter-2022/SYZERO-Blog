using System;
using System.Collections.Generic;
using System.Text;
using Snowflake;
namespace SyZero.Common
{
    public class SnowflakeId
    {
        private static IdWorker worker = new IdWorker(1, 1);

        public static string GetID()
        {
            return worker.NextId().ToString();
        }
    }
}
