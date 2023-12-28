using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    public float invincibleCounter;

    private SpriteRenderer theSR;

    //public GameObject DeathEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            //invicibleCounter -- can't do like this bacause in 1 sec game will run 60 frame;
            // Time.deltaTime = 1/60 because game is 60 frame in 1 secount make invisible in a time
            invincibleCounter -= Time.deltaTime;

            //this make when visible become invisible when the timeout
            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }

        }
    }

    public void DealDamage()
    {
        //this is make a moment invisible
        if (invincibleCounter <= 0)
        {
            //currentHealth = currentHealth - 1;
            //currentHealth -= 1;
            currentHealth--;
            //-- = -1 or ++ = +1

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //make player disappear
                //gameObject.SetActive(false);

                //Instantiate(DeathEffect, transform.position, transform.rotation);

                //this gonna make player respawn in LevelManger
                // LevelManger.instance.RespawnPlayer();

            }
            else
            {
                //player alive

                invincibleCounter = invincibleLength;
                //need to set the color between 0 and 1 == .5f : f is mean float.. Unity is know the lenght between 0 and 1
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                // PlayerController.instance.KnockBack();
                //AudioManager.instance.PlaySFX(9);
            }

            //UIController.Instance.UpdateHealthDisplay();
        }

    }

    public void HealPlayer()
    {
        // Heal full health
        //currentHealth = maxHealth;

        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //UIController.Instance.UpdateHealthDisplay();

    }






}
