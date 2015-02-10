﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    class Enemy : Sprite
    {
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        protected float startHealth;
        protected float currentHealth;
        protected bool isAlive = true;
        protected float speed = 0.5f;
        protected int bountyGiven;

        public Enemy(Texture2D texture, Vector2 position, float health, int bountyGiven, float speed)
            : base(texture, position)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.bountyGiven = bountyGiven;
            this.speed = speed;
        }

        public void SetWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            this.position = this.waypoints.Dequeue();
        }
        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }
        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public bool IsDead
        {
            get { return currentHealth <= 0; }
        }

        public int BountyGiven
        {
            get { return bountyGiven; }
        }

 

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < speed)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();

                    velocity = Vector2.Multiply(direction, speed);

                    position += velocity;
                }
            }

            else
                isAlive = false;

            if (currentHealth <= 0)
                isAlive = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                float healthPercentage = (float)currentHealth / (float)startHealth;

                Color color = new Color(new Vector3(1 - healthPercentage,
                    1 - healthPercentage, 1 - healthPercentage));

                base.Draw(spriteBatch, color);
            }
        }
    }
}
