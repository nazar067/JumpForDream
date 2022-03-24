using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject shopBG, shopDiamonds, mainCube, recordBG;
    public Sprite mus_on, mus_off;
    public float bigger = 1f, lower = 0.79f;
    public AudioSource music;
    void Start()
    {
        if (gameObject.name == "Settings")
        {
            if (PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = mus_off;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
        }
    }
    void OnMouseDown()
    {
        transform.localScale = new Vector3(bigger, bigger, bigger);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(lower, lower, lower);
    }
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":
                Cubejump.nextBlock = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "About":
                Application.OpenURL("https://www.instagram.com/nazar067/");
                break;
            case "Settings":
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;
            case "Google+":
                Application.OpenURL("https://google.com/");
                break;
            case "Sound":
                if (mainCube.GetComponent<AudioSource>().mute == true)
                {
                    GetComponent<Image>().sprite = mus_on;
                    mainCube.GetComponent<AudioSource>().mute = false;
                }
                else
                {
                    GetComponent<Image>().sprite = mus_off;
                    mainCube.GetComponent<AudioSource>().mute = true;
                }
                break;
            case "Shop":
                shopBG.SetActive(!shopBG.activeSelf);
                break;
            case "Close":
                shopBG.SetActive(false);
                Cubejump.nextBlock = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Diamonds":
                shopDiamonds.SetActive(!shopDiamonds.activeSelf);
                break;
            case "Ads":
                shopBG.SetActive(false);
                Cubejump.nextBlock = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Score":
                //recordBG.SetActive(true);
                break;
        }
    }
}
