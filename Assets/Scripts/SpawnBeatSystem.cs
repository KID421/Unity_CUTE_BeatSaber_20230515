using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ͦ��`�I�t��
    /// </summary>
    public class SpawnBeatSystem : MonoBehaviour
    {
        [Header("�ͦ���m")]
        [SerializeField] private Transform pointLeft;
        [SerializeField] private Transform pointRight;
        [Header("�ͦ�����"), SerializeField]
        private GameObject prefabBox;
        [Header("�ͦ��ɶ�")]
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
        /// �ͦ�
        /// </summary>
        private void Spawn()
        {
            GameObject tempBox = Instantiate(prefabBox);

            // left 0 | right 1
            int leftOrRight = Random.Range(0, 2);
            tempBox.transform.position = leftOrRight == 0 ? pointLeft.position : pointRight.position;

            // �����H���|��
            // 0 - 0 ��
            // 1 - 90 ��
            // 2 - 180 ��
            // 3 - 270 ��
            int randomAngle = Random.Range(0, 4);
            tempBox.transform.eulerAngles = new Vector3(0, 0, angles[randomAngle]);
        }
    }
}
