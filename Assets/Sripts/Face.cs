using UnityEngine;

public class Face : MonoBehaviour
{
    public GameObject OopFace;

    private void Start()
    {
        OopFace = GameObject.Find("�����h�y�X��").GetComponent<GameObject>();
    }
}
