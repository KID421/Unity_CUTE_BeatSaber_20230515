using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成節點系統
    /// </summary>
    public class SpawnBeatSystem : MonoBehaviour
    {
        [Header("生成位置")]
        [SerializeField] private Transform pointLeft;
        [SerializeField] private Transform pointRight;
        [Header("生成物件"), SerializeField]
        private GameObject prefabBox;
        [Header("生成時間")]
        [SerializeField, Range(0, 10)]
        private float delayToSpawn;
        [SerializeField, Range(0, 10)]
        private float inteval = 1;

        private int[] angles = { 0, 90, 180, 270 };

        private void Awake()
        {
            InvokeRepeating("Spawn", delayToSpawn, inteval);
        }

        /// <summary>
        /// 生成
        /// </summary>
        private void Spawn()
        {
            GameObject tempBox = Instantiate(prefabBox);

            // left 0 | right 1
            int leftOrRight = Random.Range(0, 2);
            tempBox.transform.position = leftOrRight == 0 ? pointLeft.position : pointRight.position;

            // 角度隨機四種
            // 0 - 0 度
            // 1 - 90 度
            // 2 - 180 度
            // 3 - 270 度
            int randomAngle = Random.Range(0, 4);
            tempBox.transform.eulerAngles = new Vector3(0, 0, angles[randomAngle]);
        }
    }
}
