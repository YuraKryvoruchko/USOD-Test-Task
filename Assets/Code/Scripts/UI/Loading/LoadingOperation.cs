using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UI
{
    public class LoadingOperation : ILoadingOperation
    {
        private ISaveLoadSystem _saveLoadSystem;

        public string Description { get => "Loading game data..."; }

        public event Action<GameData> OnLoadGameData;

        public LoadingOperation(ISaveLoadSystem saveLoadSystem)
        {
            _saveLoadSystem = saveLoadSystem;
        }
        public async Task Load(Action<float> onProgress, CancellationToken cancellationToken = default)
        {
            onProgress?.Invoke(0.3f);
            GameData data = await _saveLoadSystem.LoadGameData(cancellationToken);
            onProgress?.Invoke(1f);

            OnLoadGameData?.Invoke(data);
        }
    }
}
