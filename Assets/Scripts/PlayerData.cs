using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    string playerName;
    public TMP_Text playerLabel;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        playerName = manager.playerName;
        playerLabel.text = playerName;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
