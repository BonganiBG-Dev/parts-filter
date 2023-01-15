using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter
{
    internal static class RunLogs
    {
        public static int NewItems { get; set; } = 0;
        public static int UpdatedItems { get; set; } = 0;
        public static long TotalRunTime { get; set; }
    }
}
