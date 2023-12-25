using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Fix when damage when player start the game 
        if (other.CompareTag("Player"))
        {

            //this make console popup when player get hit
            Debug.Log("Hit"); 

            
            //This is way to find function in other scrip for this example want to get fn dealDamage in PlayerHealthController
            //FindObjectOfType<PlayerHealthController>().DealDamage();

            //
            PlayerHealthController.instance.DealDamage();

        }



    }

}
