using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interlocking
{
    public static class UniqueSequence
    {
        private static int _SeqNo = 0;

        public static int GetNextSequence()
        {
            return Interlocked.Increment(ref _SeqNo) % 100;
        }   
    }   // UniqueSequence
}
