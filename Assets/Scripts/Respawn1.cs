using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn1 : MonoBehaviour
{

    public GameObject player;
    public GameObject respawnPoint;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))//if player is touching this obj
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }







    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
