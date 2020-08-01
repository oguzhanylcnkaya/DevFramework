using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _invertal;
        [NonSerialized]
        private Stopwatch _stopwatch;

        public PerformanceCounterAspect(int invertal=5)
        {
            _invertal = invertal;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();

            if(_stopwatch.Elapsed.TotalSeconds> _invertal)
            {
                //Buraya ihtiyacımıza göre ne yapacağımızı yazarız. Mesela performans beklediğimiz zamanı geçerse bize mail göndermesini isteyebiliriz. Yada aşağıda olduğu gibi Output ekranına yazdırabiliriz.

                Debug.WriteLine("PERFORMANCE: {0}.{1} -- <<Expected: {2}>>:<<Lasting Time: {3}>>",
                    args.Method.DeclaringType.FullName,
                    args.Method.Name,
                    _invertal,
                    _stopwatch.Elapsed.TotalSeconds);
            }

            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
