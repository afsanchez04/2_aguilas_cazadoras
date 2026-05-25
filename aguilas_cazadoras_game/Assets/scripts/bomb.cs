using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [Header("Timer")]
    public float timer = 15f;

    [Header("Current Holder")]
    public GameObject currentHolder;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public GameObject timeoutMessage;

    public TextMeshProUGUI loserText;
    public GameObject restartText;

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

        // Hide message when starting the game
        if (timeoutMessage != null)
        {
            timeoutMessage.SetActive(false);
        }

        // hide loser text
        if (loserText != null)
        {
            loserText.gameObject.SetActive(false);
        }

        // hide restart text
        if (restartText != null)
        {
            restartText.SetActive(false);
        }
    }

    void Update()
    {
        
        // restart after exploding
        if (exploded)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            return;
        }

        // seguir al jugador
        if (currentHolder != null)
        {
            transform.position =
                currentHolder.transform.position + Vector3.up * 2f;
        }

        // reduce time
        timer -= Time.deltaTime;

        // update counter
        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.Ceil(timer).ToString();
        }

        // burst
        if (timer <= 0)
        {
            Explode();
        }
    }

    // pass bomb
   public void PassBomb(GameObject newHolder)
{
    // stop passing after explosion
    if (exploded) return;

    currentHolder = newHolder;

    // launch sound
    if (audioSource != null && throwSound != null)
    {
        audioSource.PlayOneShot(throwSound);
    }
}

    // burst
    void Explode()
    {
        exploded = true;

        Debug.Log("BOOM! perdió: " + currentHolder.name);

        // visual burst
        if (explosionEffect != null)
        {
            // separate particles
            explosionEffect.transform.parent = null;

            // move explosion
            explosionEffect.transform.position = transform.position;

            // reproduce effect
            explosionEffect.Play();

            // destroy particles
            Destroy(explosionEffect.gameObject, 3f);
        }

        // sound of explosion
        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        // hide counter
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }

        // show GAME OVER
        if (timeoutMessage != null)
        {
            timeoutMessage.SetActive(true);
        }
        // show loser name
        if (loserText != null)
        {
            loserText.text = "Player Lost: " + currentHolder.name;
            loserText.gameObject.SetActive(true);
        }

        // show restart message
        if (restartText != null)
        {
            restartText.SetActive(true);
        }
        // hide visual model of the pump
        {
            transform.localScale = Vector3.zero;
        }
        

        // destroy bomb
        //Destroy(gameObject, 2f);
    }
}