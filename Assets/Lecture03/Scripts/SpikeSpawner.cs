using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;
    private Coroutine spawnRoutine;

    private bool isGameOver = false;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnSpikeRoutine());
    }

    IEnumerator SpawnSpikeRoutine()
    {
        while (!isGameOver)
        {
            float waitTime = Random.Range(1f, 4f);
            yield return new WaitForSeconds(waitTime);

            if (isGameOver)
                yield break; // ���ӿ����� �ڷ�ƾ ����

            Debug.Log("Spawner : Spike ����!");
            GameObject spike = Instantiate(SpikePrefab);
            spike.transform.position = transform.position;
        }
    }

    // ���ӿ��� �� ȣ��Ǵ� �Լ�
    public void GameOver()
    {
        isGameOver = true;
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
        Debug.Log("���� ���� - ������ũ ���� ����");
    }
}
