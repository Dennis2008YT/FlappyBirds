using UnityEngine;

public class SpawnTubi : MonoBehaviour
{
    [SerializeField] GameObject Tubi;
    float timer = 3f, spawnTimer = 0f;

    void Update()
    {
        if(Flappy.playing)
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= timer)
            {
                spawnTimer = 0f;
                Instantiate(Tubi, new Vector2(3.6f, Random.Range(-1f, 2.5f)), Quaternion.identity);
            }
        }
    }
}
