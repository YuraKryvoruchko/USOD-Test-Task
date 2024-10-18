using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class SaveLoadSystem : ISaveLoadSystem
    {
        private const int LOADING_DELAY_IN_MILLISECONDS = 5000;

        public async Task<GameData> LoadGameData(CancellationToken cancellationToken = default)
        {
            await Task.Delay(LOADING_DELAY_IN_MILLISECONDS, cancellationToken);
            return new GameData();
        }
    }
}
