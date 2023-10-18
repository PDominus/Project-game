using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public GameObject Chest;
    public GameObject ChestOpen;



    // Start is called before the first frame update
    void Start()
    {
        Chest.SetActive(true);
        ChestOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Chest.SetActive(false);
        ChestOpen.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Chest.SetActive(true); 
        ChestOpen.SetActive(false);
    }

}
