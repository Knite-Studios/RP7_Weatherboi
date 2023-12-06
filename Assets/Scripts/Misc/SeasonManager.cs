using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : Singleton<SeasonManager>
{
    enum Season { Normal, Summer, Winter };

    [Header("Season Timer"), SerializeField]
    float seasonDuration = 10f;

    private Season currentSeason;
    float time = 0f;
    void Start()
    {
        SetSeason(Season.Normal);
    }
    private void SetSeason(Season newSeason)
    {
        currentSeason = newSeason;
        StopAllCoroutines();

        switch (currentSeason)
        {
            case Season.Normal:
                StartCoroutine(ResetToNormal());
                break;
            case Season.Winter:
                StartCoroutine(WinterTime());
                break;
            case Season.Summer:
                StartCoroutine(SummerTime());
                break;
            default:
                break;
        }

    }
    private IEnumerator SummerTime()
    {
        time = 0f;
       
        yield return null;
    }
    private IEnumerator WinterTime()
    {
        time = 0f;
        
        yield return null;
    }
    private IEnumerator ResetToNormal()
    {
        Debug.Log("Resetting to normal");
      
        yield return null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetSeason(Season.Winter);
            Debug.Log("Winter");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetSeason(Season.Summer);
            Debug.Log("Summer");
        }

        time += Time.deltaTime;

       


    }
}
