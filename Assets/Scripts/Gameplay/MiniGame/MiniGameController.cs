using System;
using System.Collections;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private MiniGameData _gameData;
        private bool _isPlaying;
        private Action _onSuccess;
        private Action _onFail;
        private Coroutine _autoClose;

        public void StartGame(MiniGameData data, Action onSuccess, Action onFail)
        {
            if (_isPlaying)
                return;

            _gameData = data;
            _onSuccess = onSuccess;
            _onFail = onFail;

            _isPlaying = true;

            _enemySpawner.Init();
            _enemySpawner.StartSpawning();

            _autoClose = StartCoroutine(AutoClose(data.Duration));
        }

        public void EndGame(bool result)
        {
            if (!_isPlaying) return;

            _isPlaying = false;
            _enemySpawner.StopSpawning();

            if (_autoClose != null)
                StopCoroutine(_autoClose);

            if (result)
                _onSuccess?.Invoke();
            else
                _onFail?.Invoke();
        }

        private IEnumerator AutoClose(float delay)
        {
            yield return new WaitForSeconds(delay);

            EndGame(true);
        }
    }
}

