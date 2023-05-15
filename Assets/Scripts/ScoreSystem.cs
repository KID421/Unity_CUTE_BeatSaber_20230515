using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// だ计╰参
    /// </summary>
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem instance;

        [Header("睰だ计"), SerializeField, Range(0, 100)]
        private int scoreAdd = 50;
        [Header("だ计ゅ"), SerializeField]
        private TextMeshProUGUI textScore;

        private int scoreTotal;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// 穝だ计
        /// </summary>
        public void UpdateScore()
        {
            scoreTotal += scoreAdd;
            textScore.text = $"SCORE {scoreTotal}";
        }
    }
}
