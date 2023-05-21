using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string InputKey;
    public UnityEvent OnInteraction;
    public UnityEvent InTrigger;
    public UnityEvent OutTrigger;

    private bool insideTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = true;
            InTrigger.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = false;
            OutTrigger.Invoke();
        }
    }

    private void Update()
    {
        //Debug.Log(insideTrigger);
        if (Input.GetKeyDown(InputKey) && insideTrigger)
        {
            OnInteraction.Invoke();
        }
    }
}
