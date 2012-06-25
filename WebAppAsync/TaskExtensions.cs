using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebAppAsync
{
    //Task.Delay extension from async CTP (provided by Reflector)
    public static class TaskExtensions
    {
        static readonly Task _sPreCompletedTask = GetCompletedTask();
        static readonly Task _sPreCanceledTask = GetPreCanceledTask();

        public static Task Delay(int dueTimeMs)
        {
            if (dueTimeMs < -1)
                throw new ArgumentOutOfRangeException("dueTimeMs", "Invalid due time");
            if (dueTimeMs == 0)
                return _sPreCompletedTask;

            var tcs = new TaskCompletionSource<object>();
            var timer = new Timer(delegate(object self)
            {
                ((Timer)self).Dispose();
                tcs.TrySetResult(null);
            });

            timer.Change(dueTimeMs, -1);
            return tcs.Task;
        }

        private static Task GetPreCanceledTask()
        {
            var source = new TaskCompletionSource<object>();
            source.TrySetCanceled();
            return source.Task;
        }

        private static Task GetCompletedTask()
        {
            var source = new TaskCompletionSource<object>();
            source.TrySetResult(null);
            return source.Task;
        }
    }
}
