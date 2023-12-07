using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public GameObject Chest;
    public GameObject ChestOpen;
    public bool openAble = false;
    public int num = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        Chest.SetActive(true);
        ChestOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (openAble)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //opening();
                //Chest.SetActive(false);
                Destroy(Chest);
                ChestOpen.SetActive(true);
                
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        openAble = true;
        if (collision.CompareTag("Player")) {
            if(num == 0){
                //openAble = true;
                ChestOpen.SetActive(true);
                num += 1;
            }
            else{
            }
            
        }
       
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            openAble = false;
        }
    }

    private void opening()
    {
        Chest.SetActive(false);
        ChestOpen.SetActive(true);
    }


}
