using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : Singleton<SeasonManager>
{
    public enum Season { Fall, Summer, Winter };

    [Header("Season Timer"), SerializeField]
    public float seasonDuration = 10f;
    [SerializeField]
    float seasonCoolDown = 10f;

    public event Action<Season> OnSeasonChange;

    private Season currentSeason;
    public float duration = 0f;
    float coolDown = 0f;
    void Start()
    {
        duration = seasonDuration;
        SetSeason(Season.Fall);
        coolDown = seasonCoolDown;
    }
    private void SetSeason(Season newSeason)
    {
        currentSeason = newSeason;
        OnSeasonChange?.Invoke(currentSeason);

        StopAllCoroutines();

        switch (currentSeason)
        {
            case Season.Fall:
                StartCoroutine(ResetToFall());
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
        duration = seasonDuration;

        yield return null;
    }
    private IEnumerator WinterTime()
    {
        duration = seasonDuration;

        yield return null;
    }
    private IEnumerator ResetToFall()
    {
        Debug.Log("Resetting to Fall done");
        OnSeasonChange?.Invoke(currentSeason);
        yield return null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && coolDown >= seasonCoolDown)
        {
            coolDown = 0f;
            SetSeason(Season.Winter);
            Debug.Log("Winter");
        }
        if (Input.GetKeyDown(KeyCode.L) && coolDown >= seasonCoolDown)
        {
            coolDown = 0f;
            SetSeason(Season.Summer);
            Debug.Log("Summer");
        }
        if (duration <= 0 && currentSeason != Season.Fall)
        {
            SetSeason(Season.Fall);
            Debug.Log("Fall");
        }
        duration -= Time.deltaTime;
        coolDown += Time.deltaTime;
    }
    public Season GetCurrentSeason()
    {
            Season season;
            season = currentSeason;
            return season;
    }
}
