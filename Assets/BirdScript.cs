using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D thisRigitBody;
    public LogicManagerScript logic;
    public float flapStrength;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Flapping Bird";
        this.thisRigitBody.gameObject.SetActive(true);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive) {
            // because pysics runs on it's clock we don't need time delta here
            thisRigitBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
