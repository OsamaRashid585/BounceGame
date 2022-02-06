using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _min, _max;
    private Rigidbody rb;

    private Vector3 _maxScaleR,_minScaleL;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _maxScaleR = new Vector3(_min, _max,0.5f);
        _minScaleL = new Vector3(_max, _min,0.5f);
    }

    void Update()
    {
        PlayerController();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,_speed * Time.deltaTime);
    }
    private void PlayerController()
    {
        if (Input.GetKey(KeyCode.Mouse0) && transform.localScale != _maxScaleR)
        {
            transform.localScale += new Vector3(0f, _scaleSpeed, 0f);
            transform.localScale -= new Vector3(_scaleSpeed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.Mouse1) && transform.localScale != _minScaleL)
        {
            transform.localScale -= new Vector3(0f, _scaleSpeed, 0f);
            transform.localScale += new Vector3(_scaleSpeed, 0f, 0f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Object")
        {
            Debug.Log("Point");
        }
    }

}