using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform pos1, pos2;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private List<GameObject> obstacles;

    public void SpawnObstacle(){
        Vector3 position = GetRandomPosition();
        CreateObstacle(position);
    }

    private Vector3 GetRandomPosition(){
        return new Vector3(
            Random.Range(Mathf.Min(pos1.position.x, pos2.position.x), Mathf.Max(pos1.position.x, pos2.position.x)),
            pos1.position.y,
            transform.position.z
        );
    }

    private void CreateObstacle(Vector3 position){
        GameObject obstacle = SpawnRandomObstacle();
        obstacle.transform.SetParent(parent);
        obstacle.transform.position = position;
    }

    private GameObject SpawnRandomObstacle(){
        GameObject prefab = obstacles[Random.Range(0, obstacles.Count)];
        return Instantiate(prefab);
    }


}
