using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    [SerializeField]
    public float width, height;

    [SerializeField]
    private List<Prop> props;

    private Rect rect = new Rect();

    private void Awake() {
        
        rect.width = width;
        rect.height = height;
        rect.center = transform.position;

        SpawnProps();
    }

    public void SpawnProps() {
        
        foreach (Prop prop in props)
        {
            SpawnProp(prop);
        }
    }

    public void SpawnProp(Prop prop){
        float amount = width * height * prop.density;
        for (var i = 0; i < amount; i++)
        {
            PutPropOnMap(prop);
        }
    }

    private void PutPropOnMap(Prop prop){
        Vector2 point = GetRandomPoint();
        PutPropAtPosition(point, prop);
    }

    private Vector2 GetRandomPoint(){
        float x = UnityEngine.Random.Range(rect.xMin, rect.xMax);
        float y = UnityEngine.Random.Range(rect.yMin, rect.yMax);
        return new Vector2(x, y);
    }

    private void PutPropAtPosition(Vector2 position, Prop prop){
        GameObject propInstance = SpawnFromProp(prop);
        propInstance.transform.SetParent(transform);
        propInstance.transform.position = position;
    }

    private GameObject SpawnFromProp(Prop prop){
        return Instantiate(prop.prefab);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }

    [Serializable]
    public class Prop
    {
        public GameObject prefab;
        public float density;
    }

}
