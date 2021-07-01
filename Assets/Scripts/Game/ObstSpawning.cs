using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstSpawning : MonoBehaviour
{
    [Header("Obst. Spawning")]
    public GameObject spawn;
    public GameObject parent;
    public List<GameObject> objects = new List<GameObject>();

    ScoreCounter score;

    [HideInInspector]
    public float time;
    

    // Start is called before the first frame update
    void Start()
    {
        time = 2.5f;
        score = GetComponent<ScoreCounter>();
        //InvokeRepeating("SpawnRect", 1, 2.5f);
        StartCoroutine(SpawnRect());
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(this, lifetime);
    }

    public void SetTime(float t)
    {
        time = t;
    }

    public float GetTime()
    {
        float minTime = 1.01f;
        float maxTime = 3f;

        return Random.Range(minTime, maxTime);
        //return time;
    }

    IEnumerator SpawnRect()
    {
        //yield return new WaitForSeconds(time);
        int i = 0;
        while (true)
        {
            
            //Debug.Log("i ="+ i);
            //yield return new WaitForSeconds(1.5f);
            SpawnObstacles();
           // i++;
            yield return new WaitForSeconds(GetTime());
        }
        
    }

    private void SpawnObstacles()
    {
        
        int result = (int) Random.Range(1.0f, 3.0f);
        Debug.Log("Type :"+result);
        switch (result)
        {
            case 1:
                spawn = Instantiate(objects[0], transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position = new Vector3(11.37f, -1.18f, 0);
                
                if(spawn.activeSelf == false)
                {
                    spawn.SetActive(true);
                }
                Destroy(spawn, 5f);
                break;
            case 2:
                spawn = Instantiate(objects[2], transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position = new Vector3(11.37f, -2f, 0);
                if (spawn.activeSelf == false)
                {
                    spawn.SetActive(true);
                }
                Destroy(spawn, 5f);
                break;
            case 3:
                spawn = Instantiate(objects[3], transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position = new Vector3(11.37f, -1.02f, 0);
                if (spawn.activeSelf == false)
                {
                    spawn.SetActive(true);
                }
                Destroy(spawn, 5f);
                break;
        }
        
    }

}
