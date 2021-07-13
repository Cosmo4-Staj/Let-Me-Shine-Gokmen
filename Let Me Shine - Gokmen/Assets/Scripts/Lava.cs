using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float scrollX = 1f;
    public float scrollY = 1f;
    Renderer renderer;

    // makes the lava puddles scroll to have a realistic look
    void Update()
    {
        float OffsetX = Time.time * scrollX;
        float OffsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

    }
}
