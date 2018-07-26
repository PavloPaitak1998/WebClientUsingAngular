using System.Threading.Tasks;
using System.Timers;

namespace BusinessLogicLayer.Helper
{
    public static class ClassHelper
    {
        public static Task MehtodHelperDelay(int miliseconds)
        {
            var tcs = new TaskCompletionSource<object>();

            var timer = new Timer(miliseconds) { AutoReset=false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
            timer.Start();

            return tcs.Task;
        }
    }
}
