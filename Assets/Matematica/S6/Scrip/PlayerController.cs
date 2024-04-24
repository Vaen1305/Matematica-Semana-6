using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _myRBD;
    [SerializeField] private float velocity;
    [SerializeField] private float rotation = 35f;
    [SerializeField] private TextMeshProUGUI vidaText;

    public int vida = 3;
    private Vector2 _movement;
    private Quaternion q = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;

    private void FixedUpdate()
    {
        _myRBD.velocity = new Vector3(_movement.x, _movement.y, _myRBD.velocity.y);

        if (_movement.x < 0) 
        {
            anguloSen = Mathf.Sin(Mathf.Deg2Rad * rotation * 0.5f);
            anguloCos = Mathf.Cos(Mathf.Deg2Rad * rotation * 0.5f);

            q.Set( 0, 0, anguloSen, anguloCos);

            transform.rotation = q;
        }
        else if (_movement.x > 0)
        {
            anguloSen = Mathf.Sin(Mathf.Deg2Rad * rotation * -0.5f);
            anguloCos = Mathf.Cos(Mathf.Deg2Rad * rotation * -0.5f);

            q.Set(0, 0, anguloSen, anguloCos);

            transform.rotation = q;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            vida--;
            vidaText.text = "Vida: " + vida;

            if (vida <= 0)
            {
                Debug.Log("Game Over");
                Destroy(this);
            }
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() * velocity;
    }
}
