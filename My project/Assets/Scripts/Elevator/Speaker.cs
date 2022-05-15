using System.Collections;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private AudioClip startSFX, stopSFX, movingSFX;
    [SerializeField] private AudioSource audioSource;

    private ElevatorController elevatorController;

    private bool isMovingPlaying = false;

    private void Awake()
    {
        elevatorController = GetComponent<ElevatorController>();

        elevatorController.OnStartMoving += ElevatorController_OnStartMoving;
        elevatorController.OnStopMoving += ElevatorController_OnStopMoving;
    }
    private void OnDestroy()
    {
        elevatorController.OnStartMoving -= ElevatorController_OnStartMoving;
        elevatorController.OnStopMoving -= ElevatorController_OnStopMoving;
    }
    private void ElevatorController_OnStartMoving()
    {
        PlayStartSFX();
    }
    private void ElevatorController_OnStopMoving()
    {
        StartCoroutine(PlayStopSFX());
    }

    private void PlayStartSFX()
    {
        audioSource.PlayOneShot(startSFX);

        audioSource.clip = movingSFX;
        audioSource.loop = true;
        audioSource.PlayDelayed(startSFX.length);
    }
    private IEnumerator PlayStopSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(stopSFX);

        yield return new WaitForSeconds(stopSFX.length);
        StopAllCoroutines();
    }
}
