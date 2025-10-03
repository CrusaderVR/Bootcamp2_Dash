using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DodgeRoll : MonoBehaviour
{
    private Movement2D move;
    bool roll = false;
    public int coolDownTime = 3;
    [SerializeField] float boost = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("rightClick");

            if (!roll)
            {
                Debug.Log("Roll was false");
                roll = true;
                Dodge();
            }
        }
    }

    void Dodge()
    {
        move.Dodger(boost);
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.1f);

        float Sd = boost - (boost * 2);

        move.Dodger(Sd);
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(coolDownTime);

        roll = false;
    }
}
