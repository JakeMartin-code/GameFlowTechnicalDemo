using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphTool;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float pipeSpawnTime;
    private float _timePased = 0;
    public GameObject pipe;
    public float maxPipeHeight;
    public float minPipeHeight;
    public float currentPipeHeight;
    public float pipeHeightMultipier;

    public float challengeCountdown;
    public float elapsedChallengeCountdown;


    void Start()
    {
        GameObject spawnPipe = Instantiate(pipe);
        spawnPipe.transform.position = transform.position + new Vector3(0, Random.Range(-minPipeHeight, minPipeHeight), 0);
        currentPipeHeight = minPipeHeight;

        elapsedChallengeCountdown = challengeCountdown;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedChallengeCountdown -= Time.deltaTime;
      
        if (elapsedChallengeCountdown <= 0)
        {
            currentPipeHeight += pipeHeightMultipier;
            elapsedChallengeCountdown = challengeCountdown;
            GraphTool.GraphRenderer1.FindObjectOfType<GraphRenderer1>().hasChallengeChanged = true;
        }

        if(_timePased > pipeSpawnTime)
        {
            GameObject spawnPipe = Instantiate(pipe);
            spawnPipe.transform.position = transform.position + new Vector3(0, Random.Range(-currentPipeHeight, currentPipeHeight), 0);
            _timePased = 0;
        }

        _timePased += Time.deltaTime;
    }
}
