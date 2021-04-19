using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    public float scrollSpeed = -1f;


    private Vector3 startPosition;
    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            float newPos = Mathf.Repeat(scrollSpeed * Time.time, 5.53f);
            transform.position = startPosition + Vector3.right * newPos;
        }
    }

    public void Stop()
    {
        stop = true;
    }
}
