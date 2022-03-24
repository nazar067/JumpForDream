using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    public GameObject[] cube;
    public GameObject buttons, m_cube, cubes, spawn_blocks, diamonds, background;
    public Light dirLight;
    public Text playTxt, gameName, record;
    public Animation block;
    private bool clicked;
    void Update()
    {
        if(clicked && dirLight.intensity != 0)
        {
            dirLight.intensity = 5f;
        }
    }
    void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true;
            playTxt.gameObject.SetActive(false);
            record.gameObject.SetActive(false);
            gameName.text = "0";
            buttons.gameObject.SetActive(false);
            diamonds.SetActive(true);
            m_cube.GetComponent<Animation>().Play("StartGame");
            background.GetComponent<Animation>().Play("Background");
            StartCoroutine(cubeToBlock());
            cubes.GetComponent<Animation>().Play();
        }
    }
    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            cube[i].GetComponent<FallCube>().enabled = true;
        }
        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
    }
    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length + 1f);
        block.Play();

        m_cube.AddComponent<Rigidbody>();
        m_cube.GetComponent<Rigidbody>().drag = 0.5f;
    }
}
