using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    GameManager gameManager;
    [SerializeField] public float minSize = 1f;
    [SerializeField] public float maxSize = 3f;
    [SerializeField] public float moveSpeed = 0f;
    
    [SerializeField] public float growValue = 1f;
    [SerializeField] public float meltBy = 1f;
    public GameObject candlePartPrefab;
    [SerializeField] GameObject meltPrefab;
    public float distance = 1f;
    public bool willDie = false;
    Vector3 partSpawnOffset = new Vector3(0f, -5.5f, 1f);
    Vector3 deathMeltSpawnOffset = new Vector3(0f, -0.5f, 0f);
    [SerializeField] [Range(0,10)] public float cutValue = 2f;

    GameObject playerOffsetX;
    Vector3 currentOffset,mouseOffset;
    public Vector2 minMaxPlayerPosX;
    public bool isCreated = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetOffset();
    }

    void Update()
    {
        Move();
        Melt();
    }

    #region Movement
    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerOffsetX.transform.position = new Vector3(OffsetOfX(), this.transform.position.y, this.transform.position.z);
            mouseOffset = this.transform.position - playerOffsetX.transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            playerOffsetX.transform.position = new Vector3(OffsetOfX(), this.transform.position.y, this.transform.position.z);
            mouseOffset.y = mouseOffset.z = 0;
            currentOffset = playerOffsetX.transform.position + mouseOffset;
            currentOffset.x = Mathf.Clamp(currentOffset.x, minMaxPlayerPosX.x, minMaxPlayerPosX.y);
            this.transform.position = currentOffset;
        }

        this.transform.position += this.transform.forward * Time.deltaTime * moveSpeed;
    }

    private void SetOffset()
    {
        playerOffsetX = new GameObject();
        playerOffsetX.name = "OffsetGameObject";
        playerOffsetX.transform.position = this.transform.position;
    }

    public float OffsetOfX()
    {
        float mousePos = (Input.mousePosition.x * (minMaxPlayerPosX.y - minMaxPlayerPosX.x)) / Screen.width;
        mousePos -= (minMaxPlayerPosX.y - minMaxPlayerPosX.x) / 2;

        return mousePos;
    }
    #endregion

    // adds length upon pickups
    public void AddLength()
    {
        if (this.transform.localScale.y < maxSize)
        {
            this.transform.localScale += Vector3.up * growValue;
        }
    }

    //  decreases player length when it got hit by certain obstacles
    public void CutLength()
    {
        if(this.transform.localScale.y > cutValue)
        {
           this.transform.localScale -= Vector3.up * cutValue; 
        }
        else if (this.transform.localScale.y <= cutValue)
        {
            willDie = true;
            gameManager.PlayFailSound();
            MeltToDeath();
            gameObject.SetActive(false);
            Invoke("CallFail", 0.8f);

        }

    }

    // melt function
    private void Melt()
    {
        if (this.transform.localScale.y > minSize)
        {
            this.transform.localScale += Vector3.down * Time.deltaTime * meltBy;
        }
    }

    public void MeltToDeath() // kills the player if too small
    {
        if (!isCreated)
        {
            Instantiate(meltPrefab, transform.position - deathMeltSpawnOffset * distance, Quaternion.identity);
            isCreated=true;
            gameManager.PlayFailSound();
        }
        
    }

    // gets score to print later on
    public float GetScore()
    {
        return this.transform.localScale.y;
    }

    public void SpawnCandlePart() // spawning a candle object once player gets cut by strings
    {
        Instantiate(candlePartPrefab, transform.position - partSpawnOffset * distance, Quaternion.identity); 
    }
    public void CallFail() // turned to a method to use invoke
    {
        gameManager.OnLevelFailed();
    }
}
