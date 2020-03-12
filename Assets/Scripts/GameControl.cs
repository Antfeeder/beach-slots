using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text prizeText;


    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;

    private int prizeValue;
    

    private bool resultsChecked = false;

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped){
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;

        }
        if (rows[0].rowStopped && rows[1].rowStopped &&  rows[2].rowStopped &&  rows[3].rowStopped && !resultsChecked){
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
            StartCoroutine("PullHandle");
        }
     
    }
    private void OnMouseDown(){

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped){
            StartCoroutine("PullHandle");
            
        }
    }

    private IEnumerator PullHandle(){
        for (int i = 0; i < 15;i+=5){
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }
        HandlePulled();
        for (int i = 0; i < 15; i +=5){
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
           
    }

    private void CheckResults(){
        if(string.Equals(rows[0].stoppedSlot, rows[1].stoppedSlot) && string.Equals(rows[0].stoppedSlot, rows[2].stoppedSlot) &&string.Equals(rows[0].stoppedSlot, rows[3].stoppedSlot) ){
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
    
    // Start is called before the first frame update
    void Start()
    {

    }


}
