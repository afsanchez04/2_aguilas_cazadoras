using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    [Header("Timer")]
    public float timer = 15f;

    [Header("Current Holder")]
    public GameObject currentHolder;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public GameObject timeoutMessage;

    [Header("Sounds")]
    public AudioClip throwSound;
    public AudioClip explosionSound;

    private AudioSource audioSource;

    private bool exploded = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ocultar mensaje al iniciar
        timeoutMessage.SetActive(false);
    }

    void Update()
    {
        if (exploded) return;

        // seguir al jugador
        if (currentHolder != null)
        {
            transform.position =
                currentHolder.transform.position + Vector3.up * 2f;
        }

        // disminuir tiempo
        timer -= Time.deltaTime;

        // actualizar UI
        timerText.text =
            "Time: " + Mathf.Ceil(timer).ToString();

        // explotar
        if (timer <= 0)
        {
            Explode();
        }
    }

    // pasar bomba
    public void PassBomb(GameObject newHolder)
    {
        currentHolder = newHolder;

        // reproducir sonido lanzamiento
        audioSource.PlayOneShot(throwSound);
    }

    void Explode()
    {
        exploded = true;

        Debug.Log("BOOM! perdió: " + currentHolder.name);

        // sonido explosión
        audioSource.PlayOneShot(explosionSound);

        // mostrar mensaje
        timeoutMessage.SetActive(true);

        // cambiar texto del contador
        timerText.text = "TIME OUT";

        // destruir después de 2 segundos
        Destroy(gameObject, 2f);
    }
}