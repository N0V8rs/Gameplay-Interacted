using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    [Header("Interactable Object")]
    public bool info;
    public TextMeshProUGUI infoText;
    public string message;

    [Header("Pickup Object")]
    public bool pickup;

    public void Info()
    {
        if (infoText != null)
        {
            infoText.text = message;
            StartCoroutine(ShowInfo(message));
            infoText.gameObject.SetActive(true);
            Debug.Log(message);
        }
        else
        {
            Debug.Log("No info text");
        }
    }

    public void Pickup()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Picked up" + gameObject.name);
    }

    IEnumerator ShowInfo(string message)
    {
        // Fade in
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            Color color = infoText.color;
            color.a = t;
            infoText.color = color;
            yield return null;
        }

        infoText.text = message;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Fade out
        t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
            Color color = infoText.color;
            color.a = t;
            infoText.color = color;
            yield return null;
        }

        infoText.text = null;
    }
}
