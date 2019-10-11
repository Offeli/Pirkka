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
        lvlIndex = 0;
    }

    void FixedUpdate()
    {
    

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && isGrounded)
        {

            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

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

    private IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(5);
        lvlIndex++;
        //SceneManager.LoadScene(lvlIndex);
        if(lvlIndex == 1)
        {
            
            SceneManager.LoadScene(1);
            
        }

        if (lvlIndex == 2)
        {
            
            SceneManager.LoadScene(2);
            
        }

        if (lvlIndex == 3)
        {
            Application.Quit();
        }

    }
}
