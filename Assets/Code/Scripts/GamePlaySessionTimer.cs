using System;
using Zenject;
using UnityEngine;

namespace Core
{
    public class GamePlaySessionTimer : ITickable
    {
        private float _time;

        private bool _isActive;

        public event Action<float> OnTick;

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }
        public void Tick()
        {
            if (!_isActive)
                return;

            _time += Time.deltaTime;
            OnTick?.Invoke(_time);
        }
    }
}
