using System.Collections;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// ����t��
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        [Header("���C"), SerializeField]
        private Transform saberLeft, saberRight;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) StartCoroutine(ControlSaber(saberLeft));
            if (Input.GetKeyDown(KeyCode.RightArrow)) StartCoroutine(ControlSaber(saberRight));
        }

        
        private IEnumerator ControlSaber(Transform saber)
        {
            float x = saber.gameObject.name.Contains("��") ? -1 : 1;
            saber.position = new Vector3(x, 2, 1);

            for (int i = 0; i < 10; i++)
            {
                yield return null;
                saber.position -= Vector3.up * 0.1f;
            }
        }
    }
}
