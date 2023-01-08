using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
namespace bearfall
{

    public class DestoryPlayer : MonoBehaviour
    {
        [SerializeField, Header("會造成傷害的目標")]
        private string nameTarget;
        private PlayerInput playerInput;
        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.R;
        
        void Start()
        {
            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();
            
        }
        private void OnCollisionEnter(Collision other)
        {
            print("碰撞:" + other.gameObject);
            if (other.gameObject.name.Contains(nameTarget))
            {
                FinalManager.instance.GameOver("遊戲結束");
                Replay();
                playerInput.enabled = false;
            }
        }
        private void Replay()
        {
            if (Input.GetKeyDown(dialogueKey))
            {
                print("我按了R");
                SceneManager.LoadScene("開始選單");
            }

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}