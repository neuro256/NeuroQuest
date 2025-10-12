using UnityEngine;

namespace NeuroQuest.UI.Data
{
    [CreateAssetMenu(menuName = "NeuroQuest/UI/QuestionData", fileName = "NewQuestionData")]
    public class QuestionData : ScriptableObject
    {
        [SerializeField]
        [TextArea] 
        private string _questionText;
        [SerializeField]
        private string _questionSpritePath;
        [SerializeField]
        private string[] _answers;

        public string QuestionText => _questionText;
        public string QuestionSpritePath => _questionSpritePath;
        public string[] Answers => _answers;
    }
}

