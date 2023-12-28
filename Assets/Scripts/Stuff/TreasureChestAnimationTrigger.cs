using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestAnimationTrigger : MonoBehaviour
{
    public GameObject player;
    public Animator anim { get; private set; }
    private bool openAllowed;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && openAllowed)
        {
            anim.SetBool("OpenAllowed", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openAllowed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openAllowed = false;
        }
    }
}
