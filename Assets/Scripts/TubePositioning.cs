using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubePositioning : MonoBehaviour
{
    public float gap;

    private Vector2 tubeSize;
    private Transform upperTube;
    private Transform lowerTube;
    private Vector2 screenBounds;

    private void Awake()
    {
        upperTube = transform.Find("TubeUp");
        lowerTube = transform.Find("TubeDown");

        tubeSize = upperTube.GetComponent<SpriteRenderer>().bounds.size;
    }

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Debug.Log($"Screen Size: {screenBounds.x} , {screenBounds.y}");
        //Debug.Log($"Tube Height: {tubeSize.y}");

        Reposition(transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public Vector2 GetTubeSize()
    {
        return tubeSize;
    }

    public void Reposition(float x)
    {
        float minUpperPosition = screenBounds.y - (tubeSize.y / 2f);
        float maxUpperPosition = -screenBounds.y + tubeSize.y + gap + (tubeSize.y / 2f);

        float upperPosition = Random.Range(minUpperPosition, maxUpperPosition);


        //Debug.Log($"Max pos: {maxUpperPosition}");
        //Debug.Log($"MMin pos: {minUpperPosition}");
        // Acordarse que en position esta la posicion global
        transform.position = new Vector3(x, 0f, 0f); // no olvidarse de setear la posicion del padre
        upperTube.transform.position = new Vector3(x, upperPosition, 0f);
        lowerTube.transform.position = new Vector3(x, upperPosition - gap - tubeSize.y, 0f);
    }
}
