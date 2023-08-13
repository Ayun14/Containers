using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxAttackCheck : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private float dissolveTime = 1.7f;

    private SpriteRenderer spriteRenderer;

    private int dissolveAmount = Shader.PropertyToID("_DissolveAmount");

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator ShowProcess()
    {
        Material mat = spriteRenderer.material;

        DOTween.To(() => mat.GetFloat(dissolveAmount),
            value => mat.SetFloat(dissolveAmount, value), 1f, dissolveTime);

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 0.8f);

            StartCoroutine(ShowProcess());

            Destroy(collision.gameObject);
            Destroy(gameObject, dissolveTime);
        }
    }
}
