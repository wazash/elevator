using System.Collections;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private AudioClip startSFX, stopSFX, movingSFX;
    [SerializeField] private AudioSource audioSource;

    private ElevatorController elevatorController;

    #region INITIALIZATION AND EVENTS
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
    #endregion

    #region METHODS
    private void PlayStartSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(startSFX);

        PlayMovingMusic(movingSFX, startSFX.length);
    }
    private IEnumerator PlayStopSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(stopSFX);

        yield return new WaitForSeconds(stopSFX.length);
    }

    private void PlayMovingMusic(AudioClip clip, float delay)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.PlayDelayed(delay);
    } 
    #endregion
}
