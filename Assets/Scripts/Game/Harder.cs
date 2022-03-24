using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    public GameObject detectClicks;
    private bool hard;
    void Update()
    {
        if(Cubejump.count_blocks > 0)
        {
            if (Cubejump.count_blocks %  4 == 0 && !hard)
            {
                print("harder");
                Camera.main.GetComponent<Animation>().Play("Harder");
                detectClicks.transform.position = new Vector3(6.93f, 6.234616f, -4.49103f);
                detectClicks.transform.eulerAngles = new Vector3(30.116f, -67.27f, 0f);
                hard = true;
            }
            else if ((Cubejump.count_blocks % 4) - 1 == 0 && hard)
            {
                hard = false;
                detectClicks.transform.position = new Vector3(0f, 1.27f, -8.54f);
                detectClicks.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Camera.main.GetComponent<Animation>().Play("Easier");
                print("easier");
            }
        }
    }
}
