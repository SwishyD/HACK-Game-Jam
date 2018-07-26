using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeClick : MonoBehaviour {



    public SpriteRenderer spriteRenderer;

    private bool printError;

    public bool buttonPressed;

    public List<GameObject> connectedNodes;

    private string currentPlayer;

    public int successRate;

    public int PPGained;

    public Text ppGainText;
    public Text successRateText;



    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        buttonPressed = false;
}
	
	// Update is called once per frame
	void Update () {
        currentPlayer = GameManager.instance.currentPlayer;
	}

    private void OnMouseDown()
    {
        printError = true;
        if (buttonPressed == false)
        {
            for (int i = 0; i < connectedNodes.Count; i++)
            {
                if (connectedNodes[i].gameObject.tag == currentPlayer)
                {
                    Debug.Log("Valid Node");
                    GameManager.instance.HackAttempt(gameObject);
                    printError = false;
                    break;
                }
  
            }
            if(printError == true)
            Debug.Log("Invalid Node");
        }
        else if (buttonPressed == true)
        {
            Debug.Log("Node Already Captured!");
        }

    }

    private void OnMouseOver()
    {
        ppGainText.text = PPGained.ToString();
        successRateText.text = "Success Chance " + successRate.ToString() + "%";
    }



}
