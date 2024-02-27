using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasebehaivour : MonoBehaviour
{
    public Transform player;
    public GameObject chaseBullet;
    public float chaseHP;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //Check if player exists 
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}