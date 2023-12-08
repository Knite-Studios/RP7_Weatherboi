using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TutorialScreen : MonoBehaviour
{

    [SerializeField]
    GameObject tutorialText;


    void Start()
    {
        if (tutorialText != null)
            tutorialText.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorialText != null)
                tutorialText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorialText != null)
                tutorialText.SetActive(false);
        }
    }
           
   
}
