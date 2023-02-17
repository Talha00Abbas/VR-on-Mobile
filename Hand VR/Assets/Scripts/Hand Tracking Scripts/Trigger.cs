using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject sphere;
    public Player player;

    public bool tr = false;
    public bool tl = false;
    public bool jp = false;

    private void Start()
    {
        sphere.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sphere.SetActive(true);
            if (tr == true)
            {
                player.turnRight = true;
            }

            if (tl == true)
            {
                player.turnLeft = true;
            }

            if (jp == true)
            {
                player.turnLeft = false;
                player.turnRight = false;
                player.rb.AddForce(Vector3.up * player.jumpForce);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sphere.SetActive(false);
        }

        if (tr == true)
        {
            player.turnRight = false;
        }

        if (tl == true)
        {
            player.turnLeft = false;
        }

        if (jp == true)
        {
            player.turnLeft = false;
            player.turnRight = false;
            
        }
    }
}
