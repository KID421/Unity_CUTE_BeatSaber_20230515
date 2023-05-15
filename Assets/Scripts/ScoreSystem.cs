using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���ƨt��
    /// </summary>
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem instance;

        [Header("�K�[����"), SerializeField, Range(0, 100)]
        private int scoreAdd = 50;
        [Header("���Ƥ�r"), SerializeField]
        private TextMeshProUGUI textScore;

        private int scoreTotal;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// ��s����
        /// </summary>
        public void UpdateScore()
        {
            scoreTotal += scoreAdd;
            textScore.text = $"SCORE {scoreTotal}";
        }
    }
}
