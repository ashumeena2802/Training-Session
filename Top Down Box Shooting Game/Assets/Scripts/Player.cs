using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject bulletSpawnPoint;

    [SerializeField] private GameObject playerobj;

    [SerializeField] private GameObject bullet;

    private Transform bulletSpawned;

    public float waitTime;

    void Start()
    {
        
    }
    
    void Update()
    {

        // For Player face the mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray,out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerobj.transform.rotation = Quaternion.Slerp(playerobj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        // For moving the box
        if (Input.GetKey(KeyCode.W))        
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
        {
            // For shooting method
            Shoot();
        }
        
    }

    void Shoot()
    {
        // Shooting the bullets

        bulletSpawned =  Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }
}
