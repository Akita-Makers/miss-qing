using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<Line> Lines;
    private DialogueManager dialogueManager;

    [System.Serializable]
    public struct Line
    {
        public string Name;
        [TextArea(3, 6)]
        public string Speech;
    }

    public void StartDialogue()
    {
        StartCoroutine(dialogueManager.DialogueLoop(Lines));
    }

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
}
