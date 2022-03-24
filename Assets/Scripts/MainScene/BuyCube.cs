using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public GameObject whichCube, selectBtn, mainCube;
    void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Diamonds") >= 2000)
        {
            PlayerPrefs.SetString(whichCube.GetComponent<SelectCube>().nowCube, "Open");
            PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - 2000);
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube)
                .GetComponent<MeshRenderer>().material;
            mainCube.GetComponent<AudioSource>().clip = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube)
                .GetComponent<AudioSource>().clip;
            selectBtn.SetActive(true);
            gameObject.SetActive(false);
            mainCube.GetComponent<AudioSource>().enabled = false;
            mainCube.GetComponent<AudioSource>().enabled = true;
        }
    }
}