using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMat : MonoBehaviour
{
    public GameObject[] cubes;
    void Start()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (PlayerPrefs.GetString("Now Cube") == cubes[i].name)
            {
                GetComponent<MeshRenderer>().material = cubes[i].GetComponent<MeshRenderer>().material;
                GetComponent<AudioSource>().clip = cubes[i].GetComponent<AudioSource>().clip;
                break;
            }
        }
    }
}
