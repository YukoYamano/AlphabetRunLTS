using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private AudioSource restartSound;
    public AudioClip restartS;

    // Start is called before the first frame update
    void Start()
    {
       restartSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void PlaySound()
    {
        restartSound.PlayOneShot(restartS, 1.0f);
    }
}
