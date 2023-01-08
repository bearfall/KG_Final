using UnityEngine;
using UnityEngine.SceneManagement;
namespace bearfall
{
    
    /// <summary>
    /// 玩家結束管理:死亡或過關
    /// </summary>

    public class PlayerFinal : MonoBehaviour
    {
        [SerializeField, Header("會造成傷害的目標")]
        private string nameTarget;

        private void OnDestroy()
        {
            FinalManager.instance.GameOver("遊戲結束");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //過關
            FinalManager.instance.GameOver("遊戲通過");
        }
    }
}
