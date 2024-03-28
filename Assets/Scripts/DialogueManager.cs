using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public GameObject player;
    private string[] dialogueLines;
    private int currentLine = 0;

    private bool canDisplayNextLine = false;

    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponentInChildren<Animator>().enabled = false;
        StartCoroutine(EnableNextLineAfterDelay(1f)); // Add this line
    }

    public void DisplayNextLine()
    {
        if (!canDisplayNextLine) // Add this line
            return; // Add this line

        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            dialogueBox.SetActive(false);
            player.GetComponent<PlayerMovement_2D>().enabled = true;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponentInChildren<Animator>().enabled = true;
            canDisplayNextLine = false; // Add this line
        }
    }

    // Add this method
    private IEnumerator EnableNextLineAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canDisplayNextLine = true;
    }
}
