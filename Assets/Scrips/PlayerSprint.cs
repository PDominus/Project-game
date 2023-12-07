using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    // public GameObject staminarbar;

    // Start is called before the first frame update

    private void Awake()
    {
        stamina = totalStamina;
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            PlayerController.instance.isRunning = true;
            stamina -= 0.05f;
        }
        else
        {
            PlayerController.instance.isRunning = false;
        }

        if (stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.225f;
        }

    }
}
