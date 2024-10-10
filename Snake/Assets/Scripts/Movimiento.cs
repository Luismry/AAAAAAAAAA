using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   Vector2 direccion = Vector2.right;
    public Transform segmentoPrefab;
    List<Transform> TamañoSerpiente = new List<Transform>();

    private void Start()
    {
        TamañoSerpiente.Add(transform);
        Time.timeScale = 1.0f;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))  //up.arrow      //.W
        {
            direccion = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S))   //down.arrow   //.S
        {
            direccion = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.A))   //left.arrow   //.A
        {
            direccion = Vector2.left;
        }
        else if( Input.GetKeyDown(KeyCode.D))   //right.arrow
        {
            direccion = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for(int i = TamañoSerpiente.Count - 1; i > 0; i--)
        {
            TamañoSerpiente[i].position = TamañoSerpiente[i - 1].position;
        }
        
        
        
        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x, Mathf.Round(transform.position.y) + direccion.y, 0.0f);
    }

    void Reset()
    {
        for (int i = 1; i <TamañoSerpiente.Count; i++)
        {
            Destroy(TamañoSerpiente [i].gameObject);
        }
        TamañoSerpiente.Clear();
        TamañoSerpiente.Add(transform);

        transform.position = Vector3.zero;
    }


    void Crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = TamañoSerpiente[TamañoSerpiente.Count - 1].position;
        TamañoSerpiente.Add(segmentoNuevo);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstaculo"))
        {
            Reset();
        }

        if(collision.CompareTag("Comida"))
        {
            Crecer(); 
        }

    }

}
