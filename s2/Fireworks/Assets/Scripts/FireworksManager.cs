using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireworksManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fireworkPrefab;

    [SerializeField]
    private float randomPositionXUpperbound = 10;

    [SerializeField]
    private float randomPositionXLowerbound = 10;

    [SerializeField]
    private float randomPositionZUpperbound = 10;

    [SerializeField]
    private float randomPositionZLowerbound = 10;

    private readonly List<GameObject> _singleInstances = new();
    private readonly List<IList<GameObject>> _fireworkShows = new();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LaunchSingleRocket();
        }

        if (Input.GetKey(KeyCode.C))
        {
            DisposeAllSingleInstances();
        }
    }

    private void LaunchSingleRocket()
    {
        GameObject rocket = Instantiate(fireworkPrefab);
        rocket.gameObject.SetActive(false);
        rocket.transform.position = GetRandomPosition();
        _singleInstances.Add(rocket);
        rocket.gameObject.SetActive(true);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(randomPositionXLowerbound, randomPositionXUpperbound), 0,
            Random.Range(randomPositionZLowerbound, randomPositionZUpperbound));
    }

    private void DisposeAllSingleInstances()
    {
        _singleInstances.ForEach(Destroy);
        _singleInstances.Clear();
    }
}