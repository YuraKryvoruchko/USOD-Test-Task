using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public interface ISaveLoadSystem
    {
        Task<GameData> LoadGameData(CancellationToken cancellationToken = default);
    }
}
