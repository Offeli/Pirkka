using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public LevelController lvlController;
    public static int lvlIndex;

    public Vector3 jump;
    //public float jumpForce = 2.0f;
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
<<<<<<< HEAD


=======
        lvlIndex = 0;
>>>>>>> c8807221bc71a708875bc440f99f6cd09e9f9fbd
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && isGrounded)
        {

            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
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
            winText.text = "You made it!";
            // Waits for 3 seconds before executing the scene change
            StartCoroutine(WaitForIt());
            
            
        }
    }

<<<<<<< HEAD
    void Awake()
    { 
        //source = GetComponent<AudioSource>(); //??
=======
    private IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(5);
        lvlIndex++;
        SceneManager.LoadScene(lvlIndex);
>>>>>>> c8807221bc71a708875bc440f99f6cd09e9f9fbd
    }
}
