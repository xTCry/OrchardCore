using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.DisplayManagement.Implementation;
using StackExchange.Profiling;

namespace OrchardCore.MiniProfiler
{
    public class ShapeStep : IShapeDisplayEvents
    {
        private Dictionary<object, IDisposable> _timings = new Dictionary<object, IDisposable>();

        public Task DisplayedAsync(ShapeDisplayContext context)
        {
        //removing value and disposition of new value
            if (_timings.TryGetValue(context, out IDisposable timing))
            {
                _timings.Remove(context);
                timing.Dispose();
            }

            return Task.CompletedTask;
        }

        public Task DisplayingAsync(ShapeDisplayContext context)
        {
        // adding of timings value
            var timing = StackExchange.Profiling.MiniProfiler.Current.Step($"Shape: {context.Shape.Metadata.Type}");
            _timings.Add(context, timing);
            return Task.CompletedTask;
        }

        // when analysis has ended  
        public Task DisplayingFinalizedAsync(ShapeDisplayContext context)
        {
            if (_timings.TryGetValue(context, out IDisposable timing))
            {
                _timings.Remove(context);
                timing.Dispose();
            }

            return Task.CompletedTask;
        }
    }
}
