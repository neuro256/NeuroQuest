using NeuroQuest.Gameplay;
using NeuroQuest.UI.Presentation;
using System;
using UnityEngine;

namespace NeuroQuest.Infrastructure
{
    public enum GameType
    {
        Quiz = 1,
        MiniGame = 2
    }

    public class GameController : MonoBehaviour
    {
        [SerializeField] private WindowManager _windowManager;
        [SerializeField]
        [TextArea]
        private string _tutorualInfo;

        private void Start()
        {
            _windowManager.ShowInfoWindow(_tutorualInfo);
        }

        public void StartGame(BaseGameData gameData, Action onSuccess = null, Action onFail = null)
        {
            switch(gameData.GameType)
            {
                case GameType.Quiz:
                    StartQuiz((QuizGameData) gameData, onSuccess, onFail);
                    break;
                case GameType.MiniGame:
                    StartMiniGame((MiniGameData)gameData, onSuccess, onFail);
                    break;
            }
        }

        private void StartQuiz(QuizGameData gameData, Action onSuccess = null, Action onFail = null)
        {
            var question = gameData.QuestionData;

            if (question == null)
            {
                Debug.LogError("question data is null");
                return;
            }

            _windowManager.ShowQuiz(gameData.QuestionData,
                onSuccess: () =>
                {
                    _windowManager.ShowNotification(question.CorrectAnswerMessage);
                    onSuccess?.Invoke();
                }, onFail: () =>
                {
                    _windowManager.ShowNotification(question.WrongAnswerMessage, question.NotificationDuration);
                    onFail?.Invoke();
                });
        }

        private void StartMiniGame(MiniGameData gameData, Action onSuccess = null, Action onFail = null)
        {
            _windowManager.ShowMiniGame(gameData, onSuccess: () =>
            {
                _windowManager.ShowNotification(gameData.WinMessage);
                onSuccess?.Invoke();
            }, onFail: () =>
            {
                _windowManager.ShowNotification(gameData.GameOverMessage);
                onFail?.Invoke();
            });
        }
    }
}

