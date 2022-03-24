using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public float speed = 5f, checkpoz = 0f;
    private RectTransform rec;
    public GameObject mainCube;
    void Start()
    {
        rec = GetComponent<RectTransform>();
        mainCube.GetComponent<AudioSource>().enabled = false;
        mainCube.GetComponent<AudioSource>().enabled = true;
    }
    void Update()
    {
        if(rec.offsetMin.y < checkpoz)
        {
            rec.offsetMin += new Vector2(-rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(-rec.offsetMax.x, speed);
        }
    }

    
}
