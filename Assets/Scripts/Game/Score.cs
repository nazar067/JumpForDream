using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text record;
    public Text txt;
    private bool gameStart;
    void Start()
    {
        record.text = "TOP: " + PlayerPrefs.GetInt("Record").ToString();
        txt = GetComponent<Text>();
        Cubejump.count_blocks = 0;
    }

    
    void Update()
    {
        if (txt.text == "0")
        {
            gameStart = true;
        }
        if (gameStart)
        {
            txt.text = Cubejump.count_blocks.ToString();
            if (PlayerPrefs.GetInt("Record") < Cubejump.count_blocks)
            {
                PlayerPrefs.SetInt("Record", Cubejump.count_blocks);
                record.text = "TOP: " + PlayerPrefs.GetInt("Record").ToString();
            }
        }
    }
}
