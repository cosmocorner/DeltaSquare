using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public 

    Vector2 StartPos;
    bool ViableMove;
    bool InputOpen = true;

    public ParticleSystem EnemyParticles;
    public ParticleSystem CoinSparkle;
    public Transform DeathParticle;

    public GameObject PlayerObj;
    public CameraShake cameraShake;

    public AudioSource CoinSound;
    public AudioSource DeathSound;
    public AudioSource WallHit;
    public AudioSource Portal;
    public AudioSource EnemyHit;
    public AudioSource Jump;
    public AudioSource Rewind;

    private void Start()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;

        //if (PlayerObj == null)
        //{
        //    PlayerObj = GameObject.FindGameObjectWithTag("Player");
        //    PlayerObj.AddComponent<PlayerMovement>();
        //}
    }

    void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (InputOpen)
        {
            StartPos = transform.position;
            ViableMove = false;
            InputOpen = false;

            if (data.Direction == SwipeDirection.Up)
            {
                UpMove();
                Jump.Play();
            }

            if (data.Direction == SwipeDirection.Down)
            {
                DownMove();
                Jump.Play();
            }

            if (data.Direction == SwipeDirection.Left)
            {
                LeftMove();
                Jump.Play();
            }

            if (data.Direction == SwipeDirection.Right)
            {
                RightMove();
                Jump.Play();
            }
        }
    }
    void UpMove()
    {
        print("Up");
        if (!GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingWall && !GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingDeath && !GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingCoin && !GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingEnemy && !GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            StartCoroutine(UpWait(true));
        }
        else if (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingCoin)
        {
            StartCoroutine(UpWait(true));
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            CoinSound.Play();
            Destroy(GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().ColObj);
            ViableMove = true;
            CoinSparkle.Play();
        }
        else if (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingEnemy)
        {
            StartCoroutine(UpWait(true, true));
            Destroy(GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().ColObj);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            EnemyHit.Play();
            ViableMove = true;
            EnemyParticles.Play();
            EndMove();
        }
        else if (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingDeath)
        {
            StartCoroutine(UpWait(true));
            var go = Instantiate(DeathParticle, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            DeathSound.Play();
            Destroy(GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().ColObj);
            gameObject.SetActive(false);
            EndMove();
        }
        else if (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            transform.position = (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().ColObj.GetComponent<Portal>().OppositePortal.transform.position);
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            Portal.Play();
            StartCoroutine(UpWait(false));
        }
        else if (GameObject.Find("UpTrigger").GetComponent<MoveTrigger>().TouchingWall)
        {
            StartCoroutine(cameraShake.Shake(.15f, .1f));
            WallHit.Play();
            EndMove();
        }
    }
    void DownMove()
    {
        print("Down");
        if (!GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingWall && !GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingDeath && !GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingCoin && !GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingEnemy && !GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            StartCoroutine(DownWait(true));
        }
        else if (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingCoin)
        {
            StartCoroutine(DownWait(true));
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            CoinSound.Play();
            Destroy(GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().ColObj);
            ViableMove = true;
            CoinSparkle.Play();
        }
        else if (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingEnemy)
        {
            StartCoroutine(DownWait(true, true));
            Destroy(GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().ColObj);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            EnemyHit.Play();
            ViableMove = true;
            EnemyParticles.Play();
            EndMove();
        }
        else if (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingDeath)
        {
            StartCoroutine(DownWait(true));
            var go = Instantiate(DeathParticle, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            DeathSound.Play();
            Destroy(GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().ColObj);
            gameObject.SetActive(false);
            EndMove();
        }
        else if (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            transform.position = (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().ColObj.GetComponent<Portal>().OppositePortal.transform.position);
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            Portal.Play();
            StartCoroutine(DownWait(false));
        }
        else if (GameObject.Find("DownTrigger").GetComponent<MoveTrigger>().TouchingWall)
        {
            StartCoroutine(cameraShake.Shake(.15f, .1f));
            WallHit.Play();
            EndMove();
        }
    }
    void LeftMove()
    {
        print("Left");
        if (!GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingWall && !GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingDeath && !GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingCoin && !GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingEnemy && !GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            StartCoroutine(LeftWait(true));
        }
        else if (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingCoin)
        {
            StartCoroutine(LeftWait(true));
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            CoinSound.Play();
            Destroy(GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().ColObj);
            ViableMove = true;
            CoinSparkle.Play();
        }
        else if (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingEnemy)
        {
            StartCoroutine(LeftWait(true, true));
            Destroy(GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().ColObj);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            EnemyHit.Play();
            ViableMove = true;
            EnemyParticles.Play();
            EndMove();
        }
        else if (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingDeath)
        {
            StartCoroutine(LeftWait(true));
            var go = Instantiate(DeathParticle, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            DeathSound.Play();
            Destroy(GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().ColObj);
            gameObject.SetActive(false);
            EndMove();
        }
        else if (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            transform.position = (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().ColObj.GetComponent<Portal>().OppositePortal.transform.position);
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            Portal.Play();
            StartCoroutine(LeftWait(false));
        }
        else if (GameObject.Find("LeftTrigger").GetComponent<MoveTrigger>().TouchingWall)
        {
            StartCoroutine(cameraShake.Shake(.15f, .1f));
            WallHit.Play();
            EndMove();
        }
    }
    void RightMove()
    {
        print("Right");
        if (!GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingWall && !GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingDeath && !GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingCoin && !GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingEnemy && !GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            StartCoroutine(RightWait(true));
        }
        else if (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingCoin)
        {
            Destroy(GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().ColObj);
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            CoinSound.Play();
            StartCoroutine(RightWait(true));
            ViableMove = true;
            CoinSparkle.Play();
        }
        else if (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingEnemy)
        {
            StartCoroutine(RightWait(true, true));
            Destroy(GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().ColObj);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            EnemyHit.Play();
            ViableMove = true;
            EnemyParticles.Play();
            EndMove();
        }
        else if (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingDeath)
        {
            StartCoroutine(RightWait(true));
            var go = Instantiate(DeathParticle, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            DeathSound.Play();
            Destroy(GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().ColObj);
            gameObject.SetActive(false);
            EndMove();
        }
        else if (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingPortal)
        {
            transform.position = (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().ColObj.GetComponent<Portal>().OppositePortal.transform.position);
            StartCoroutine(cameraShake.Shake(.1f, .05f));
            Portal.Play();
            StartCoroutine(RightWait(false));
        }
        else if (GameObject.Find("RightTrigger").GetComponent<MoveTrigger>().TouchingWall)
        {
            StartCoroutine(cameraShake.Shake(.15f, .1f));
            WallHit.Play();
            EndMove();
        }
    }
    void EndMove()
    {
        if (!ViableMove)
        {
            transform.position = StartPos;
            Rewind.Play();
        }
        InputOpen = true;
    }
    IEnumerator UpWait(bool move, bool end = false)
    {
        if (move)
        {
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.088125f, 0);
        }
        yield return new WaitForSeconds(0.01f);
        if (end)
        {
            EndMove();
        }
        else
        {
            UpMove();
        }
    }
    IEnumerator DownWait(bool move, bool end = false)
    {
        if (move)
        {
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.088125f, 0);
        }
        yield return new WaitForSeconds(0.01f);
        DownMove();
    }
    IEnumerator LeftWait(bool move, bool end = false)
    {
        if (move)
        {
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.088125f, 0, 0);
        }
        yield return new WaitForSeconds(0.01f);
        if (end)
        {
            EndMove();
        }
        else
        {
            LeftMove();
        }
    }
    IEnumerator RightWait(bool move, bool end = false)
    {
        if (move)
        {
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0.088125f, 0, 0);
        }
        yield return new WaitForSeconds(0.01f);
        if (end)
        {
            EndMove();
        }
        else
        {
            RightMove();
        }
    }
}
