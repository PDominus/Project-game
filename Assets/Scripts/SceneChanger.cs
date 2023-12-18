using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string ToWhatScene;
    [SerializeField] private GameObject uiElement;
    private bool enterAllowed;

    public GameObject player;
    public float newXposition;
    public float newYposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enterAllowed && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(ToWhatScene);
            //player.transform.position = new Vector3(newXposition, newYposition, 0);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Crash!");
            SceneManager.LoadScene(ToWhatScene);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player")){
            Debug.Log("Crash!");
            uiElement.SetActive(true);
            enterAllowed = true;
        }
    }

    /*private void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(ToWhatScene);
        }
    }*/

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            uiElement.SetActive(false);
            enterAllowed = false;
        }
    }
}
