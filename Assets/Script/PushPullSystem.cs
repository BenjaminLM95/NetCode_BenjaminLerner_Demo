using TMPro;
using UnityEngine;

public class PushPullSystem : MonoBehaviour
{
    [SerializeField] private GameObject movableObj = null;

    [Header("Raycast Settings")]
    public float rayDistance = 1.5f;       // How far the ray should go
    public LayerMask movableMask;           // Layers to detect (set in Inspector)


    [Header("References")]
    public TextMeshPro actionPrompt;

    bool isMoving = false;

    private void Awake()
    {        
        if(actionPrompt == null) 
        {
            actionPrompt = GameObject.Find("ActionPrompt").GetComponent<TextMeshPro>();
            actionPrompt.gameObject.SetActive(false); 
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMoving = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Perform the raycast
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, rayDistance, movableMask))
        {
            // Log the name of the object hit
            //Debug.Log("Hit: " + hitInfo.collider.name);

            if (movableObj == null)
            {
                movableObj = hitInfo.collider.gameObject;
                actionPrompt.gameObject.SetActive(true);              
            }


        }
        else
        {
            if (movableObj != null)
            {
                movableObj = null;
                actionPrompt.gameObject.SetActive(false);
            }
        }

        if(movableObj != null) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (!isMoving)
                {
                    //movableObj.transform.SetParent(transform);
                    // TODO: Make the object child of the player from the cube object

                    movableObj.GetComponent<Parenting>().BecomeAChild(transform); 

                    isMoving = true;
                }
                else 
                {
                    //movableObj.transform.SetParent(null);
                    // TODO: Make the object free from the player from the cube object

                    movableObj.GetComponent<Parenting>().BecomeIndependient(); 
                    isMoving = false; 
                }
            }
        }

        if (actionPrompt.gameObject.activeSelf) 
        {
            if (isMoving)
            {
                actionPrompt.text = "Press 'E' to release the cube";
            }
            else
            {
                actionPrompt.text = "Press 'E' to grab the cube";
            }
        }

    }


}
