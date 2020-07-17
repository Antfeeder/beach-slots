using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GreenControl : MonoBehaviour
{

    public static event Action ButtonPushed = delegate { };

    [SerializeField]
    private Text prizeText = null;


    [SerializeField]
    private GreenRow[] rows = null;

    //[SerializeField]
    //private Transform handle = null;

    private int prizeValue;
    

    private bool resultsChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped){ //SPIKE: Not Scalable
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;

        }
        if (rows[0].rowStopped && rows[1].rowStopped &&  rows[2].rowStopped && !resultsChecked){ //SPIKE: Not Scalable
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
            Debug.Log("Test");
        }
       
    }
    
    public void Spin(){

        Debug.Log("Test");
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped){
            StartCoroutine("PushButton");
            
        }
    }


    private IEnumerator PushButton(){
        /*for (int i = 0; i < 15;i+=5){
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }*/
        ButtonPushed();
        /*for (int i = 0; i < 15; i +=5){
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }*/
        yield return new WaitForSeconds(0.1f);
    }

    private void CheckResults(){
        if(string.Equals(rows[0].stoppedSlot, rows[1].stoppedSlot) && string.Equals(rows[0].stoppedSlot, rows[2].stoppedSlot) ){
            switch (rows[0].stoppedSlot){
                case "Diamond":
                    prizeValue = 200;
                    break;
                case "Lemon":
                    prizeValue = 5000;
                    break;
                case "Cherry":
                    prizeValue = 3000;
                    break;
                case "Seven":
                    prizeValue = 1500;
                    break;
                case "Bar":
                    prizeValue = 800;
                    break;
                case "Watermellon":
                    prizeValue = 600;
                    break;
                case "Crown":  
                    prizeValue = 400;
                    break;
            }
        }
        /*else if(string.Equals(rows[0].stoppedSlot, rows[1].stoppedSlot)){
            switch (rows[0].stoppedSlot){
                case "Diamond":
                    prizeValue = 100;
                    break;
                case "Lemon":
                    prizeValue = 4000;
                    break;
                case "Cherry":
                    prizeValue = 2000;
                    break;
                case "Seven":
                    prizeValue = 1000;
                    break;
                case "Bar":
                    prizeValue = 700;
                    break;
                case "Watermellon":
                    prizeValue = 500;
                    break;
                case "Crown":  
                    prizeValue = 300;
                    break;
            }
        }*/
        prizeText.text = "Prize: " + prizeValue;
        resultsChecked = true;
    }

}
