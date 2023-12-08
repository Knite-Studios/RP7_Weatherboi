using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonalModifier : MonoBehaviour
{
    [Header("Season Objects"), SerializeField]
    GameObject[] fallObjects;
    [SerializeField]
    GameObject[] winterObjects;
    [SerializeField]
    GameObject[] summerObjects;

    private void Awake()
    {
        SeasonManager.Instance.OnSeasonChange += HandleSeasonChange;
    }

    private void HandleSeasonChange(SeasonManager.Season newSeason)
    {
        switch (newSeason)
        {
            case SeasonManager.Season.Fall:
                SetObjectsActive(winterObjects, false);
                SetObjectsActive(summerObjects, false);
                SetObjectsActive(fallObjects, true);

                break;
            case SeasonManager.Season.Winter:
                SetObjectsActive(fallObjects, false);
                SetObjectsActive(summerObjects, false);
                SetObjectsActive(winterObjects, true);
                break;
            case SeasonManager.Season.Summer:
                SetObjectsActive(fallObjects, false);
                SetObjectsActive(winterObjects, false);
                SetObjectsActive(summerObjects, true);
                break;
            default:
                break;
        }
    }

    // Helper method to set object activity
    private void SetObjectsActive(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
