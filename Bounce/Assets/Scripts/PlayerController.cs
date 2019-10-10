using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public LevelController lvlController;

    public Vector3 jump;
   // public float jumpForce = 2.0f;
    public bool isGrounded;

    private Rigidbody rb;
    private int count;

    public AudioSource source; // ???

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;
        SetCountText();
        winText.text = "";


    }

    void FixedUpdate()
    {
        AudioScript page = new AudioScript(); // ???
        page.Play2();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;

            //AudioScript page2 = new AudioScript(); // ???
            //page2.Play2();
        }
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //FirstPage page2 = new FirstPage();
        //page2.Yell();

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString() + "/10" ;
        if(count == 10)
        {
            winText.text = "You collected all the coins!";
            // Waits for 3 seconds before executing the scene change
            System.Threading.Thread.Sleep(3000);
            lvlController.TenCollected();
        }
    }

    void Awake()
    { 
        //source = GetComponent<AudioSource>(); //??
    }
}
