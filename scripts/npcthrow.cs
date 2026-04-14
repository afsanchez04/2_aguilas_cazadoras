using UnityEngine;

public class NPCThrow : MonoBehaviour
{
    public Bomb bomb;
    public GameObject[] targets;

    float timer;
    public float delay = 2f;

    void Update()
    {
        // solo si este NPC tiene la bomba
        if (bomb.currentHolder != gameObject) return;

        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0;

            int random = Random.Range(0, targets.Length);
            bomb.PassBomb(targets[random]);
        }
    }
}