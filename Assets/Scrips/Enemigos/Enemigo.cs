using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
	[SerializeField] private float vida;

	public void TomarDa�o(float da�o)
	{
		vida -= da�o;
		if (vida <= 0)
		{
			Muerte();
		}
	}

	private void Muerte()
	{
		Destroy(this.gameObject);
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.Instance.PerderVida();
		}
	}
}
