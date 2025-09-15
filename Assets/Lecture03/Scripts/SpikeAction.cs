using UnityEngine;

public class SpikeAction : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        // 왼쪽으로 이동
        transform.position = new Vector3(transform.position.x -0.05f, transform.position.y, transform.position.z);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("박았어!!!");
        if (collision.gameObject.CompareTag("SpikeDestroyer")) ;
        {
            Destroy(gameObject);
            
        }
    }
}
