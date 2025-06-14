using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ReactionTest : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text infoText;
    public Button startButton;

    private bool testStarted = false;
    private bool canClick = false;
    private float startTime;

    public void StartTest()
    {
        startButton.gameObject.SetActive(false);
        infoText.text = "Palauk... nepaspausk per anksti!";
        panel.GetComponent<Image>().color = Color.red;

        testStarted = true;
        canClick = false;

        StartCoroutine(WaitAndStart());
    }

    IEnumerator WaitAndStart()
    {
        float waitTime = Random.Range(2f, 5f);
        yield return new WaitForSeconds(waitTime);

        panel.GetComponent<Image>().color = Color.green;
        infoText.text = "Spausk dabar!";
        startTime = Time.time;
        canClick = true;
    }

    void Update()
    {
        if (testStarted && Input.GetMouseButtonDown(0))
        {
            if (canClick)
            {
                float reactionTime = Time.time - startTime;
                infoText.text = $"Tavo reakcija: {reactionTime:F3} sek.";
            }
            else
            {
                StopAllCoroutines();
                infoText.text = "Per anksti! Bandyk iš naujo.";
                panel.GetComponent<Image>().color = Color.red;
            }

            testStarted = false;
            canClick = false;
            startButton.gameObject.SetActive(true);
        }
    }
}
