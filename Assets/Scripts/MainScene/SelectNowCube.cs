using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNowCube : MonoBehaviour
{
    public GameObject whichCube, mainCube;

    void OnMouseDown()
    {
        if (mainCube != null)
        {
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube)
            .GetComponent<MeshRenderer>().material;
            mainCube.GetComponent<AudioSource>().clip = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube)
                .GetComponent<AudioSource>().clip;
        }
        PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
        mainCube.GetComponent<AudioSource>().enabled = false;
        mainCube.GetComponent<AudioSource>().enabled = true;
    }
}
