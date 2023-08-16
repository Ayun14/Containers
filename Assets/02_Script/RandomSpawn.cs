using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private int boxCount = 23;

    IEnumerator enumerator;

    private void Awake()
    {
        enumerator = BoxSpawn();
    }

    private void Start()
    {
        while (boxCount > 0)
        {
            StartCoroutine(BoxSpawn());
            boxCount--;
        }
    }

    public void StartBoxSpawn()
    {
        StartCoroutine(enumerator);
        Debug.Log("다시 생성");
    }

    private IEnumerator BoxSpawn()
    {
        GameObject box = Instantiate(boxPrefab);
        int rdIndex = Random.Range(0, transform.childCount);
        box.transform.position = transform.GetChild(rdIndex).position;
        yield return null;
    }
}
