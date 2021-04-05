using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogOfWar : MonoBehaviour
{
    SpriteRenderer[] renderers;
    BoxCollider2D[] colliders;
    RoomManager roomManager;

    [SerializeField]
    [Tooltip("Whether or not the room has been explored.\nIf this is the starting room, check this.\nOtherwise, you should not edit this")]
    private bool explored;

    [Tooltip("Manually Click And Drag All Enemies In Room Into This List")]
    [SerializeField]
    //private List<GameObject> enemies;
    public List<Enemy> enemies;

    private enum roomType { None, Corridoor, Room};
    [Header("Read Only")]
    [Tooltip("Whether the room is a corridoor or just a room")]
    [SerializeField]
    private roomType type = roomType.None;

    [Tooltip("The area compound area of the room")]
    [SerializeField]
    private float size;

    [Header("Only Edit In Prefab")]
    [Tooltip("Used to calculate if a room is a corridoor or not.\nIf the width is X times longer/shorter than the height,\nit's a corridoor!")]
    [SerializeField]
    private float corridoorRatio;

    [Tooltip("The opacity of the blue room filter in the editor window")]
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float gizmoOpacity;

    [Tooltip("The opacity of the unexplored areas")]
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float darknessOpacity;

    [Tooltip("How fast rooms fade from black.")]
    [SerializeField]
    private float darknessOpacitySpeed;

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        roomManager = transform.parent.GetComponent<RoomManager>();
        colliders = GetComponentsInChildren<BoxCollider2D>();

        size = calculateRoomSize();
        type = calculateRoomType();

        if (!explored) // If the room is hidden to the player at the start,
        {
            foreach (Enemy enemy in enemies) // Iterate through each enemy,
            {
                if (enemy != null) enemy.gameObject.SetActive(false); // And deactivate them. This makes them invisible and pauses their AI
            }
        }
        else // If the room is visable to the player at the start, 
        {
            transform.parent.GetComponent<RoomManager>().setCurrentRoom(this); // Assume it is the starting room and set the current room var accordingly
        }
    }

    /// <summary>
    /// Calculates the compound area of the room.
    /// </summary>
    /// <returns>
    /// Returns the area of the room.
    /// </returns>
    private float calculateRoomSize()
    {
        // Note: Each room is likely a compound shape, so each sections area must be calculated individually.
        float total = 0; // Initialise the total counter,
        foreach (Collider2D col in colliders) // For each section of the room,
        {
            total += col.bounds.size.x * col.bounds.size.y; // Increment the total by the area of that section.
        }
        return total; // Return the total
    }

    /// <summary>
    /// Estimates the type of room (corridor or room).
    /// </summary>
    /// <returns>
    /// An enum called 'roomtype'. Either roomType.Corridoor, or roomType.Room.
    /// </returns>
    private roomType calculateRoomType()
    {
        float weight = 0; // Initialise the weight counter.
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>(); // Get all the colliders which make up the room

        foreach (Collider2D col in colliders) // For each collider in the room,
        {
            float w = col.bounds.size.x; // Get the dimensions of the collider
            float h = col.bounds.size.y;

            if (w > corridoorRatio * h || h > corridoorRatio * w) // If the width is longer than the height (or vice versa),
            {
                weight += col.bounds.size.magnitude; // Assume this section is corridoor-like and increment the weight by the size of the room.
                // The bigger the room segment, the greater impact it has on the weight.
            }
            else // If the width and height are quite,
            {
                weight -= col.bounds.size.magnitude; // Assume this section is not a corridoor.
            }
        }

        if (weight > 0) return roomType.Corridoor; // If the weight is greater than 0, assume the whole room is a corridoor,
        else return roomType.Room; // Otherwise, assume it is a room.
    }

    /// <summary>
    /// Getter for the room type.
    /// </summary>
    /// <returns>
    /// The room type, as a string. Either 'Room' or 'Corridoor'
    /// </returns>
    public string getRoomType()
    {
        if (type == roomType.None) throw new System.Exception(name + "'s type is set to 'None'");
        return type.ToString(); 
    }

    /// <summary>
    /// Getter for the room size.
    /// </summary>
    /// <returns>
    /// Returns the area of the room as a float.
    /// </returns>
    public float getRoomSize()
    {
        return size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor) // While running in the editor, update the editor graphics to reflect the room variables.
        {
            // The following is not very efficently programmed, but this is not a problem since it is only run in the editor, not the build

            size = calculateRoomSize(); // Update the room size,
            type = calculateRoomType(); // And the type,

            updateDarkness(); // And the darkness.

            if (explored) // If the explored tick box has been checked, update the visuals to match.
            {
                explore();
            }
            else // Otherwise, 
            {
                foreach (SpriteRenderer renderer in renderers) // Iterate through each renderer in the room,
                {
                    renderer.enabled = true; // And ensure they are enabled.
                }
            }
        }

        foreach (BoxCollider2D col in colliders)
        {
            if (col.bounds.Contains(GameObject.FindGameObjectWithTag("Player").transform.position))
            {
                if (!explored) explore(); // If the room has not been explored, explore it (remove the fog and enable the enemies),
                if (roomManager.getCurrentRoom() != gameObject) roomManager.setCurrentRoom(this); // And set the current room to this one.
                break;
            }
        }
    }

    /// <summary>
    /// Updates the opacity of the fog of war. This is only called in the editor.
    /// </summary>
    private void updateDarkness()
    {
        foreach (SpriteRenderer rend in renderers) // For each renderer which makes up the room, 
        {
            Color new_darkness = rend.color; // Get the colour of the renderer,
            new_darkness.a = darknessOpacity; // Update its opacity to match the equivilent variable,
            rend.color = new_darkness; // And set the colour to this new value.
        }
    }

    /// <summary>
    /// Draws the rooms in the editor to make editing easier.
    /// </summary>
    private void OnDrawGizmos()
    {
        foreach (Transform child in transform) // For each room segment,
        {
            Gizmos.color = new Color(0.0f, 0.0f, 1.0f, gizmoOpacity/4); // Set the gizmo colour to a transparent blue
            Gizmos.DrawCube(child.position, child.transform.localScale); // And fill the insides of the rooms with this colour.
            Gizmos.color = new Color(0.0f, 0.0f, 1.0f, gizmoOpacity); // Set the gizmo colour to a opaque blue,
            Gizmos.DrawWireCube(child.position, child.transform.localScale); // And draw a box around each room segment.
        }
    }

    /// <summary>
    /// Removes the fog of war from this room and enables the AI of the enemies present.
    /// </summary>
    void explore()
    {
        explored = true; 
        foreach (Enemy enemy in enemies) // For each enemy which starts in the room,
        {
            if (enemy != null) enemy.gameObject.SetActive(true); // Activate it.
        }

        StartCoroutine(decreaseOpacity()); // Begin the coroutine to remove the fog of war effect.
    }

    /// <summary>
    /// Coroutine to fade the room opacity.
    /// </summary>
    private IEnumerator decreaseOpacity()
    {
        for (float i = renderers[0].color.a; i >= 0; i -= darknessOpacitySpeed * Time.deltaTime) // Repeat many times for a smooth fade,
        {
            foreach (SpriteRenderer renderer in renderers) // For each renderer in the room,
            {
                Color new_color = renderer.color; // Get its colour,
                new_color.a = i; // Reduce its opacity,
                renderer.color = new_color; // Update the colour with our new one,
                if (renderer.color.a <= 0.05f) renderer.enabled = false; // If it is practically invisible, deactivate the renderer.
            }
            yield return null;
        }
    }
}
