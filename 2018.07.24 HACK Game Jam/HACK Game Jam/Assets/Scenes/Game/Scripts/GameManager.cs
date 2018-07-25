using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int threatTimer;

    public string currentPlayer;

    public enum States { P1Turn, P2Turn, P3Turn, P4Turn, SweepTime};
    private States state;

    // Use this for initialization
    void Start () {
        state = States.P1Turn;
        Debug.Log("Player1's Turn!");
        threatTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.SweepTime:
                Debug.Log("Threat Detection Underway...");
                state = States.P1Turn;
                break;

            case States.P1Turn:
               
                currentPlayer = "Player1";
              
                if (Input.GetKeyDown(KeyCode.Mouse0)){
                    state = States.P2Turn;
                    Debug.Log("Player 2's Turn!");
                }
                break;

            case States.P2Turn:
                currentPlayer = "Player2";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    state = States.P3Turn;
                    Debug.Log("Player 3's Turn!");
                }
                break;

            case States.P3Turn:
                currentPlayer = "Player3";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    state = States.P4Turn;
                    Debug.Log("Player 4's Turn!");
                }
                break;

            case States.P4Turn:
                currentPlayer = "Player4";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    threatTimer++;
                    if (threatTimer >= 2)
                    {
                        state = States.SweepTime;
                    }
                    else
                    {
                        Debug.Log("Player 1's Turn!");
                        state = States.P1Turn;
                    }
                    
                }
                break;
        }
    }
   
}
