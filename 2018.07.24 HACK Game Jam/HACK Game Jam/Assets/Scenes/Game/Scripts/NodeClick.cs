using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClick : MonoBehaviour {



    public Sprite pushed;
    public Sprite notPushed;

    private SpriteRenderer spriteRenderer;

    public int successRate = 50;

    private int minSuccessRate = 0;
    private int maxSuccessRate = 100;

    private bool buttonPressed = false;

    public List<GameObject> connectedNodes;



    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (buttonPressed == false)
        {
            for (int i = 0; i < connectedNodes.Count; i++)
            {
                if (connectedNodes[i].gameObject.tag == "Player1")
                {
                    Debug.Log("Valid Node");
                    HackAttempt();
                    break;
                }
  
            }
            Debug.Log("Invalid Node");
        }
        else if (buttonPressed == true)
        {
            Debug.Log("Node Already Captured!");
        }

    }

    private void HackAttempt()
    {
        buttonPressed = true;
        Debug.Log("Hack Initiated!");
        if (Random.Range(minSuccessRate, maxSuccessRate) >= successRate)
        {
            StartCoroutine(WaitTimeSuccess());
        }
        else
        {
            StartCoroutine(WaitTimeFail());

        }
    }

    IEnumerator WaitTimeSuccess()
    {
        yield return new WaitForSeconds(1);
        this.tag = "Player1";
        Debug.Log("Hack Successful!");
        spriteRenderer.sprite = pushed;
       
    }

    IEnumerator WaitTimeFail()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Hack Failed!");
        buttonPressed = false;

        
    }
}
