using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace bearfall
{
    /// <summary>
    /// 選單管理器
    /// </summary>

    public class ReplayManager : MonoBehaviour
    {
        /// <summary>
        /// 開始遊戲
        /// </summary>
        
        
        public void Replay()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("開始選單");
            }
            
        }
       
    }
}