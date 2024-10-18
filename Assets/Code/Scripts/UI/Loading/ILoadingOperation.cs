using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UI
{
    public interface ILoadingOperation
    {
        public string Description { get; }

        public Task Load(Action<float> onProgress, CancellationToken cancellationToken = default);
    }
}
