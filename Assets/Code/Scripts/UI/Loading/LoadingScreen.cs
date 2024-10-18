using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Slider _progressSlider;

        public async Task Load(Queue<ILoadingOperation> loadingOperations)
        {
            foreach (ILoadingOperation operation in loadingOperations)
            {
                _progressSlider.value = 0;

                _descriptionText.text = operation.Description;
                await operation.Load(OnUpdateProgress);
            }
        }

        private void OnUpdateProgress(float progress)
        {
            _progressSlider.value = progress;
        }
    }
}
