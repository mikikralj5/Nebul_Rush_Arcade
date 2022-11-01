using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private  Rigidbody playerRb;
    public float speed = 70f;
    private float speedToSide = 100f;
    public Text score;
    private float rotationAngle = 360;
    //private float upForce = 1000f;
    public float gravityModifier=2;
    private float groundEdge = 12.5f;

    public GameObject blastEffect;


    //Inventory 
    public GameObject[] slots;
    public bool[] isFull;


    //slomo
    private float oldSpeed;
   
    

    void Start()
    {
       playerRb = GetComponent<Rigidbody>();

       // Physics.gravity = Physics.gravity * gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {

        BaseMechanics();
        InventoryFuncionality();


    }

    public void InventoryFuncionality()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
                      
              foreach(Transform child in slots[0].transform)
              {
                if(child.CompareTag("SpeedupPickup"))
                {
                    child.GetComponent<SpeedupPickup>().SpeedUpFunc();
                    GameObject.Destroy(child.gameObject);
                    FindObjectOfType<SoundEffectManager>().PlaySound("SpeedUp");
                    isFull[0] = false;
                }
                else if (child.CompareTag("CatapultPickup"))
                {
                    child.GetComponent<CatapulPickup>().CatapulFun();
                    GameObject.Destroy(child.gameObject);
                    FindObjectOfType<SoundEffectManager>().PlaySound("Catapult");
                    isFull[0] = false;
                }
                else if(child.CompareTag("BlastPickup"))
                {
                    blastEffect.SetActive(true);
                    child.GetComponent<BlastPickup>().BlastFunc();
                    FindObjectOfType<SoundEffectManager>().PlaySound("Supernova");
                    GameObject.Destroy(child.gameObject);
                    // blastEffect.SetActive(false);
                    StartCoroutine(BlastCountdown());
                    isFull[0] = false;
                }
                 
                
              }        
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {

            foreach (Transform child in slots[1].transform)
            {
                if (child.CompareTag("SpeedupPickup"))
                {
                    child.GetComponent<SpeedupPickup>().SpeedUpFunc();
                    GameObject.Destroy(child.gameObject);
                    FindObjectOfType<SoundEffectManager>().PlaySound("SpeedUp");
                    isFull[1] = false;
                }
                else if (child.CompareTag("CatapultPickup"))
                {
                    child.GetComponent<CatapulPickup>().CatapulFun();
                    GameObject.Destroy(child.gameObject);
                    FindObjectOfType<SoundEffectManager>().PlaySound("Catapult");
                    isFull[1] = false;
                }
                else if (child.CompareTag("BlastPickup"))
                {
                    blastEffect.SetActive(true);
                    child.GetComponent<BlastPickup>().BlastFunc();
                    FindObjectOfType<SoundEffectManager>().PlaySound("Supernova");
                    GameObject.Destroy(child.gameObject);
                    //blastEffect.SetActive(false);
                    StartCoroutine(BlastCountdown());
                    isFull[1] = false;
                }

            }
        }
    }

    IEnumerator BlastCountdown()
    {
        yield return new  WaitForSeconds(1.50f);
        blastEffect.SetActive(false);
    }

    public void BaseMechanics()
    {
        playerRb.AddForce(Vector3.forward * Time.deltaTime * speed, ForceMode.VelocityChange);
        //transform.position = Vector3.forward * Time.deltaTime *speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.right * Time.deltaTime * speedToSide, ForceMode.VelocityChange);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.left * Time.deltaTime * speedToSide, ForceMode.VelocityChange);
        }

        score.text = "Score : " + transform.position.z.ToString("0");

        if (transform.position.x < -groundEdge)
        {
            transform.position = new Vector3(-groundEdge, transform.position.y, transform.position.z);
        }

        if (transform.position.x > groundEdge)
        {
            transform.position = new Vector3(groundEdge, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * rotationAngle);
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {

            playerRb.AddForce(Vector3.up * Time.deltaTime * upForce, ForceMode.Impulse);


        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            this.enabled = false;
            FindObjectOfType<SoundEffectManager>().PlaySound("Death");           
            FindObjectOfType<GameManager>().EndGame();
        } 
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            FindObjectOfType<GameManager>().LevelComplete();
        }

        if (other.gameObject.CompareTag("slomo"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<SoundEffectManager>().PlaySound("Slow");
            oldSpeed = speed;
            speed /= 2;
            StartCoroutine(SlomoCountDown());
            //float newSpeed = 2f;
            //playerRb.AddForce(Vector3.forward * Time.deltaTime * newSpeed, ForceMode.VelocityChange);

        }

        if (other.gameObject.CompareTag("collisionFree"))
        {
            Destroy(other.gameObject);
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach(GameObject obestacle in obstacles)
            {
                 Physics.IgnoreCollision(obestacle.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(),   true);
            }
            StartCoroutine(CollisionFreeCountdown());




        }
    }

    IEnumerator SlomoCountDown()
    {
        yield return new WaitForSeconds(3);
        speed = oldSpeed;
    }

    IEnumerator CollisionFreeCountdown()
    {
        yield return new WaitForSeconds(1);
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obestacle in obstacles)
        {
            Physics.IgnoreCollision(obestacle.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(),false);
        }

    }

   
}
