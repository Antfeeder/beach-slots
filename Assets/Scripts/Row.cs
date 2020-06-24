using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public int rowPosition;
    public bool rowStopped;
    public string stoppedSlot;

    public IDictionary<double, string> slotValues = new Dictionary<double, string>()
                                                    {
                                                        {1.75, "Diamond"},
                                                        {1, "Lemon"},
                                                        {0.25, "Cherry"},
                                                        {-0.5, "Seven"},
                                                        {-1.25, "Bar"},
                                                        {-2, "Watermellon"},
                                                        {-2.75, "Crown"},
                                                        {-3.5,"Diamond"}
                                                    };
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }


    private void StartRotating(){
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;
        for (int i = 0; i < 30+(rowPosition*10); i++){
            if (transform.position.y <= -15f)
                transform.position = new Vector2(transform.position.x, 15f);

            transform.position = new Vector3(transform.position.x, transform.position.y - 1.00f);
            yield return new WaitForSeconds(timeInterval);
        }
        transform.position = new Vector3(transform.position.x, randomSlot(3.0f, 15f, -15f));
        /*randomValue = Random.Range(60, 100);

        switch (randomValue % 12)
        {
            case 1:
                randomValue += 11;
                break;
            case 2:
                randomValue += 10;
                break;
            case 3:
                randomValue += 9;
                break;
            case 4:
                randomValue += 8;
                break;
            case 5:
                randomValue += 7;
                break;
            case 6:
                randomValue += 6;
                break;
            case 7:
                randomValue += 5;
                break;
            case 8:
                randomValue += 4;
                break;
            case 9:
                randomValue += 3;
                break;
            case 10:
                randomValue += 2;
                break;
            case 11:
                randomValue += 1;
                break;
        }
        for (int i = 0; i < randomValue; i++){
            if (transform.position.y <= -15)
                transform.position = new Vector2(transform.position.x, 15f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue *0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue *0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue *0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue *0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }*/
            stoppedSlot =  "Diamond"; //slotValues[transform.position.y];
            rowStopped = true;
    }

    private void slotValue(float y){

    }


    private float randomSlot(float slotSize, float startRange, float endRange){
        int i = Random.Range(0, 10);
        int[] j = new int[] {-15, -12, -9, -6, -3, 0, 3, 6, 9, 12, 15};
        return (float)j[i];
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
