using UnityEngine;

public class MoveTerrainScript : MonoBehaviour
{
    [SerializeField] private GameObject Terrain;
     private float speed = 3f;
    private Vector3 terrainStartPosition;

    void Start()
    {
        terrainStartPosition = Terrain.transform.position;
    }

    void Update()
    {
        if(Flappy.playing) MoveTerrain();
    }

    private void MoveTerrain()
    {
        Terrain.transform.position = new Vector2(Terrain.transform.position.x - (speed * Time.deltaTime), Terrain.transform.position.y);
        if(Terrain.transform.position.x <= -7.2f)
        {
            Terrain.transform.position = terrainStartPosition;
        }
    }
}
