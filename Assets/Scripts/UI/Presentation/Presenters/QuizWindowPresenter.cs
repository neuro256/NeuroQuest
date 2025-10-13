using NeuroQuest.Gameplay;
using NeuroQuest.Infrastructure;
using System;
using UnityEngine;

namespace NeuroQuest.UI.Presentation
{
    public class QuizWindowPresenter : BaseWindowPresenter<QuizWindowView>
    {
        private readonly QuestionData _questionData;
        private readonly Action _onSuccess;
        private readonly Action _onFail;

        public QuizWindowPresenter(QuizWindowView view, QuestionData question, Action onSuccess, Action onFail)
            : base(view)
        {
            _questionData = question;
            _onSuccess = onSuccess;
            _onFail = onFail;
        }

        public override void Show()
        {
            base.Show();

            if (_questionData == null)
            {
                Debug.LogError("Question data is null");
                return; 
            }

            if(!string.IsNullOrEmpty(_questionData.QuestionSpritePath))
            {
                AddressablesLoader.LoadAsync<Sprite>(_questionData.QuestionSpritePath, (sprite) =>
                {
                    _view.ShowQuestion(null, sprite, _questionData.Answers, OnAnswerSelected);
                });
            }
            else
            {
                _view.ShowQuestion(_questionData.QuestionText, null, _questionData.Answers, OnAnswerSelected);
            }
        }

        private void OnAnswerSelected(bool isCorrect)
        {
            if (isCorrect)
            {
                Hide();
                _onSuccess?.Invoke();
            }
            else
            {
                _onFail?.Invoke();
            }
        }
    }
}

