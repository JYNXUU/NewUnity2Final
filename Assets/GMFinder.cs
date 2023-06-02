using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMFinder : MonoBehaviour
{
    public GameManager gm;
    public GameObject coinHUD;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        coinHUD = GameObject.Find("Pickup HUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
