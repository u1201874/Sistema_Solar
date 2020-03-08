using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tras_Marte : MonoBehaviour
{

    Vector3 posicion;
    float tiempo;
    float distancia = 227;
    float theta = 0;
    // float masa = 5.9722f;//Kg
    float periodo = 686;//dias

    float avance;
    // Start is called before the first frame update
    void Start()
    {
        posicion = new Vector3(0, 0, 227);

    }

    // Update is called once per frame
    void Update()
    {

        avance = 2 * 3.1416f / periodo;


        posicion = gameObject.GetComponent<Transform>().position;
        posicion.z = distancia * Mathf.Cos(theta);
        posicion.x = distancia * Mathf.Sin(theta);
        gameObject.GetComponent<Transform>().position = posicion;


        theta = theta + avance;

    }
}
