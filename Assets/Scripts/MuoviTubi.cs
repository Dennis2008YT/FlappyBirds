using UnityEngine;

public class MuoviTubi : MonoBehaviour
{
    private float speed = 3f;
    private bool counted = false;

    void Update()
    {
        if(Flappy.playing)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            if(transform.position.x <= -8f)
            {
                Destroy(gameObject);
            }
            if(transform.position.x <= -1f && !counted)
            {
                Flappy.points++;
                StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Flappy>().playPointSound());
                counted = true;
            }
        }
    }
}
