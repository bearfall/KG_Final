using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
namespace bearfall
{
    /// <summary>
    /// 結束管理器
    /// </summary>

    public class FinalManager : MonoBehaviour
    {

        public static FinalManager instance;
        /// <summary>
        /// 結束畫布
        /// </summary>
        private CanvasGroup groupFinal;
        /// <summary>
        /// 結束標題
        /// </summary>
        private TextMeshProUGUI textTitle;
        /// <summary>
        /// 重新遊戲
        /// </summary>
        
        private void Awake()
        {
            instance = this;

            groupFinal = GameObject.Find("結束畫布").GetComponent<CanvasGroup>();
            textTitle = GameObject.Find("結束標題").GetComponent<TextMeshProUGUI>();
            


        }
        /// <summary>
        /// 遊戲結束
        /// </summary>
        /// <param name="title">遊戲標題</param>
        public void GameOver(string title)
        {
            textTitle.text = title;

            StartCoroutine(FadeIn());
        }

        /// <summary>
        /// 淡入
        /// </summary>
        private IEnumerator FadeIn()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.02f);
            }
            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
            
        }

       
    }
}
