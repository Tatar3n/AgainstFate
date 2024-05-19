using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4BehaviorScenario : MonoBehaviour
{
    [SerializeField] private Transform cameraMovePoint;
    [SerializeField] private float movePointSpeed = 0.32f;
    [SerializeField] private GameObject cameraStopPoints;
    private List<Transform> cameraStopPointsArr;
    private bool canMove = true;
    private int stage = 0;
    [SerializeField] private Transform pointDelTiles;

    // Получаем компонент Camera
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject pointVisibleByCamera;
    [SerializeField] private Transform aquarius; 
    private List<Transform> pointVisibleByCameraArr;
    private List<bool> pointVisibleByCameraCheckArr;
    private bool canSpawnAquaruis = false;
    [SerializeField] private Transform player;

    void Start()
    {
        cameraStopPointsArr = new List<Transform>();
        foreach (Transform point in cameraStopPoints.GetComponentsInChildren<Transform>())
        {
            if(point != cameraStopPoints.transform)
                cameraStopPointsArr.Add(point);
        }
        pointVisibleByCameraCheckArr = new List<bool>();
        pointVisibleByCameraArr = new List<Transform>();
        foreach (Transform point in pointVisibleByCamera.GetComponentsInChildren<Transform>())
        {
            pointVisibleByCameraArr.Add(point);
            pointVisibleByCameraCheckArr.Add(false);
        }
    }

	void Update()
    {
        if (canSpawnAquaruis)
            aquarius.transform.position += transform.right * Time.deltaTime * movePointSpeed;
        if (stage == 0)
        {
            movePointSpeed = 1.5f;
        }
        else if (stage == 1)
        {
            movePointSpeed = 0.96f;
            StartCoroutine(SpawnAquaruisDelay());
            //GetComponent<DestroyHalfOfTilemap>().RemoveTilesInArea((Vector3Int)pointDelTiles.position, 2f);
        }
        else if (stage == 2)
        {
            // А теперь ускоримся
            movePointSpeed = 1.5f;
        }

        if (canMove)
        {
            cameraMovePoint.position += cameraMovePoint.right * Time.deltaTime * movePointSpeed;
            foreach (Transform point in cameraStopPointsArr)
                if (point.position.x < cameraMovePoint.position.x)
                {
                    cameraStopPointsArr.Remove(point);
                    stage++;
                    StartCoroutine(MoveDelay(2f));
                    break;
                }
            for (int i = 0; i < pointVisibleByCameraArr.Count; i++)
            {
                if (pointVisibleByCameraArr[i] != null)
                {
                    Vector3 viewportPos = mainCamera.WorldToViewportPoint(pointVisibleByCameraArr[i].position);
                    if (viewportPos.x >= 0 && viewportPos.x <= 1.1 && viewportPos.y >= 0 && viewportPos.y <= 1 && !pointVisibleByCameraCheckArr[i])
                    {
                        Transform point = pointVisibleByCameraArr[i];
                        Vector3 endPosition = new Vector3(point.position.x, pointVisibleByCameraArr[i].position.y, point.position.z);
                        point.position = new Vector3(point.position.x, point.position.y - 10f);
                        point.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        pointVisibleByCameraCheckArr[i] = true;
                        StartCoroutine(MovePlatform(point, endPosition));
                    }
                    else if (viewportPos.x < 0.17f && (viewportPos.y >= 0 && viewportPos.y <= 1) && pointVisibleByCameraCheckArr[i])
                    {
                        Destroy(pointVisibleByCameraArr[i].gameObject);
                        pointVisibleByCameraArr[i] = null;
                    }
                }
            }
        }
        if (aquarius.gameObject.GetComponent<Boss4HP>().GetHP() <= 0)
        {
            mainCamera.GetComponentInParent<CameraMotor>().target = player;
            Destroy(gameObject);
        }
    }

    private IEnumerator MoveDelay(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

    private IEnumerator SpawnAquaruisDelay()
    {
        canSpawnAquaruis = false;
        yield return new WaitForSeconds(5f);
        canSpawnAquaruis = true;
        aquarius.transform.position = new Vector3(cameraMovePoint.position.x - (mainCamera.orthographicSize * mainCamera.aspect) / 6 * 5, cameraMovePoint.position.y);
    }

    IEnumerator MovePlatform(Transform objectTransform, Vector3 targetPoint)
    {
        float distance = Vector3.Distance(objectTransform.position, targetPoint);
        while (distance > 0.1f) 
        {
            objectTransform.position = Vector3.Lerp(objectTransform.position, targetPoint, Time.deltaTime * 3f);
            distance = Vector3.Distance(objectTransform.position, targetPoint);
            yield return null;
        }
    }
}
