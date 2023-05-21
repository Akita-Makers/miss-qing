using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI NameTextMesh;

    public TextMeshProUGUI SpeechTextMesh;

    // public void StartDialogue(List<Dialogue.Line> lines)
    // {

    // }

    public UnityEvent DialogueStart;
    public UnityEvent DialogueEnd;
    public IEnumerator DialogueLoop(List<Dialogue.Line> lines)
    {
        DialogueStart.Invoke();
        int dialougeIndex = 0;
        while (dialougeIndex < lines.Count)
        {
            NameTextMesh.text = lines[dialougeIndex].Name;
            SpeechTextMesh.text = lines[dialougeIndex].Speech;
            while (!Input.GetKeyDown(KeyCode.Return)) { yield return null; }
            dialougeIndex += 1;
            yield return null;
        }
        DialogueEnd.Invoke();
    }
}
