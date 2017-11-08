using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game9.Buttons;
using Game9.Model;
using Game9.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game9.States
{
    class GameState3 : State
    {
        public List<Sprite> _sprites;
        private List<Component> _component;

        public List<SecurityGuard> securityGuard;

        public Texture2D Screen;
        public Texture2D MoneyScores;

        public Vector2 screenPosition = new Vector2(0, 0);
        public Vector2 MoneyScoresPosition = new Vector2(-30, -80);
        Vector2 positionScores = new Vector2(20, 30);


        SpriteBatch spriteBatch;

        public State _currentState;
        public State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public SpriteFont _font;


        public GameState3(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _font = this._content.Load<SpriteFont>("Fonts/FontScores");
            MoneyScores = this._content.Load<Texture2D>("Money/MoneyScores/MoneyScores");



            Screen = this._content.Load<Texture2D>("Screen/Screen3");
            //player
            var animetion = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Player/WalkingUp"), 3)},
                { "WalkDown", new Animation(_content.Load<Texture2D>("Player/WalkingDown"), 3) },
                { "WalkLeft", new Animation(_content.Load<Texture2D>("Player/WalkingLeft"), 3)},
                { "WalkRight", new Animation(_content.Load<Texture2D>("Player/WalkingRight"), 3)},
            };
            //
            //guard
            var animetionGuard = new Dictionary<string, Animation1>()
            {
                { "WalkUp", new Animation1(_content.Load<Texture2D>("SecurityGuard/WalkingUp"), 3)},
                { "WalkDown", new Animation1(_content.Load<Texture2D>("SecurityGuard/WalkingDown"), 3) },
                { "WalkLeft", new Animation1(_content.Load<Texture2D>("SecurityGuard/WalkingLeft"), 3)},
                { "WalkRight", new Animation1(_content.Load<Texture2D>("SecurityGuard/WalkingRight"), 3)},
            };
            //
            // wall
            var wall = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/1"), 1)},
            };
            var wall2 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/2"), 1)},
            };
            var wall3 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/3"), 1)},
            };
            var wall4 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/4"), 1)},
            };
            var wall5 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/5"), 1)},
            };
            var wall6 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/6"), 1)},
            };
            var wall7 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/7"), 1)},
            };
            var wall8 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/8"), 1)},
            };

            var wall9 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/9"), 1)},
            };
            var wall10 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/10"), 1)},
            };
            var wall13 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/13"), 1)},
            };
            var wall14 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/14"), 1)},
            };
            var wall15 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/15"), 1)},
            };
            var wall16 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/16"), 1)},
            };
            var wall17 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/17"), 1)},
            };
            var wall18 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/18"), 1)},
            };
            var wall19 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState3/19"), 1)},
            };

            //
            //money
            var Money = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Money/Money"), 1)},
            };
            //
            _sprites = new List<Sprite>()
            {
                //Money
                /*new Sprite(Money)
                {
                    chacktype = "money",
                    Position = new Vector2(310, 140),
                    Input = new Input()
                    {
                    },
                },*/
                //
                //wall

                new Sprite(wall)
                {
                    chacktype = "wall",
                    Position = new Vector2(0,450),
                    Input = new Input()
                    {
                    },
                },
                 new Sprite(wall2)
                 {
                     chacktype = "wall",
                     Position = new Vector2(242, 137),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall3)
                 {
                     chacktype = "wall",
                     Position = new Vector2(396, 138),
                     Input = new Input()
                     {
                     },
                 },/*
                 new Sprite(wall4)
                 {
                     chacktype = "wall",
                     Position = new Vector2(502, 807),
                     Input = new Input()
                     {
                     },
                 },*/
                new Sprite(wall5)
                {
                    chacktype = "wall",
                    Position = new Vector2(452, 138),
                    Input = new Input()
                    {
                    },
                },
                new Sprite(wall6)
                {
                    chacktype = "wall",
                    Position = new Vector2(553, 185),
                    Input = new Input()
                    {
                    },
                },/*
            new Sprite(wall7)
            {
                chacktype = "wall",
                Position = new Vector2(606,273),
                Input = new Input()
                {
                },
            },*/
                 new Sprite(wall8)
                 {
                     chacktype = "wall",
                     Position = new Vector2(706,170),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall9)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1225, 230),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall10)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1281, 365),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall13)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1696, 225),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall14)
                 {
                     chacktype = "wall",
                     Position = new Vector2(236,770),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall15)
                 {
                     chacktype = "wall",
                     Position = new Vector2(0, 718),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall16)
                 {
                     chacktype = "wall",
                     Position = new Vector2(964, 453),
                     Input = new Input()
                     {
                     },
                 },

                 new Sprite(wall17)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1022, 541),
                     Input = new Input()
                     {
                     },
                 },
                  new Sprite(wall18)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1018, 590),
                     Input = new Input()
                     {
                     },
                 },
                  new Sprite(wall19)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1381, 590),
                     Input = new Input()
                     {
                     },
                 },
                 //
                new Sprite(animetion)
                {
                Position = new Vector2(0,575),
                Input = new Input()
                {
                    Up = Keys.W,
                    Down = Keys.S,
                    Right = Keys.D,
                    Left = Keys.A,
                    E = Keys.E,
                },
            },

            };

            /*securityGuard = new List<SecurityGuard>()
            {
                new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(475, 500),
                Speed = 0.2f,
                chack = 1,
                Farest = 850,
                Smallest = 470,

                },
            };*/
            //button
            var buttonQuitMenuTexture = _content.Load<Texture2D>("Control/buttonQuitMenu");
            var buttonMenuTexture = _content.Load<Texture2D>("Control/buttomMenu");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var quitGameButton = new Button(buttonQuitMenuTexture, buttonFont)
            {
                Position = new Vector2(1800, 20),
            };
            quitGameButton.Click += quitGameButton_Click;

            var meneGameButton = new Button(buttonMenuTexture, buttonFont)
            {
                Position = new Vector2(1800, 120),
            };
            meneGameButton.Click += MeneGameButton_Click;

            _component = new List<Component>()
            {
                quitGameButton,
                meneGameButton,
            };
            //
        }

        private void MeneGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuToFront(_game, _graphicsDevice, _content));

        }
        public void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }


        public void LoadContent()
        {

        }

        public override void Draw(GameTime GameTime, SpriteBatch spriteBatch)
        {
            

            spriteBatch.Draw(Screen, screenPosition, Color.White);
            spriteBatch.Draw(MoneyScores, MoneyScoresPosition, Color.White);
            foreach (var sprite in _sprites)
            {
                spriteBatch.DrawString(_font, "         " + Convert.ToString(sprite.Scores), positionScores, Color.Green);

                sprite.Draw(spriteBatch);
                //foreach (var securityGuards in securityGuard)
                //securityGuards.Draw(GameTime, _sprites);

            }
            /*
            if (MyGlobals.Over == "Over")
            {
                //add backgroud
                _currentState.Draw(GameTime, spriteBatch);
            }*/
            foreach (var component in _component)
                component.Draw(GameTime, spriteBatch);

        }

        public override void PostUpdate(GameTime gameTime)
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].isRemoved)
                {
                    _sprites.RemoveAt(i);
                }
            }

        }

        public override void Update(GameTime game)
        {
            foreach (var component in _component)
                component.Update(game);
            MyGlobals.retry = 2;
            foreach (var sprite in _sprites)
            {
                sprite.Update(game, _sprites);
                //foreach (var securityGuards in securityGuard)
                   // securityGuards.Update(game, _sprites);


            }

            /*
            if (MyGlobals.Over == "Over")
            {
                _currentState.Update(game);
                foreach (var sprite in _sprites)
                {
                    sprite.isRemoved = true;

                }
            }*/
            PostUpdate(game);
        }
    }
}