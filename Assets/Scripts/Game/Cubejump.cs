using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cubejump : MonoBehaviour
{
    public static bool jump, nextBlock;
    public GameObject mainCube, buttons, lose_buttons, detectClicks;
    private bool animate, lose;
    private float scratch_speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;

    void Awake()
    {
        jump = false;
        nextBlock = false;
    }

    void Start()
    {
        StartCoroutine(CanJump());
    }

    void FixedUpdate()
    {
        if (animate && mainCube.transform.localScale.y > 0.5f)
        {
            PressCube(-scratch_speed);
        }else if (!animate&&mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1.256121f)
            {
                PressCube(scratch_speed * 3f);
            }
        }
        if (mainCube != null)
        {
            if (mainCube.transform.position.y < -9.84f)
            {
                Destroy(mainCube, 0.5f);
                print("Lose");
                lose = true;
            }
        }
        if (lose)
        {
            PlayerLose();
        }
    }
    void PlayerLose()
    {
        buttons.GetComponent<ScrollObjects>().speed = -5f;
        buttons.GetComponent<ScrollObjects>().checkpoz = 0;
        if (!lose_buttons.activeSelf)
        {
            lose_buttons.SetActive(true);
        }
        lose_buttons.GetComponent<ScrollObjects>().checkpoz = 50;
        detectClicks.transform.position = new Vector3(0f, 1.27f, -8.54f);
        detectClicks.transform.eulerAngles = new Vector3(0f, 0f, 0f);

    }
    void OnMouseDown()
    {
        if (mainCube != null && nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;
            yPosCube = mainCube.transform.localPosition.y;
        }
    }
    void OnMouseUp()
    {
        if (mainCube != null && nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = false;
            jump = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f)
            {
                force = 180 * diff;
            }
            else
            {
                force = 300f;
            }
            if(force < 60f)
            {
                force = 60f;
            }
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * force);
            StartCoroutine(checkCubePos());
            nextBlock = false;
        }
    }
    void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(2f);
        if ((int)yPosCube == (int)mainCube.transform.localPosition.y)
        {
            print("Lose");
            lose = true;
        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                    break;
                
            }
            if (!lose)
            {
                nextBlock = true;
                mainCube.transform.localPosition = new Vector3(mainCube.transform.localPosition.x, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                mainCube.transform.eulerAngles = new Vector3(mainCube.transform.eulerAngles.x, mainCube.transform.eulerAngles.y, 0f);
                print("Next");
                count_blocks++;
            }
        } 
    }
    IEnumerator CanJump()
    {
        while(!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1f);
        nextBlock = true;
        detectClicks.SetActive(true);
    }
}
