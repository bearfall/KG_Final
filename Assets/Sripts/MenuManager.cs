using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace bearfall
{
    /// <summary>
    /// 選單管理器
    /// </summary>

    public class MenuManager : MonoBehaviour
    {
        /// <summary>
        /// 開始遊戲
        /// </summary>
        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.KeypadEnter;
        private void Update()
        {
            GetStart();
        }

        public void GetStart()
        {
            if (Input.GetKeyDown(dialogueKey))
            {
                print("我按了Enter");
                SceneManager.LoadScene("遊戲場景");
            }
        }
    }
}