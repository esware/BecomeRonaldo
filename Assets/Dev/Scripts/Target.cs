using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	
	public OptionsList addScore;
	public enum OptionsList{
	NinetyPoints, 
	SixtyPoints,
	ThirtyPoints,
	TenPoints
	}
	
	public ParticleSystem effect1;
	public ParticleSystem effect2;
	public ParticleSystem effect3;
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.CompareTag("Ball"))
		{
			if(addScore == OptionsList.NinetyPoints)
			{
				StartCoroutine(CreateAndDestroy(effect1,other));

			}
			if(addScore == OptionsList.SixtyPoints)
			{
				StartCoroutine(CreateAndDestroy(effect2,other));
			}
			if(addScore == OptionsList.ThirtyPoints)
			{
				StartCoroutine(CreateAndDestroy(effect3,other));
			}
			if(addScore == OptionsList.TenPoints)
			{
				//Soccer.score += 10;
			}
		}
	}

	IEnumerator CreateAndDestroy(ParticleSystem effect , Collider other)
	{
		var ef = Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
		yield return new WaitForSecondsRealtime(0.5f);
		Destroy(ef.gameObject);
	}
}
