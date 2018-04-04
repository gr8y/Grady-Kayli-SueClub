using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Information Classes hold some sort of Information in Game. 
/// Non Actor Classes should Inherit from here. 
/// </summary>
public class Info : MonoBehaviour
{
    /// <summary>
    /// Factory Function for new Actor Game Objects
    /// </summary>
    /// <param name="ActorPrefab">Which Prefab to spawn</param>
    /// <param name="Location">Vector3. Global Space Position</param>
    /// <param name="Rotation">Quaternion. Global Space Rotation</param>
    /// <param name="NewOwner">Optional Controller if needed to attach player information</param>
    /// <returns></returns>
    public static GameObject Factory(GameObject ActorPrefab, Vector3 Location, Quaternion Rotation, Controller NewOwner = null)
    {
        GameObject NewActor = Instantiate(ActorPrefab, Location, Rotation);
        if (NewActor)
        {
            Actor actor = NewActor.GetComponent<Actor>();
            if (actor)
            {
                actor.Owner = NewOwner;
            }
        }

        return NewActor;
    }

    /// <summary>
    /// Property, Easy Access to Get\Set gameObject.name
    /// </summary>
    public string Name
    {
        get { return gameObject.name; }
        set { gameObject.name = value; }
    }

    /// <summary>
    /// Convience Property, Gets Location as a Vector3 from the Game Object this script is on
    /// </summary>
    public Vector3 Location
    {
        get { return gameObject.transform.position; }
    }

    /// <summary>
    /// Convience Property, Gets Rotation as a Quaternion from the Game Object this script is on
    /// </summary>
    public Quaternion Rotation
    {
        get { return gameObject.transform.rotation; }
    }

    /// <summary>
    /// Convience Property, Gets the Transform property from the Game Object this script is on
    /// </summary>
    public Transform Transform
    {
        get { return gameObject.transform; }
    }

    /// <summary>
    /// Static Log Method
    /// </summary>
    /// <param name="s">String, Logged Text</param>
    public static void sLOG(string s)
    {
        Debug.Log(s);
    }

    public virtual void LOG(string s)
    {
        Debug.Log(s);
    }

   

    public void LOG_ERROR(string s)
    {
        Debug.LogError(s);
    }

}
