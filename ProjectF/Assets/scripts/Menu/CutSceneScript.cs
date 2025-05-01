using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndCutscene; // Chama função ao terminar
    }
    void EndCutscene(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync("Entrada FEI");
        Destroy(gameObject);
        // Aqui você pode carregar a próxima cena ou esconder o vídeo
    }


}