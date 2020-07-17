using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRow : MonoBehaviour
{

    [SerializeField]
    public SpriteRenderer spriteRenderer;
    public double stopTime;

    public int rowPosition;
    public bool rowStopped;
    public string stoppedSlot;


    [SerializeField]
    private Sprite[] sprites = null;
    private float timeInterval;

    void Start()
    {
        rowStopped = true;
        spriteRenderer.sprite = sprites[0];
        GreenControl.ButtonPushed += StartRotating;
    }
    private void StartRotating(){
        StartCoroutine("Rotate");
    }
    
    private IEnumerator Rotate()
    {
        Debug.Log("Test");
        rowStopped = false;
        timeInterval = 0.025f;
        for (int i = 0; i < 52; i++){
            if (transform.position.y <= -3.25f){
                spriteRenderer.sprite = sprites[Random.Range(0,6)];
                transform.position = new Vector2(transform.position.x, 3.25f);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f);
            yield return new WaitForSeconds(timeInterval);
        }
        rowStopped = true;
    
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {   
        //timeInterval = Time.realtimeSinceStartup;
        //if(timeInterval < stopTime)
        //spriteRenderer.sprite = sprites[Random.Range(0,6)];
    }

    private void OnDestroy()
    {
        GreenControl.ButtonPushed -= StartRotating;
    }
    
}