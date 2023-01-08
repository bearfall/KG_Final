using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace bearfall
{
    /// <summary>
    /// ��ܨt��
    /// </summary>

    public class DialogueSystem : MonoBehaviour
    {
        #region ��ưϰ�
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("�}�Y���")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("��ܫ���")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);


        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        private PlayerInput playerInput;
        private UnityEvent onDialogueFinish;
        #endregion




        #region �ƥ�
        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("��ܧ����ϥ�");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        } 
        #endregion
        /// <summary>
        /// �}�l���
        /// </summary>
        /// <param name="data">�n���檺��ܸ��</param>
        /// <param name="_onDialogueFinish">��ܵ������ƥ�A�i�H���ŭ�</param>
        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }
        /// <summary>
        /// �H�J�H�X�s�ժ���
        /// </summary>
        private IEnumerator FadeGroup(bool fadeIn = true)
        {

            float increase = fadeIn ? +0.1f : -0.1f;
            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }
        #region ���r�ĪG
        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContent.text = "";
                goTriangle.SetActive(false);

                string dialogue = data.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueInterval;
                }

                goTriangle.SetActive(true);

                //�p�G ���a �٨S���U ���w���� �N����
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;             //�}�Ҫ��a��J����
            onDialogueFinish?.Invoke();               //��ܵ����ƥ�.�I�s();
        }
        #endregion
    }
}