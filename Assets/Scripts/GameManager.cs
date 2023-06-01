using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public string playerName;
    public int coins;
    public int key;
    public TMP_InputField playerNameInput;
    public TMP_Text coinHud;

    public AudioSource pickupaudio;

    //public GameObject ExitText1;
    //public GameObject ExitText2;


    // Start is called before the first frame update
    void Start()
    {
       // ExitText1.SetActive(false);
       // ExitText2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendNameData()
    {
        Debug.Log(playerNameInput.text);
        playerName = playerNameInput.text;
    }

    public void CoinCollected()
    {
        coins++;
        coinHud.text = "Coins: " + coins.ToString();
        pickupaudio.Play();
        //if(coins > 4)
        //{
           // Destroy(GameObject.Find("ExitDoor"));
           // ExitText1.SetActive(true);
           //S ExitText2.SetActive(true);
        //}
    }

    public void KeyCollected()
    {
        key++;
        if(key == 1)
        {
            Destroy(GameObject.Find("ExitDoor"));
        }
    }
}
