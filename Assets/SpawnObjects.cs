using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject gameObject;
    public int xPos;
    public int zPos;
    public int count;
    public int yPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        while (count < 10)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            Instantiate(gameObject, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            count += 1;
        }
    }
}
