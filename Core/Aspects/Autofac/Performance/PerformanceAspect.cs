using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();

        }
        public override void OnBefore(IInvocation invocation)
        {
            _stopWatch.Start();
        }
        public override void OnAfter(IInvocation invocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}");

            }
            _stopWatch.Reset();

        }

    }
}
