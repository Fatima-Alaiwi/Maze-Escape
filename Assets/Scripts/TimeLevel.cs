using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using TMPro;

public class TimeLevel : MonoBehaviour
{
    public static bool gameEnded = false;

    [SerializeField] TMP_Text timeBox;
    [SerializeField] int timeLeft = 100;
    [SerializeField] bool takingSecond = false;

    [SerializeField] AudioSource timeUpSound;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject timeUp;

    [SerializeField] GameObject playerControl;
    [SerializeField] bool isRespawning = false;

    void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (timeBox != null)
        {
            timeBox.text = "TIME LEFT: " + timeLeft;
        }

        if (!takingSecond && !gameEnded)
        {
            StartCoroutine(RemoveSecond());
        }

        if (timeLeft <= 0 && !isRespawning && !gameEnded)
        {
            isRespawning = true;
            takingSecond = true;

            if (levelBGM != null)
                levelBGM.SetActive(false);

            if (timeUpSound != null)
                timeUpSound.Play();

            if (fadeOut != null)
                fadeOut.SetActive(true);

            if (timeUp != null)
                timeUp.SetActive(true);

            FirstPersonController controller = playerControl.GetComponent<FirstPersonController>();
            if (controller != null)
                controller.enabled = false;

            StartCoroutine(Respawn());
        }
    }

    IEnumerator RemoveSecond()
    {
        takingSecond = true;
        yield return new WaitForSeconds(1f);

        if (!gameEnded)
            timeLeft -= 1;

        takingSecond = false;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}