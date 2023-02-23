using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class DecoderSlot : MonoBehaviour, IDropHandler
{
    public GameObject thePic;
    public GameObject decodeLoading;
    private BoxCollider2D col;
    public WindowUI myDocuments;
    public GameObject resume, summonLetter;
    public DialogueRunner runner;
    public GameObject decipher;
    private bool isCollide = false;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped == thePic && isCollide)
        {
            Debug.Log("correct");
            decodeLoading.SetActive(true);
            decodeLoading.transform.SetAsLastSibling();
            Invoke("OpenDocuments", 2.4f);
        }
    }
    private void OpenDocuments()
    {
        myDocuments.OnOpen();
        resume.SetActive(true);
        summonLetter.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == thePic)
        {
            isCollide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == thePic)
        {
            isCollide = false;
        }
    }
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }
}
