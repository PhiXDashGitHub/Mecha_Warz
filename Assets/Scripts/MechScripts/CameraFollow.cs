using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraFollow : MonoBehaviour {

	bool playerFound;

	void Start()
	{
		playerFound = false;
	}

	void Update()
	{
		if (FindObjectOfType<PlayerStats>() && !playerFound)
		{
			ConstraintSource source = new ConstraintSource();
			source.weight = 1;
			source.sourceTransform = FindObjectOfType<PlayerStats>().transform;

			GetComponent<PositionConstraint>().AddSource(source);
			GetComponent<PositionConstraint>().constraintActive = true;
			playerFound = true;
		}
	}
}
