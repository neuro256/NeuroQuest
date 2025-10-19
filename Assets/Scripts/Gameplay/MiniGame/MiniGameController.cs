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
        private Coroutine _levelSequence;

        public void StartGame(MiniGameData data, Action onSuccess, Action onFail)
        {
            if (_isPlaying)
                return;

            _gameData = data;
            _onSuccess = onSuccess;
            _onFail = onFail;

            _isPlaying = true;
            _levelSequence = StartCoroutine(LevelSequence());
        }

        public void EndGame(bool result)
        {
            if (!_isPlaying) return;

            _isPlaying = false;
            _enemySpawner.StopSpawning();

            if (_levelSequence != null)
                StopCoroutine(_levelSequence);

            if (result)
                _onSuccess?.Invoke();
            else
                _onFail?.Invoke();
        }

        private IEnumerator LevelSequence()
        {
            foreach (var level in _gameData.Levels)
            {
                _enemySpawner.Init(level);
                _enemySpawner.StartSpawning();

                yield return new WaitForSeconds(level.Duration);

                _enemySpawner.StopSpawning();

                yield return new WaitForSeconds(level.PauseBetweenLevels);
            }

            EndGame(true);
        }
    }
}

