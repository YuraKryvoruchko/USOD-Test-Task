using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class GameUI : WindowBase
    {
        [SerializeField] private Text _timeText;

        public override void Show()
        {
            gameObject.SetActive(true);
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateTime(float time)
        {
            _timeText.text = time.ToString();
        }
    }
}
