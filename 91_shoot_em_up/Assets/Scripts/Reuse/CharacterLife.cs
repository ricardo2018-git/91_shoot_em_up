using System.Collections;
using UnityEngine;

public class CharacterLife : MonoBehaviour
{
    public int health;              // Vida player

    [HideInInspector]               // Não deixa aparecer a variavel isDead na unity mesmo ela sendo publica
    public bool isDead = false;     // Sinaliza se player esta morto

    public int scorePoints;         // Pontuação player


    public GameObject explosion;    // Game objeto da explosão
    private SpriteRenderer sprite;  // Sprite do objeto
    public Color damageColor;       // Cor

    public GameObject[] dropItems;  // Itens que pode ser dropado depois da morte do enemy
    private static int chanceToDroptItem = 0;    // Static todos que tiver esse script vai compartilhar o mesmo valor dessa var

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
                    chanceToDroptItem++;    // Contagem +1
                    int random = Random.Range(0, 100);  // Sorteia um valor entre
                    if(random < chanceToDroptItem && dropItems.Length > 0)  // Verifica se o numero sorteado é menor que a chance de drop E se existem itens que pode ser dropado
                    {
                        Instantiate(dropItems[Random.Range(0, dropItems.Length)], transform.position, Quaternion.identity); // Cria o item na tela
                        chanceToDroptItem = 0;  // Reseta chance se dropar o item
                    }
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
