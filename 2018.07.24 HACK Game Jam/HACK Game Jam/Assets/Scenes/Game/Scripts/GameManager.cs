using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int threatTimer;

    public string currentPlayer;

    public enum States { P1Turn, P2Turn, P3Turn, P4Turn, SweepTime};
    private States state;

    public static GameManager instance = null;

    private int minSuccessRate = 0;
    private int maxSuccessRate = 100;

    public Sprite empty;
    public Sprite p1;
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;

    public int p1PP;
    public int p2PP;
    public int p3PP;
    public int p4PP;

    public int currentPlayerPP;

    public Text currentPlayerTurnText;
    public Text currentPlayerPPText;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        state = States.P1Turn;
        currentPlayer = "Player1";
        Debug.Log("Player1's Turn!");
        threatTimer = 0;
        p1PP = 0;
        p2PP = 0;
        p3PP = 0;
        p4PP = 0;
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
                currentPlayerPP = p1PP;
                currentPlayerPPText.text = "PP - " + currentPlayerPP;
                currentPlayerTurnText.text = "P1";
                //Debug.Log("Player 1's Turn!");
                currentPlayer = "Player1";              
               
                break;

            case States.P2Turn:
                currentPlayerPP = p2PP;
                currentPlayer = "Player2";
                currentPlayerPPText.text = "PP - " + currentPlayerPP;
                currentPlayerTurnText.text = "P2";
                //Debug.Log("Player 2's Turn!");
                currentPlayer = "Player2";
               
                break;

            case States.P3Turn:
                currentPlayer = "Player3";
                currentPlayerPP = p3PP;
                currentPlayerPPText.text = "PP - " + currentPlayerPP;
                currentPlayerTurnText.text = "P3";
                //Debug.Log("Player 3's Turn!");
                currentPlayer = "Player3";
               
                break;

            case States.P4Turn:
                currentPlayer = "Player4";
                currentPlayerPP = p4PP;
                currentPlayerPPText.text = "PP - " + currentPlayerPP;
                currentPlayerTurnText.text = "P4";
                //Debug.Log("Player 4's Turn!");
                currentPlayer = "Player4";
                
                break;
        }
    }

    public void HackAttempt(GameObject node)
    {
        
        Debug.Log("Hack Initiated!");
        if (Random.Range(minSuccessRate, maxSuccessRate) - currentPlayerPP <= node.GetComponent<NodeClick>().successRate)
        {
            StartCoroutine(WaitTimeSuccess(node));
        }
        else
        {
            StartCoroutine(WaitTimeFail(node));

        }
    }

    IEnumerator WaitTimeSuccess(GameObject node)
    {
        yield return new WaitForSeconds(1);
        node.GetComponent<NodeClick>().buttonPressed = true;
        node.tag = currentPlayer;
        Debug.Log("Hack Successful!");
        if (state == States.P1Turn)
        {
            node.GetComponent<NodeClick>().spriteRenderer.sprite = p1;
            p1PP += node.GetComponent<NodeClick>().PPGained;
        }
        else if (state == States.P2Turn)
        {
            node.GetComponent<NodeClick>().spriteRenderer.sprite = p2;
            p2PP += node.GetComponent<NodeClick>().PPGained;
        }
        else if (state == States.P3Turn)
        {
            node.GetComponent<NodeClick>().spriteRenderer.sprite = p3;
            p3PP += node.GetComponent<NodeClick>().PPGained;
        }
        else if (state == States.P4Turn)
        {
            node.GetComponent<NodeClick>().spriteRenderer.sprite = p4;
            p4PP += node.GetComponent<NodeClick>().PPGained;
        }
        if (state == States.P1Turn)
            state = States.P2Turn;
        else if (state == States.P2Turn)
            state = States.P3Turn;
        else if (state == States.P3Turn)
            state = States.P4Turn;
        else if (state == States.P4Turn)
            state = States.P1Turn;

    }

    IEnumerator WaitTimeFail(GameObject node)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Hack Failed!");
        node.GetComponent<NodeClick>().buttonPressed = false;
        if (state == States.P1Turn)
            state = States.P2Turn;
        else if (state == States.P2Turn)
            state = States.P3Turn;
        else if (state == States.P3Turn)
            state = States.P4Turn;
        else if (state == States.P4Turn)
            state = States.P1Turn;

    }

}
