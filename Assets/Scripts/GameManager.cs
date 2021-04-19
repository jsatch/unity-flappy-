using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetScreenBounds()
    {
        return screenBounds;
    }
}
