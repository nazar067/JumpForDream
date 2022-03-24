using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, allCubes, diamond;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 5f;
    private bool onPlace;
    void Start()
    {
        spawn();
    }
    void Update()
    {
        if(blockInst.transform.position != blockPos && !onPlace)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
        else if (blockInst.transform.position == blockPos)
        {
            onPlace = true;
        }
        if (Cubejump.jump && Cubejump.nextBlock)
        {
            StartCoroutine(waiter());
            spawn();
            onPlace = false;
        }
    }
    float RandScale()
    {
        float rand;
        if(Random.Range(0,100) > 80)
        {
            rand = Random.Range(1.8f, 2.2f);
        }
        else
        {
            rand = Random.Range(1.8f, 2.2f);
        }
        return rand;
    }
    void spawn()
    {
        blockPos = new Vector3(Random.Range(1f, 2.1f), Random.Range(1.5f, -1.3f), -1.5f);
        blockInst = Instantiate(block, new Vector3(4.08f, -5.82f, 0f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(RandScale(), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = allCubes.transform;
        if (Cubejump.count_blocks % 1 == 0)
        {
            GameObject diamondInst = Instantiate(diamond, new Vector3(blockInst.transform.position.x, blockInst.transform.position.y + 1f, blockInst.transform.position.z), Quaternion.Euler(Camera.main.transform.eulerAngles)) as GameObject;
            diamondInst.transform.parent = blockInst.transform;
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2f);
    }
}
