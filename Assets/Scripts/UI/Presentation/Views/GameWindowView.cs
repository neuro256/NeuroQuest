using NeuroQuest.UI.Data;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NeuroQuest.UI.Presentation
{
    public class GameWindowView : BaseWindowView
    {
        [SerializeField]
        private TextMeshProUGUI _questionText;
        [SerializeField]
        private Image _questionImage;
        [SerializeField]
        private Transform _answersContainer;
        [SerializeField]
        private Button _answerButtonPrefab;

        public void ShowQuestion(string text, Sprite image, Answer[] answers, Action<bool> onAnswerSelected)
        {
            if(!string.IsNullOrEmpty(text))
            {
                _questionText.gameObject.SetActive(true);
                _questionText.text = text; 
            }

            if (image != null)
            {
                _questionImage.gameObject.SetActive(true);
                _questionImage.sprite = image;
            }

            foreach (Transform child in _answersContainer)
                Destroy(child.gameObject);

            for (int i = 0; i < answers.Length; i++)
            {
                var btn = Instantiate(_answerButtonPrefab, _answersContainer);
                btn.GetComponentInChildren<TMP_Text>().text = answers[i].Text;
                bool isCorrect = answers[i].IsCorrect;
                btn.onClick.AddListener(() => onAnswerSelected?.Invoke(isCorrect));
            }
        }
    }
}

