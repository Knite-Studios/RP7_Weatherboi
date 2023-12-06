using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weather;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Vector2 _teleportPosition;
    [SerializeField] private float _teleportDelay = 0.5f;

    private Vector2 intialPos;
    private void Awake()
    {
        intialPos = transform.position;
        _teleportPosition = intialPos;
    }
    public void SetSpawnPoint(Vector2 spawnPoint)
    {
        _teleportPosition = spawnPoint;
    }
    public void Die()
    {
        if (!this.TryGetComponent(out IPlayerController controller)) return;

        controller.RepositionImmediately(_teleportPosition, true);
        controller.TogglePlayer(false);
        StartCoroutine(ActivatePlayer(controller));
    }

    private IEnumerator ActivatePlayer(IPlayerController controller)
    {
        yield return new WaitForSeconds(_teleportDelay);
        controller.TogglePlayer(true);
    }
}
