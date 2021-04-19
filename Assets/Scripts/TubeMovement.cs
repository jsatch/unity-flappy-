using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMovement : MonoBehaviour
{
    public float scrollSpeed;

    private Vector2 screenBounds;
    private float startX;
    private Vector2 tubeSize;
    private TubePositioning tubePositioning;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = GameObject.Find("GameManager").GetComponent<GameManager>().GetScreenBounds();
        tubePositioning = GetComponent<TubePositioning>();
        tubeSize = tubePositioning.GetTubeSize();
        startX = transform.position.x;
        Debug.Log($"SCREEN_BOUNDS_X: {screenBounds.x}");
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            if (transform.position.x < -screenBounds.x - (tubeSize.x /2f)  )
            {
                // Salio de la camara (reposicionar)
                //Espacio entre tuberias 1.73
                tubePositioning.Reposition(4.18f);
            }
        }
    }

    public void Stop()
    {
        stop = true;
    }
}
