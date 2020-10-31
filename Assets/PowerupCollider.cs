using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollider : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement = null;
    [SerializeField] GameObject oldTrail = null;
    [SerializeField] GameObject newTrail = null;
    [SerializeField] ParticleSystem gainedParticles = null;
    [SerializeField] ChipsShoot chipsShoot = null;
    [SerializeField] AudioClip collected = null;

    public float _candyTime = 5;
    Gradient gradient = new Gradient();

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        //setGradient();
    }

    /*
    void setGradient()
    {
        Color pink = new Color(229, 43, 80);
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(pink, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(0.3f, 1.0f) }
        );
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Powerups"))
        {
            if (collision.CompareTag("Candy")) //if candy was collided with
            {
                Debug.Log("Got Candy!");
                //give candy powerup

                AudioHelper.PlayClip2D(collected, 2);
                StartCoroutine(CandyPowerup());

                collision.gameObject.SetActive(false);
                
            }

            if (collision.CompareTag("Soda")) //if candy was collided with
            {
                Debug.Log("Got Soda");
                //give soda powerup

                StartCoroutine(SodaPowerup());
                AudioHelper.PlayClip2D(collected, 2);
                collision.gameObject.SetActive(false);
            }

            if (collision.CompareTag("Chips")) //if candy was collided with
            {
                Debug.Log("Got Chips");
                //give chips powerup

                StartCoroutine(ChipsPowerup());
                AudioHelper.PlayClip2D(collected, 2);
                collision.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator CandyPowerup()
    {
        playerMovement._moveSpeed *= 1.5f;
        gainedParticles.Play();
        oldTrail.SetActive(false);
        newTrail.SetActive(true);
        //visual feedback
        //audio feedback

        yield return new WaitForSeconds(_candyTime);

        playerMovement._moveSpeed /= 1.5f;
        gainedParticles.Stop();
        oldTrail.SetActive(true);
        newTrail.SetActive(false);

    }

    IEnumerator SodaPowerup()
    {
        //LAUREN: [ADD TIME]

        //visual feedback (maybe show on UI how much time gained?)
        gainedParticles.Play();

        //audio feedback

        yield return new WaitForSeconds(0.1f);

        gainedParticles.Stop();

    }

    IEnumerator ChipsPowerup()
    {
        //NOW THE HARD ONE
        chipsShoot.canShoot = true;

        //visual feedback (maybe show on UI how much time gained?)
        gainedParticles.Play();

        //audio feedback

        yield return new WaitForSeconds(0.1f);

        gainedParticles.Stop();

    }
}
