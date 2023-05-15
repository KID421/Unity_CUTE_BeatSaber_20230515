using UnityEngine;

namespace KID
{
    /// <summary>
    /// 盒子移動與打擊判定
    /// </summary>
    public class BoxSystem : MonoBehaviour
    {
        [Header("移動速度"), SerializeField, Range(0, 100)]
        private float moveSpeed = 3.5f;
        [Header("判定區塊")]
        [SerializeField] private Vector3 checkPointUpSize = Vector3.one;
        [SerializeField] private Vector3 checkPointUpOffset;
        [SerializeField] private Vector3 checkPointDownSize = Vector3.one;
        [SerializeField] private Vector3 checkPointDownOffset;

        [SerializeField, Header("光劍圖層")]
        private LayerMask layerSword;

        private bool isIn;

        private void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

            Gizmos.color = new Color(0, 1, 0.3f, 0.5f);
            Gizmos.DrawCube(
                checkPointUpOffset,
                checkPointUpSize);
            Gizmos.color = new Color( 1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(
                checkPointDownOffset,
                checkPointDownSize);
        }

        private void Update()
        {
            Move();
            CheckSword();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.World);
        }

        /// <summary>
        /// 檢查光劍
        /// </summary>
        private void CheckSword()
        {
            Collider[] hitsUp = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(checkPointUpOffset),
                checkPointUpSize / 2, Quaternion.identity, layerSword);

            if (hitsUp.Length > 0) isIn = true;

            Collider[] hitsDown = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(checkPointDownOffset),
                checkPointDownSize / 2, Quaternion.identity, layerSword);

            if (isIn && hitsDown.Length > 0)
            {
                AudioClip sound = SoundSystem.instance.soundHit;
                SoundSystem.instance.PlaySound(sound, 0.7f, 1.2f);
                ScoreSystem.instance.UpdateScore();
                Destroy(gameObject);
            }
        }
    }
}
