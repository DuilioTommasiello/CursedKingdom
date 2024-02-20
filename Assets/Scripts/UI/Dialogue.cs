using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)]private string[] dialogueLines;
    private bool isPLayerRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
    
    void Update()
    {
        if (isPLayerRange && Input.GetButtonDown("Interaction"))
        {
            if (!didDialogueStart)
            {
                 StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialaguoeLine(); 
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
           
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0;
        StartCoroutine(showLine());
    }

    private void NextDialaguoeLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(showLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1;
        }
    }

    private IEnumerator showLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPLayerRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Puedo Hbalar");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPLayerRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("No se puede iniciar");
        }
        
    }
}
