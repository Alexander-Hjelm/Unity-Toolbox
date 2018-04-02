using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public static ObjectPool current;
	public GameObject pooledObject;
	public int pooledAmount = 1;
	public bool willGrow = true; 	//dynamicly sized pool or not?
	private GameObject temporary_target;
	
	List<GameObject> pooledObjects;
	
	void Awake()
	{
		current = this; 	//setting up static reference
	}
	
	void Start () {
		pooledObjects = new List<GameObject>();
		for(int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add (obj);
		}
	}
	
	public GameObject GetAvailablePooledObject ()
	{
		for(int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		
		if(willGrow)	//if no available instaqnce was found
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}
		
		return null;	// No available Pooled object
	}

	public void PlaceTarget(Vector3 position)
	{
		temporary_target = GetAvailablePooledObject ();
		temporary_target.transform.position = position;
		temporary_target.SetActive(true);
	}
}
