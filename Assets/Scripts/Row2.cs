using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row2 : MonoBehaviour
{

    [SerializeField]
    public SpriteRenderer spriteRenderer;
    public double stopTime;


    [SerializeField]
    private Sprite[] sprites = null;
    private double timeInterval;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        timeInterval = Time.realtimeSinceStartup;
        if(timeInterval < stopTime)
        spriteRenderer.sprite = sprites[Random.Range(0,6)];
    }
}
