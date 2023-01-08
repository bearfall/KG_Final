using UnityEngine;
namespace bearfall
{


    public class RunGhostTrigger : MonoBehaviour
    {

       
       
        [SerializeField, Header("追人鬼魂")]
        private GameObject badGhost;
        [SerializeField, Header("追人鬼魂生成點")]
        private Transform spawnBadGhost;
        private DialogueData dataDialogueActive;
        private string nameTarget = "PlayerCapsule";



        private void Start()
        {
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains(nameTarget))
            {
                print(other.name);

                Instantiate(badGhost, spawnBadGhost.position, spawnBadGhost.rotation);

                transform.GetComponent<Collider>().enabled = false;
            }
            
        }
       

    }
}