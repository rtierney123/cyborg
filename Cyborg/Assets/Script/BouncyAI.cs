using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BouncyAI : Attack
    {
        public Transform player;
        public int bounceAmt;
        public int amplitude;
        public int period;
        enum travelDir {x, y};

        private float time;
        private Vector2 dirtoPlayer;
        //distance to midline
        private float currAmp;
        //current direction of line
        private float currDir;
        //previous direction of line
        private float prevDir;
        //spring to alter when bouncing
        private Transform spring;
        //vector to be returned from move
        private Vector2 moveVector;
        private SpriteRenderer m_SpriteRenderer;
        //integer used to alter redness of sprite renderer
        
        private Color m_NewColor;
        private Color origColor;
        private void Start()
        {
            spring = transform.GetChild(0);
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            origColor = m_SpriteRenderer.color;
            if (spring == null)
            {
                Debug.Log("Have to have spring attached to bouncy alien");
            }
            player = GameObject.Find("Player").transform;
        }

        public override Vector2 move(Vector2 tan)
        {
            time = Time.time;
            dirtoPlayer = player.position - transform.position;
            currAmp = 5 * Mathf.Sin(5 * time);
            if (Mathf.Abs(dirtoPlayer.x) > Mathf.Abs(dirtoPlayer.y)) { 

                currDir = (int)travelDir.x;
                moveVector = new Vector2(amplitude * tan.x, currAmp);

            }
            else {

                currDir = (int)travelDir.y;
                moveVector = new Vector2(currAmp, amplitude * tan.y);

            }
        
            return getSpeed() * moveVector;

        }
         public override void attack()
        {

        }

        public override void updateSprites()
        {
            

            if (currAmp < 0)
            {
                spring.localScale -= new Vector3(0, bounceAmt, 0) * Time.deltaTime;

                if (currAmp <= -amplitude+.1)
                {
                    AdjustColor();
                }
                


            } else
            {
                spring.localScale += new Vector3(0, bounceAmt, 0) * Time.deltaTime;
 
            }
            
        }

        private void AdjustColor()
        {
            Vector3 colorArray = new Vector3(255, 105, 105);
            colorArray = colorArray.normalized;
            m_NewColor = new Color(colorArray.x, colorArray.y, colorArray.z);
            m_SpriteRenderer.color = m_NewColor;
            Invoke("ReturnColor", (float).5);
        }

        private void ReturnColor()
        {
            m_SpriteRenderer.color = origColor;
        }

        private void ChangeDir()
        {
            if (currDir == (int) travelDir.x)
            {
                currDir = (int)travelDir.y;
            } 
            else
            {
                currDir = (int)travelDir.x;
            }

        }
    }
}

