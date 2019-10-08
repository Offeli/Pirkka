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

    public AudioClip crashSoft;
    public AudioClip crashHard;

    public AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;
        SetCountText();
        winText.text = "";

        source.Play();  // REMOVE!
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


        {
            //source.pitch = Random.Range(lowPitchRange, highPitchRange);
            //float hitVol = coll.relativeVelocity.magnitude * velToVol;
            //if (coll.relativeVelocity.magnitude < velocityClipSplit)

            //float hitVol = 1;
         source.Play();

            //500_hz_sinus_tone
            //else
            // source.PlayOneShot(crashHard, hitVol);
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

        source = GetComponent<AudioSource>();
    }
}
