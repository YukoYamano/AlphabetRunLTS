using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseLifeScript : MonoBehaviour
{
   // public Transform spawnPoint;
    public Text loseText;
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       // loseText = GameObject.Find("loseText").GetComponent<Text>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // other.gameObject.transform.position = spawnPoint.position;
            //Lose condition
            //Time.timeScale = 0.0f;
            loseText.gameObject.SetActive(true);
            anim.SetBool("isDead", true);
            player.GetComponent<PlayerController>().isLose = true;
            StartCoroutine("Restart");
          
        }
    }

    IEnumerator Restart()
    {
        
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Level1");
    }
   
}
