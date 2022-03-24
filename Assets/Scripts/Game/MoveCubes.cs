using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;
    public GameObject detectClicks;
    void Start()
    {
        target = new Vector3(-0.72f, 4.18f, -3.174529f);
    }

    void Update()
    {
        if (Cubejump.nextBlock)
        {
            if (transform.position != target && Cubejump.count_blocks > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 2.5f);
            }
            else if (transform.position == target && !moved)
            {
                detectClicks.SetActive(false);
                target = new Vector3(transform.position.x - 2.75f, transform.position.y + 2.8f, transform.position.z);
                Cubejump.jump = false;
                moved = true;
                StartCoroutine(CanJump());
            }
            if (Cubejump.jump)
            {
                moved = false;
            }
        }
    }
    IEnumerator CanJump()
    {
        yield return new WaitForSeconds(1.5f);
        detectClicks.SetActive(true);
    }
}
