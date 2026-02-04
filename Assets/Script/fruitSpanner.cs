using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitSpanner : MonoBehaviour
{

    [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private BoxCollider2D bd;
    [SerializeField] private GameObject targetPrefeb;
    public float timer;
    public float cooldown;

    private int fruitFall = 0;
    private int fruitMilestone = 6;

   
    void Start()
    {
        timer = cooldown;
    }

  
    void Update()
    {
        timer -= Time.deltaTime;
        if( timer <= 0)
        {
            fruitFall++;
            
            if(fruitFall > fruitMilestone && cooldown>0.5f)
            {
                fruitMilestone += 10;
                cooldown = Mathf.Max(0.6f, cooldown - 0.23f);
            }

                GameObject newTarget = Instantiate(targetPrefeb);

                float randomX = Random.Range(bd.bounds.min.x, bd.bounds.max.x);
                newTarget.transform.position = new Vector2(randomX, transform.position.y);
                int randomIndex = Random.Range(0, targetSprite.Length);
                newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[randomIndex];
            timer = cooldown;

            }
    }
}
