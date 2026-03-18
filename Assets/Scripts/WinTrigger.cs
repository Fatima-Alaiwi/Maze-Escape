using StarterAssets;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerControl;
    [SerializeField] AudioSource levelJingle;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER REACHED FINISH");

            TimeLevel.gameEnded = true;

            //STOP PLAYER
            FirstPersonController controller = playerControl.GetComponent<FirstPersonController>();
            if (controller != null)
                controller.enabled = false;

            // STOP MUSIC
            if (levelBGM != null)
                levelBGM.SetActive(false);

            // PLAY WIN SOUND
            if (levelJingle != null)
                levelJingle.Play();

            // FADE OUT
            if (fadeOut != null)
                fadeOut.SetActive(true);
        }
    }
}