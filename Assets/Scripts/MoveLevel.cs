using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    [SerializeField] private float _velocity = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _velocity * Time.deltaTime;
    }
}