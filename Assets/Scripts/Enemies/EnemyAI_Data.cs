using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyAI_Data : ScriptableObject
{
	public float f_enemySpeed;
	public float f_enemyHealth;
	public float f_enemyDamage;
	public float f_perceptionRadius;
	public float f_moneyPerShot;
	public float f_moneyPerDeath;
}
