using UnityEngine;

public class SimpleEnemyBot : MonoBehaviour
{
    public CardScriptableObject[] cards;

    public Collider spawnArea;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 6f);
    }

    void SpawnEnemy()
    {
        int randomNB = Random.Range(0, cards.Length);

        var card = cards[randomNB];

        Vector3 spawnPos =
            new Vector3(Random
                    .Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                1,
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));
        GameObject newUnit =
            Instantiate(card.unit.unitPrefab, spawnPos, Quaternion.identity);

        newUnit.GetComponent<UnitBase>().unitData = card.unit;

        newUnit.GetComponent<UnitBase>().isPlayer = false;
    }
}
