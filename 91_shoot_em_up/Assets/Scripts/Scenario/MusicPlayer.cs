using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer musicPlayer;     // Referencia a proprio class

    public AudioClip[] songs;                   // Vetor para receber todas as músicas

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
        
    }

    void Update()
    {
        
    }
}
