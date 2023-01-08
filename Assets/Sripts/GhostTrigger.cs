using UnityEngine;
namespace bearfall
{


    public class GhostTrigger : MonoBehaviour
    {

        [SerializeField, Header("鬼魂編號")]
        private GameObject ghost;
        [SerializeField, Header("動畫")]
        private Animator Animator;
        [SerializeField, Header("聲音來源")]
        private AudioSource Aud;
        [SerializeField, Header("聲音")]
        private AudioClip Oop;




        private void Start()
        {
            Animator = ghost.GetComponent<Animator>();
            Aud = ghost.GetComponent<AudioSource>();
        }
        private void OnTriggerEnter(Collider other)
        {
            print(other.name);
            GoGhostGo();
            PlaySound(Oop);
            transform.GetComponent<Collider>().enabled = false;


        }
        public void PlaySound(AudioClip sound)
        {
            Aud.PlayOneShot(sound);
        }
        void GoGhostGo()
        {
                Animator.enabled = true;
           
        }

    }
}