using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer musicPlayer;     // Referencia a proprio class
    private AudioSource audioSource;            // Referencia ao componente

    public AudioClip[] songs;                   // Vetor para receber todas as músicas
    private int index;                          // Controla qual musica

    void Awake()
    {
        if(musicPlayer == null)     // Verifica se obj ja esta criado
        {
            musicPlayer = this;     // Cria esse obj
        }
        else if (musicPlayer != this)   // Verifica se ojb é Diferente desse obj
        {
            Destroy(gameObject);        // Destroi obj
        }
        DontDestroyOnLoad(gameObject);  // Não deixa destruir obj entre cenas
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Acessa componente de audio
        index = Random.Range(0, songs.Length);      // Sorteia um valor de 0 até a quantidade total de músicas que tiver no array
        StartMusicPlayer();                         // Chama metodo que toca música do cenario
    }

    void Update()
    {
        
    }

    void StartMusicPlayer()                 // Toca todas as músicas
    {
        audioSource.clip = songs[index];    // Seleciona uma música
        index++;                            // Add +1, ou seja vai para proxima música
        if(index >= songs.Length)           // Verifica se index ja passou da ultima musica
        {
            index = 0;                      // Reseta index, coloca na primeira música
        }
        audioSource.Play();                 // Coloca para tocar música
        Invoke("StarMusicPlayer", audioSource.clip.length + 0.5f);  // Chama proprio metodo para tocar proxima música, mas só depois que terminar a que esta tocando + um preve atraso de 0.5f
    }
}
