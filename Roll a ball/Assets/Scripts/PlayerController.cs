using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Text CountText;
    [SerializeField] private Text WinText;

    [HideInInspector] public int count;


    private Rigidbody rb;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        WinText.text = "";
    }

    private void Update()
    {
        CountText.text = "Score :" + count ;

        if(count >= 12)
        {
            WinText.text = "You Win !!!!";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(Movement * speed);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            count++;
            Destroy(other.gameObject);
        }
    }


}
