using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class ScytheAI : Attack
    {
        private enum State { attacking, moving };
        public enum Direction { up, down, left, right };

        public Sprite[] spritesIdle;
        public Sprite[] spritesAttack;
        public SpriteRenderer spriteRenderer;
        public Sprite[] armSprites;
        public Transform[] armPivots;
        public SpriteRenderer armRenderer;
        public Transform[] armLocations;
        public EdgeCollider2D[] edges;

        public int speed;
        public int range;

        private GameObject target;
        private State state;
        private Direction dir;
        private Direction swingStartDir;
        private float angle;
        private float endAngle;

        public void Start()
        {
            state = State.moving;
            target = GameObject.Find("Player");
            dir = Direction.right;
            swingStartDir = dir;
            angle = 0;
            endAngle = 360;
        }

        public override Vector2 move(Vector2 tan)
        {
            if (state == State.attacking)
            {
                UpdateState();
                return new Vector2();
            }
            setSpeed(speed);
            if (System.Math.Abs(tan.x) > System.Math.Abs(tan.y))
            {
                if (tan.x > 0)
                {
                    dir = Direction.right;
                    swingStartDir = dir;
                    angle = 0;
                }
                else
                {
                    dir = Direction.left;
                    swingStartDir = dir;
                    angle = 45;
                }
            }
            else
            {
                if (tan.y > 0)
                {
                    dir = Direction.up;
                    swingStartDir = dir;
                    angle = 0;
                }
                else
                {
                    dir = Direction.down;
                    swingStartDir = dir;
                    angle = 180;
                }
            }
            UpdateState();
            return getSpeed() * tan;
        }

        private void chooseSwingDir()
        {
            switch(swingStartDir)
            {
                case Direction.up:
                    if ((angle % 360 >= 0 && angle % 360 < -1) || (angle % 360 >= 270 && angle % 360 < 360))
                    {
                        dir = Direction.right;
                    }
                    else if (angle % 360 >= 0 && angle % 360 < 135)
                    {
                        dir = Direction.up;
                    }
                    else if (angle % 360 >= 135 && angle % 360 < 235)
                    {
                        dir = Direction.left;
                    }
                    else
                    {
                        dir = Direction.down;
                    }
                    break;
                case Direction.right:
                    if ((angle % 360 >= 0 && angle % 360 < 135) || (angle % 360 >= 270 && angle % 360 < 360))
                    {
                        dir = Direction.right;
                    }
                    else if (angle % 360 >= 136 && angle % 360 < 135)
                    {
                        dir = Direction.up;
                    }
                    else if (angle % 360 >= 135 && angle % 360 < 235)
                    {
                        dir = Direction.left;
                    }
                    else
                    {
                        dir = Direction.down;
                    }
                    break;
                case Direction.down:
                    if ((angle % 360 >= 0 && angle % 360 < 80) || (angle % 360 >= 315 && angle % 360 < 360))
                    {
                        dir = Direction.right;
                    }
                    else if (angle % 360 >= 80 && angle % 360 < 170)
                    {
                        dir = Direction.up;
                    }
                    else if (angle % 360 >= 170 && angle % 360 < 210)
                    {
                        dir = Direction.left;
                    }
                    else
                    {
                        dir = Direction.down;
                    }
                    break;
                case Direction.left:
                    if ((angle % 360 >= 0 && angle % 360 < 45) || (angle % 360 >= 315 && angle % 360 < 360))
                    {
                        dir = Direction.right;
                    }
                    else if (angle % 360 >= 0 && angle % 360 < 45)
                    {
                        dir = Direction.up;
                    }
                    else if (angle % 360 >= 45 && angle % 360 < 235)
                    {
                        dir = Direction.left;
                    }
                    else
                    {
                        dir = Direction.down;
                    }
                    break;
            }
        }

        public override void updateSprites()
        {
            if (state == State.attacking)
            {
                chooseSwingDir();
                armRenderer.enabled = true;
                switch (dir)
                {
                    case Direction.up:
                        spriteRenderer.sprite = spritesAttack[0];
                        spriteRenderer.flipX = false;
                        armRenderer.sprite = armSprites[0];
                        armRenderer.flipX = false;
                        armRenderer.sortingLayerName = "wall";
                        armRenderer.transform.position = armLocations[0].position;
                        armRenderer.transform.rotation = armLocations[0].rotation;
                        armRenderer.transform.RotateAround(armPivots[0].position, Vector3.forward, angle);
                        break;
                    case Direction.right:
                        spriteRenderer.sprite = spritesAttack[1];
                        spriteRenderer.flipX = false;
                        armRenderer.sprite = armSprites[1];
                        armRenderer.flipX = false;
                        armRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
                        armRenderer.transform.position = armLocations[1].position;
                        armRenderer.transform.rotation = armLocations[1].rotation;
                        armRenderer.transform.RotateAround(armPivots[1].position, Vector3.forward, angle);
                        break;
                    case Direction.down:
                        spriteRenderer.sprite = spritesAttack[2];
                        spriteRenderer.flipX = false;
                        armRenderer.sprite = armSprites[2];
                        armRenderer.flipX = false;
                        armRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
                        armRenderer.transform.position = armLocations[2].position;
                        armRenderer.transform.rotation = armLocations[2].rotation;
                        armRenderer.transform.RotateAround(armPivots[2].position, Vector3.forward, angle);
                        break;
                    case Direction.left:
                        spriteRenderer.sprite = spritesAttack[1];
                        spriteRenderer.flipX = true;
                        armRenderer.sprite = armSprites[1];
                        armRenderer.flipX = true;
                        armRenderer.sortingLayerName = "wall";
                        armRenderer.transform.position = armLocations[3].position;
                        armRenderer.transform.rotation = armLocations[3].rotation;
                        armRenderer.transform.RotateAround(armPivots[3].position, Vector3.forward, angle);
                        break;
                }
            } else if (state == State.moving)
            {
                switch (dir)
                {
                    case Direction.up:
                        armRenderer.enabled = false;
                        spriteRenderer.sprite = spritesIdle[0];
                        spriteRenderer.flipX = false;
                        break;
                    case Direction.right:
                        armRenderer.enabled = false;
                        spriteRenderer.sprite = spritesIdle[1];
                        spriteRenderer.flipX = false;
                        break;
                    case Direction.down:
                        armRenderer.enabled = false;
                        spriteRenderer.sprite = spritesIdle[2];
                        spriteRenderer.flipX = false;
                        break;
                    case Direction.left:
                        armRenderer.enabled = false;
                        spriteRenderer.sprite = spritesIdle[1];
                        spriteRenderer.flipX = true;
                        break;
                }
            }
        }

        public override void attack()
        {
            
        }

        private void UpdateState()
        {
            if (state == State.moving)
            {
                if ((transform.position - target.transform.position).magnitude <= range)
                {
                    state = State.attacking;
                    endAngle = angle + 270;
                }
            }
            else if (state == State.attacking)
            {
                if (angle >= endAngle)
                {
                    state = State.moving;
                    if ((transform.position - target.transform.position).magnitude <= range)
                    {
                        state = State.attacking;
                        endAngle = angle + 270;
                    }
                } else
                {
                    angle += 180 * Time.deltaTime;
                }
            }
        }
    }
}