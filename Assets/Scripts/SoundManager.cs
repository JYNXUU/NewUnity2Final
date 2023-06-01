using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    public static SoundManager instance;
    public AudioSource audioPlayer;
    public AudioClip clip;



    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.PlayOneShot(clip);

        ConsoleMsg<string>("Annie is epic");
        ConsoleMsg<int>(9000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ConsoleMsg<T>(T value)
    {
        Debug.Log("The Message is: " + value.ToString());
    }

}
