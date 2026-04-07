using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StackExample : MonoBehaviour
{
    private Stack<string> effects = new Stack<string>();

    public Text display;

    private float timer = 0;
    private float timePerTurn = 5;

    private void Start()
    {
        DoAThing();
    }

    //This is a garbage function that only exists to show you a StackTrace.
    public void DoAThing()
    {
        int[] iArray = new int[2];
        
        Debug.Log(iArray[0]);
        iArray[5] = 0;
    }

    private void Update()
    {
        // If you press space, reload the scene.  This makes it easy to restart!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // If a move takes more than 5 seconds, continue.
        if (timer > timePerTurn) return;
        
        // Increase the timer.
        timer += Time.deltaTime;

        // If you press A, S, D, or F, push that move into the stack.
        if (Input.GetKeyDown(KeyCode.A))
        {
            effects.Push("Card: Ace");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            effects.Push("Card: King");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            effects.Push("Card: Queen");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            effects.Push("Card: Jack");
        }

        // If the time is up, say that time is up and show the effects.
        if (timer >= timePerTurn)
        {
            display.text = "Time is up!\n";

            ShowCardStack();
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F1");
        }

        if (Input.GetMouseButtonDown(0))
        {
            ThrowException();
        }
    }

    private void ShowCardStack()
    {
        
        // While there are effects in the stack, pop them out and show them.
        while (effects.Count > 0)
        {
            display.text += "\n" + effects.Pop();
        }
    }
    
    void ThrowException()
    {
        throw new NotImplementedException();
    }
}
