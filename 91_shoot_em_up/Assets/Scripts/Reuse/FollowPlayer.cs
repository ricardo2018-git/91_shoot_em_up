using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;       // Alvo nosso player

    public float speed;             // Velocidade enemy

    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;     // Acessa a posição do player em tempo de execução
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);   // Faz obj ir até o player
    }
}
