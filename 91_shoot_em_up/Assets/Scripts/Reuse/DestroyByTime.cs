using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float destroyTime;   // Tempo para destruir obj

    void Start()
    {
        Destroy(gameObject, destroyTime);   // Destroi obj em x segundos
    }

    void Update()
    {
        
    }
}
