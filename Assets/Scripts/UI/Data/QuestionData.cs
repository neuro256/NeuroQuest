using System;
using UnityEngine;

namespace NeuroQuest.UI.Data
{
    [Serializable]
    public class Answer
    {
        public string Text;
        public bool IsCorrect;
    }

    [CreateAssetMenu(menuName = "NeuroQuest/UI/QuestionData", fileName = "NewQuestionData")]
    public class QuestionData : ScriptableObject
    {
        [SerializeField]
        [TextArea] 
        private string _questionText;
        [SerializeField]
        private string _questionSpritePath;
        [SerializeField]
        private Answer[] _answers;

        public string QuestionText => _questionText;
        public string QuestionSpritePath => _questionSpritePath;
        public Answer[] Answers => _answers;
    }
}

