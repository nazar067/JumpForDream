using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    Score score;
    public List<Text> record = new List<Text>();
    private void Start()
    {
        record.Add(score.txt);
    }
}
