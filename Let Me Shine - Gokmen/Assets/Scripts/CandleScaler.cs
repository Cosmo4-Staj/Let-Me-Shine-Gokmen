using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScaler : MonoBehaviour
{
    [SerializeField] public float minSize = 1f;
    [SerializeField] public float maxSize = 3f;
    [SerializeField] public float meltTime = 10f;
    [SerializeField] public float timer = 0f;

    public bool isMinSize = false;
    public bool isMaxSize = false;
    public float addCandle = 0.05f;

    GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(isMinSize == false)
        StartCoroutine(MeltOvertime());
    }

    public void AddLength()
    {
        gameObject.transform.localScale += new Vector3(0, addCandle, 0);
    }

    IEnumerator MeltOvertime()
    {        
        Vector3 startScale = transform.localScale;
        Vector3 maxScale = new Vector3(transform.localScale.x, maxSize, transform.localScale.z);
        Vector3 minScale = new Vector3(transform.localScale.x, minSize, transform.localScale.z);

        do
        {
        transform.localScale = Vector3.Lerp(startScale, minScale, timer / meltTime);
        timer += Time.deltaTime;
        yield return null;
        } 
        while (timer < meltTime);
        
        isMinSize = true;
    }
}
