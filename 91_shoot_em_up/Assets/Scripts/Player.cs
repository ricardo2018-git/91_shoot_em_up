using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   // Interagir com UI

[System.Serializable]   // Para conseguir editar pelo editor da unity
public class Boundary   // São os limites que player pode ir pela tela
{
    public float xMin, xMax;    // Limite minimo e maximo horizontal
    public float yMin, yMax;    // Limite minimo e maximo vertical
}

public class Player : MonoBehaviour
{
    private CharacterLife characterLife;    // Referencia ao script

    public int lives = 3;                   // Qts vidas player
    private bool isDead = false;            // Sinaliza se player esta morto
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    public Boundary boundary;   // Classe que foi criada a cima

    public GameObject bullet;   // Tiro do player
    private SpriteRenderer sprite;  // Sprite do player
    private Vector3 startPosition;  // Posição inicial padrão do player

    public float spawnTime;         // Tempo para spawnar
    public float invencibilityTime; // Tempo que player não recebe dano depois de ser spaenado

    public int fireLevel = 1;   // Controla level dos tiros

    // Controla quantidade de tiros
    public float fireRate;      // Tempo fixo para liberar o proximo tiro
    private float nextFire;     // Vai receber tempo atual do jogo + o tempo fixo

    // UI botão de tiro
    public Button shootButton;      // referência ao botão
    public GameObject bulletPrefab; // prefab da bala
    public Transform[] shotSpawns;  // ponto de saída da bala

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // 
        sprite = GetComponent<SpriteRenderer>();    // 
        shootButton.onClick.AddListener(Shoot);     // Vincula a função Shoot ao clique do botão
        startPosition = transform.position;         // Pega posição inicial do player

        characterLife = GetComponent<CharacterLife>();  // Acessa o proprio componente
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(movementJoystick.Direction.y != 0)   // Verifica se joystick esta sendo precionado para algum eixo
        {
            rb.linearVelocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);    // Faz player se mover
        }
        else
        {
            rb.linearVelocity = Vector2.zero;   // Para player
        }

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));  // Limita movimentação do player pela tela nos eixos x e y

    }

    void Shoot()    // Efetua o tiro
    {
        if(Time.time > nextFire)    // Verifica se passou o tempo para liberar o proximo tiro
        {
            if(fireLevel >= 1)  // Verifica se esta no level 1
            {
                Instantiate(bulletPrefab, shotSpawns[0].position, shotSpawns[0].rotation);  // Instancia a bala no ponto de tiro
            }
            if(fireLevel >= 2) // Verifica se esta no level 2
            {
                Instantiate(bulletPrefab, shotSpawns[1].position, shotSpawns[1].rotation);  // Instancia a bala no ponto de tiro
                Instantiate(bulletPrefab, shotSpawns[2].position, shotSpawns[2].rotation);  // Instancia a bala no ponto de tiro
            }
            if(fireLevel >= 3)
            {
                Instantiate(bulletPrefab, shotSpawns[3].position, shotSpawns[3].rotation);  // Instancia a bala no ponto de tiro
                Instantiate(bulletPrefab, shotSpawns[4].position, shotSpawns[4].rotation);  // Instancia a bala no ponto de tiro
            }
            nextFire = Time.time + fireRate;                                            // Atualiza o tempo do proximo tiro
        }
    }

    public void Respawn()
    {
        lives--;    // Tira uma vida do player
        if(lives > 0)   // Verifica se player tem vidas ainda
        {
            StartCoroutine(Spawning());     // Executa o IEnumerator 
        }
        else
        {
            lives = 0;              // Zera qts de vidas
            isDead = true;          // Sinaliza que player morreu
            sprite.enabled = false; // Desativa sprite do player
            LevelController.levelController.GameOver(); // Acessa função de game over
        }

        LevelController.levelController.SetLivesText(lives);    // Atualiza vidas na UI
    }

    IEnumerator Spawning()                          // Processo de perda de vida player
    {
        isDead = true;                              // Sinaliza que player morreu
        sprite.enabled = false;                     // Desativa sprite player
        fireLevel = 1;                              // level do tiro inicial
        gameObject.layer = 11;                      // Muda player para layer do enemy que é a 10
        yield return new WaitForSeconds(spawnTime); // Espero por x segundos
        isDead = false;                             // Sinaliza que player esta vivo
        transform.position = startPosition;         // Posiciona player na posição padrão do inicio do game
        for (float i = 0; i < invencibilityTime; i+= 0.1f)   // Como se fosse um cronometro.
        {
            sprite.enabled = !sprite.enabled;       // Faz ficar piscando o sprite do player
            yield return new WaitForSeconds(0.1f);  // Espera por x segundos
        }
        gameObject.layer = 6;   // Volta player para sua layer inicial
        sprite.enabled = true;  // Garante que que o sprite do player vai esta ativado
        characterLife.isDead = false;   // Sinaliza que player morreu para outro script
    }

}
