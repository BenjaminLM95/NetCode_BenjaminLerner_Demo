using UnityEngine;

public class Parenting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BecomeAChild(Transform _transform) 
    {
        this.transform.SetParent(_transform);
    }

    public void BecomeIndependient() 
    {
        this.transform.SetParent(null); 
    }
}
