using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;
    public Transform particulas;
    public Transform particulasError;
    private ParticleSystem systemaParticulas;
    private ParticleSystem systemaParticulasError;

    private Vector3 posicion;

    private int puntaje;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        systemaParticulas = particulas.GetComponent<ParticleSystem> ();
        systemaParticulas.Stop();

        rb = GetComponent<Rigidbody> ();
        systemaParticulasError = particulasError.GetComponent<ParticleSystem> ();
        systemaParticulasError.Stop();
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate (){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movimiento = new Vector3 (moveHorizontal, 0.0f, moveVertical); 

        rb.AddForce (movimiento*speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Recolectable")){
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            systemaParticulas.Play();
            other.gameObject.SetActive(false);
            puntaje = puntaje + 1;
        } else if (other.gameObject.CompareTag("RecolectableMalo")){
            posicion = other.gameObject.transform.position;
            particulasError.position = posicion;
            systemaParticulasError = particulasError.GetComponent<ParticleSystem> ();
            systemaParticulasError.Play();
            other.gameObject.SetActive(false);
            puntaje = puntaje - 1;
        }

        Debug.Log("Puntaje: " + puntaje);
    }
}
