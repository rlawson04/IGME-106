﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW_2_MonoGame
{
    internal class Player : GameObject
    {
        // -----------------------------------
        // Fields
        // -----------------------------------

        protected int levelScore;
        protected int totalScore;
        protected int windowWidth;
        protected int windowHeight;

        // -----------------------------------
        // Properties
        // -----------------------------------

        public int LevelScore
        {
            get { return levelScore; }
        }

        public int TotalScore
        {
            get { return totalScore; }
        }
        // -----------------------------------
        // Constructors
        // -----------------------------------

        public Player(Texture2D texture, Rectangle rectangle, int levelScore,
            int totalScore, int windowWidth, int windowHeight) 
            : base(texture, rectangle)
        {
            this.levelScore = levelScore;
            this.totalScore = totalScore;
            this.windowWidth = windowWidth; 
            this.windowHeight = windowHeight;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------
    }
}
