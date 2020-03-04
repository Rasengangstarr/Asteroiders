using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject asteroid2;
    
    
    void Start()
    {
        for (int x = 0; x < 100; x+=10) {
            for (int z = 0; z < 100; z+=10) {

                var asteroidNumber = Random.Range(0,2);
            
                GameObject asteroidPrefab;
                if (asteroidNumber == 0) {
                    asteroidPrefab = asteroid1;
                }
                else {
                    asteroidPrefab = asteroid2;
                }

                var asteroid = Instantiate(asteroidPrefab, new Vector3(Random.Range(x,x+10) , Random.Range(-5, 5), Random.Range(z,z+10)), Quaternion.identity);

                var scaleFactor = Random.Range(50f, 200f);

                asteroid.transform.localScale = new Vector3(scaleFactor + Random.Range(1f, 5f), scaleFactor + Random.Range(1f, 5f), scaleFactor + Random.Range(1f, 5f));
                asteroid.transform.Rotate(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));
            }
                

        }
                     
    }

}