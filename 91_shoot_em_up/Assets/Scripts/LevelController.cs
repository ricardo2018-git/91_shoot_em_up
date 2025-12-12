using UnityEngine;
using TMPro;            // Texto no canvas
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;   // Manipular elementos de UI
using UnityEngine.SceneManagement;  // Para recarregar tela

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;  // 

    public TMP_Text livesText;      // Texto UI das vidas player
    public TMP_Text scoreText;      // texto UI da pontuação player
    private int score;              // Pontuação player

    public TMP_Text recordText;     // Recorde de pontuação em texto

    public GameObject gameOverPanel;    // Tela de game over

    public float startWait;         // Tempo para inicio dos spwans
    private bool gameOver = false;  // Sinaliza se jogo acabou
    private int enemyCount = 1;     // 
    public int enemyCountMax = 10;  // Limita qts de inimigos
    public float spawnWaitMin;      // Limita o tempo minimo para spawn
    public float waveWait;          // Tempo para proxima onde de spawn
    public float waveWaitMin;       // Tempo minimo para onda de spawn

    public GameObject[] enemies;    // Prefab de todos enemies
    public Boundary boundary;       // Classe publia criada no script do player
    public Vector2 spawnWait;       // Tempo depois de spwanar enemy

    void Start()
    {
        levelController = this;
        StartCoroutine(SpawnWaves());   // Executa IEnumerator
    }

    
    void Update()
    {
        if (gameOver)   // Verifica se player perdeu jogo
        {
            if (Input.GetMouseButtonDown(0))    // Verifica se foi pressionado btn esquerdo do mouse. Obs: no android traduz para um toque na tela
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Recarrega cena atual
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);  // Pera um pouco para iniciar a criação de inimigos  
        while(!gameOver)        // Loop enquanto não for fim do jogo ele roda
        {
            for(int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemies[Random.Range(0, enemies.Length)];    // Sorteia um inimigo
                Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax), boundary.yMin, 0);  // Sorteia posição onde enemy vai ser instanciado
                Instantiate(enemy, spawnPosition, Quaternion.identity);     // Estancia inimigo na posição da tela
                yield return new WaitForSeconds(Random.Range(spawnWait.x, spawnWait.y));    // Tempo de espera 
            }
            enemyCount++;   // Contagem de enemy
            if(enemyCount >= enemyCountMax)     // 
            {
                enemyCount = enemyCountMax;     // 
            }
            spawnWait.x -= 0.1f;    // Deixa o tempo de spawn mais rapido, cria dificuldade
            spawnWait.y -= 0.1f;    // Deixa o tempo de spawn mais rapido, cria dificuldade
            
            if(spawnWait.x <= spawnWaitMin)
            {
                spawnWait.x = spawnWaitMin;     // Limita tempo
                spawnWait.y = spawnWaitMin;     // Limita tempo
            }
            yield return new WaitForSeconds(waveWait);  // Tempo para proxima onda de spawn
            waveWait -= 0.1f;   // Deixa mais rapido a proxima onda de spawn
            if(waveWait <= waveWaitMin)     // Verifica se ja chegou no menor valor possivel
            {
                waveWait = waveWaitMin;     // Limita no menor valor
            }
        }
    }

    public void SetLivesText(int lives)     // Atualiza qts vidas no UI
    {
        livesText.text = lives.ToString();  // 
    }

    public void SetScore(int scorePoints)   // Atualiza pontos player na UI
    {
        score += scorePoints;               // Atualiza pontuação com atual + o recebido
        scoreText.text = "Score: " + score.ToString();  // Atualiza pontos na UI
    }

    public void GameOver()  
    {
        gameOver = true;                // Sinaliza que perdeu jogo
        gameOverPanel.SetActive(true);  // Ativa painel game over

        // Salva maior pontuação do jogo
        if(PlayerPrefs.GetInt("MaxScore") < score)  // Verifica se maior score ja salvo é menor que score
        {
            PlayerPrefs.SetInt("MaxScore", score);  // Salva score atual do jogo
        }

        recordText.text = "Record: " + PlayerPrefs.GetInt("MaxScore");  // Mostra maior pontuação ja feita no jogo
    }
}
