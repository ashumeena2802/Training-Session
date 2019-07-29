using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float smooth = 0.1f;

    [SerializeField] private float height ;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {

        // Position of camera relative to player
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.y = player.position.y + height;
        pos.z = player.position.z - 7f;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);        
        
    }




}
