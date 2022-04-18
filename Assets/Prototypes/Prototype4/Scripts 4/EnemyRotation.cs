using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRotation : MonoBehaviour
{
    private GameObject player;
    public Image image;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.right = player.transform.position - transform.position;
    }
}
