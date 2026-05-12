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

    [Header("Explosion")]
    public ParticleSystem explosionEffect;

    [Header("Sounds")]
    public AudioClip throwSound;
    public AudioClip explosionSound;

    private AudioSource audioSource;

    private bool exploded = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ocultar mensaje al iniciar
        if (timeoutMessage != null)
        {
            timeoutMessage.SetActive(false);
        }
    }

    void Update()
    {
        // detener actualización después de explotar
        if (exploded) return;

        // seguir al jugador
        if (currentHolder != null)
        {
            transform.position =
                currentHolder.transform.position + Vector3.up * 2f;
        }

        // disminuir tiempo
        timer -= Time.deltaTime;

        // actualizar contador
        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.Ceil(timer).ToString();
        }

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

        // sonido lanzamiento
        if (audioSource != null && throwSound != null)
        {
            audioSource.PlayOneShot(throwSound);
        }
    }

    // explosión
    void Explode()
    {
        exploded = true;

        Debug.Log("BOOM! perdió: " + currentHolder.name);

        // explosión visual
        if (explosionEffect != null)
        {
            // separar partículas
            explosionEffect.transform.parent = null;

            // mover explosión
            explosionEffect.transform.position = transform.position;

            // reproducir efecto
            explosionEffect.Play();

            // destruir partículas después
            Destroy(explosionEffect.gameObject, 3f);
        }

        // sonido explosión
        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        // ocultar contador
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }

        // mostrar GAME OVER
        if (timeoutMessage != null)
        {
            timeoutMessage.SetActive(true);
        }

        // destruir bomba
        Destroy(gameObject);
    }
}