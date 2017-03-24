using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRpcEmulator
{
    public class AsyncCallEmulator
    {
        private readonly int _min = 20;
        private readonly int _max = 500;
        private static Random random = new Random();

        public AsyncCallEmulator() { }
        public AsyncCallEmulator(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public async Task<int> CallWithDelayedResponse()
        {
            var delay = random.Next(_min, _max);
            //Console.WriteLine($"call open with expected delay of {delay}");
            await Task.Delay(delay).ConfigureAwait(false);
            //Console.WriteLine($"call closed with delay {delay}");
            return delay;
        }
    }
}
