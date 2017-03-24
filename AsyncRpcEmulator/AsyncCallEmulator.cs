using Nito.AsyncEx;
using System;
using System.Threading.Tasks;

namespace AsyncRpcEmulator
{
    public class AsyncCallEmulator 
    {
        private readonly int _min = 20;
        private readonly int _max = 500;
        private static Random random = new Random();
        private readonly AsyncSemaphore _semaphore;

        public AsyncCallEmulator()
        {
            _semaphore = new AsyncSemaphore(5);
        }
        public AsyncCallEmulator(int min, int max) : this()
        {
            _min = min;
            _max = max;
        }

        public async Task<int> CallWithDelayedResponse()
        {  
            _semaphore.Wait();
            var delay = random.Next(_min, _max);
            Console.WriteLine($"call open with expected delay of {delay}");
            await Task.Delay(delay).ConfigureAwait(false);
            Console.WriteLine($"call closed with delay {delay}");
            _semaphore.Release();

            return delay;
        }
    }
}
