using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject openPosObj;
    private Vector3 openPos;
    private Vector3 closePos;
    private Color originalColor;
    [SerializeField] float closingSpeed = 1f;
    [SerializeField] float fadeSpeed = 2f;

    private bool isOpen = false;

    void Start()
    {
        closePos = door.transform.position;
        openPos = openPosObj.transform.position;
        originalColor = door.GetComponent<SpriteRenderer>().color;
    }

    public void TriggerDoor()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        while (Vector3.Distance(door.transform.position, openPos) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, openPos, closingSpeed * Time.deltaTime);
            FadeOut();
            yield return null;
        }
        isOpen = true;
    }

    private IEnumerator CloseDoor()
    {
        while (Vector3.Distance(door.transform.position, closePos) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, closePos, closingSpeed * Time.deltaTime);
            FadeIn();
            yield return null;
        }
        isOpen = false;
    }

    private void FadeIn()
    {
        Color smoothColor = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(door.GetComponent<SpriteRenderer>().color.a, 1f, fadeSpeed * Time.deltaTime));
        door.GetComponent<SpriteRenderer>().color = smoothColor;
    }

    private void FadeOut()
    {
        Color smoothColor = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(door.GetComponent<SpriteRenderer>().color.a, 0f, fadeSpeed * Time.deltaTime));
        door.GetComponent<SpriteRenderer>().color = smoothColor;
    }
}
