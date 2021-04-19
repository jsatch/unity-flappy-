using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    public TubeMovement tubeMovement1;
    public TubeMovement tubeMovement2;
    public TubeMovement tubeMovement3;
    public TubeMovement tubeMovement4;
    public  ScrollMovement scrollMovement;
    public Text counterText;
    public Transform gameoverMesage;

    public float jumpSpeed;

    private Animator birdAnimator;
    private Rigidbody2D rigidBody;

    private int cont;
    
    // Start is called before the first frame update
    void Start()
    {
        birdAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector3.up * jumpSpeed;
        }
        //if (Input.GetKeyDown(KeyCode.Space))

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            cont++;
            counterText.text = cont.ToString();
        }
        else
        {
            birdAnimator.SetBool("hasCrashed", true);
            tubeMovement1.Stop();
            tubeMovement2.Stop();
            tubeMovement3.Stop();
            tubeMovement4.Stop();
            scrollMovement.Stop();
            rigidBody.gravityScale = 0;
            rigidBody.velocity = Vector3.zero;
            gameoverMesage.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
