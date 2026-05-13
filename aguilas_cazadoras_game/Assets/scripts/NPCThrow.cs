using UnityEngine;

public class NPCThrow : MonoBehaviour
{
    public Bomb bomb;
    public GameObject[] targets;

    float timer;
    public float delay = 2f;

    void Update()
    {
        // check if a pump exists
        if (bomb == null) return;

        // only if this NPC has the bomb
        if (bomb.currentHolder != gameObject) return;

        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0;

            int random = Random.Range(0, targets.Length);

            if (targets[random] != gameObject)
            {
                bomb.PassBomb(targets[random]);
            }
        }
    }
}