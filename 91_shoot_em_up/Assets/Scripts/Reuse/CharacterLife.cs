using System.Collections;
using UnityEngine;

public class CharacterLife : MonoBehaviour
{
    public int health;              // Vida player

    [HideInInspector]               // Não deixa aparecer a variavel isDead na unity mesmo ela sendo publica
    public bool isDead = false;    // Sinaliza se player esta morto

    public int scorePoints;         // Pontuação player


    public GameObject explosion;    // Game objeto da explosão
    private SpriteRenderer sprite;  // Sprite do objeto
    public Color damageColor;       // Cor

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    // Acessa proprio sprite
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)    // Verifica se NÃO esta morto
        {
            health -= damage;   // Tira da vida o valor do dano
            if(health <= 0)     // Verifica se morreu
            {
                isDead = true;          // Sinaliza que morreu
                Instantiate(explosion, transform.position, transform.rotation); // Instancia explosão depois que morrer
                if(this.GetComponent<Player>() != null)     // Verifica se existe esse componente no game object. É um forma de identificar se esse script esta no player
                {
                    GetComponent<Player>().Respawn();   // Executa função do player. [Processo de perda de vida player]
                }
                else
                {
                    
                    LevelController.levelController.SetScore(scorePoints);  // Atualiza pontuação do UI
                    Destroy(gameObject);    // Destroi obj
                }
            }
            else
            {
                StartCoroutine(TakingDamage());     // Executa coroutine
            }
        }
    }

    IEnumerator TakingDamage()  // coroutine
    {
        sprite.color = damageColor;             // Troca cor do sprite
        yield return new WaitForSeconds(0.1f);  // Espera por 0.x segundos
        sprite.color = Color.white;             // Volta pra cor normal do sprite
    }
}
