using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UI
{
    public class GameInitializationOperation : ILoadingOperation
    {
        private const int GAME_INITIALIZATION_DELAY_IN_MILLISECONDS = 1000;

        public string Description { get => "Game initialization..."; }

        public async Task Load(Action<float> onProgress, CancellationToken cancellationToken = default)
        {
            await Task.Delay(GAME_INITIALIZATION_DELAY_IN_MILLISECONDS);
        }
    }
}
