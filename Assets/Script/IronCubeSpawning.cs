using UnityEngine;

public class IronCubeSpawning : MonoBehaviour
{
    public GameObject _ironCube; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCubesSurrounding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCubesSurrounding() 
    {
        for(int i = 0; i < 20; i++) 
        {
            Instantiate(_ironCube, new Vector3(-19f + (2 * i), 0, 19f), Quaternion.identity);  
        }

        for (int i = 0; i < 20; i++)
        {
            Instantiate(_ironCube, new Vector3(-19f + (2 * i), 0, -19f), Quaternion.identity);
        }

        for(int j = 0; j < 18; j++) 
        {
            Instantiate(_ironCube, new Vector3(-19f, 0, -17f + (2 * j)), Quaternion.identity);
        }

        for (int j = 0; j < 18; j++)
        {
            Instantiate(_ironCube, new Vector3(19f, 0, -17f + (2 * j)), Quaternion.identity);
        }
    }
}
