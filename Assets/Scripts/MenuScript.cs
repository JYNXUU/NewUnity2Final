using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

        public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        SceneManager.LoadScene(7);
    }

    public void Win()
    {
        SceneManager.LoadScene(6);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }


}
