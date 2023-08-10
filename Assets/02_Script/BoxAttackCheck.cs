using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxAttackCheck : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private float dissolveTime = 0.75f;

    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Material material;

    private int dissolveAmount = Shader.PropertyToID("_DissolveAmount");

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
    }

    private IEnumerator Vanish()
    {
        float elapsedTime = 0f;
        while(elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0f, 1f, (elapsedTime / dissolveTime));
            material.SetFloat(dissolveAmount, lerpedDissolve);

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ShowProcess()
    {
        Material mat = spriteRenderer.material;

        DOTween.To(() => mat.GetFloat(dissolveAmount),
            value => mat.SetFloat(dissolveAmount, value), 1f, dissolveTime)
            .SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collider.enabled = false;
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.9f);

            StartCoroutine(ShowProcess());

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
