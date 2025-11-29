using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;     // Velocidade do tiro

    private Rigidbody2D rb; // Gravidade

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();               // Acessa componente do obj

        rb.linearVelocity = transform.up * speed;         // Faz obj ir para cima
    }

    
    void Update()
    {
        
    }
}
