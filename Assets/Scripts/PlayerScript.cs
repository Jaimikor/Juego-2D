using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //The PlayerInput the player will use                //El PlayerInput el jugador lo usará
    public PlayerInput playerInput;

    //The bullet the player will shoot                   //La bullet del jugador disparará
    public GameObject bullet;

    //The point from where the bullets will be shoot     //El punto desde donde la bala se disparará
    public Transform gun;

    //The Player speed of movement                       //La velocidad del jugador
    public float speed = 5f;

    //The movement of the player right now               //El movimiento del jugador ahora mismo
    private Vector2 inputMovement;

    //The health of the player                           //La vida del jugador
    private int health = 3;

    //First let's start with the input controller        //Primero vamos a empezar con el input controller
    public void OnShoot(InputAction.CallbackContext value)
    {
        Debug.Log("Shoot: " + value.started);
        if (value.started)
        {
            //Here write the code for when you shoot     //Aqui escribe el codigo para cuando dispares
            GameObject projectile = Instantiate(bullet, gun.position, transform.rotation);
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    void Update()
    {
        Movement();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        transform.Translate(new Vector3(inputMovement.x, inputMovement.y, 0) * speed * Time.deltaTime);
    }

    public void ReduceHealth(int damage)
    
    {
        health -= damage;
    }
}
