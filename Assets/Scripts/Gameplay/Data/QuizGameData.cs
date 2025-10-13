using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/Games/QuizGameData", fileName = "NewQuizGameData")]
    public class QuizGameData : BaseGameData
    {
        public override GameType GameType => GameType.Quiz;

        [SerializeField] private QuestionData _questionData;
        public QuestionData QuestionData => _questionData;
    }
}
