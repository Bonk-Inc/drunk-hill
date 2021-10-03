using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFaller : MonoBehaviour
{
    
    [SerializeField]
    private Transform shadow, faller;

    [SerializeField]
    private float fallTimeInSeconds = 3;

    [SerializeField]
    private float fallHeightAddition = 3;

    [SerializeField]
    private Transform shadowScale;

    private SpriteRenderer fallerVisual;

    private void Awake() {
        fallerVisual = faller.GetComponent<SpriteRenderer>();
        faller.gameObject.SetActive(false);
        shadowScale.localScale = new Vector3(0, 0, 1);
    }

    public void Fall(){
        PositionObstacle();
        StartCoroutine(AnimateToPosition());
    }

    private void PositionObstacle(){
        Camera cam = Camera.main;
        Vector2 fallerPosition = shadow.position;
        fallerPosition.y = cam.transform.position.y + cam.orthographicSize + fallerVisual.bounds.extents.y + fallHeightAddition;
        faller.position = fallerPosition;
        faller.gameObject.SetActive(true);
    }

    private IEnumerator AnimateToPosition(){
        Vector3 startPosition = faller.localPosition;
        Vector3 targetPosition = shadowScale.localPosition;
        float way = 0;
        while (way < 1)
        {
            faller.localPosition = Vector3.Lerp(startPosition, targetPosition, way);

            float clampedWay = Mathf.Clamp01(way);
            shadowScale.localScale = new Vector3(clampedWay, clampedWay, 1);
            
            way += Time.deltaTime / fallTimeInSeconds;
            yield return null;
        }
        faller.localPosition = targetPosition;
        shadowScale.localScale = Vector3.one;
    }

}
