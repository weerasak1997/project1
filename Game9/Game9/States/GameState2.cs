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
    class GameState2 : State
    {
        public List<Sprite> _sprites;
        private List<Component> _component;
        public GameState1 game1;

        public Texture2D Screen;
        public Texture2D MoneyScores;

        public Vector2 screenPosition = new Vector2(0, 0);
        public Vector2 MoneyScoresPosition = new Vector2(-30, -80);
        Vector2 positionScores = new Vector2(20, 30);

        public List<SecurityGuard> securityGuard;

        public SpriteBatch spriteBatch;

        public State _currentState;
        public State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public SpriteFont _font;


        public GameState2(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _font = this._content.Load<SpriteFont>("Fonts/FontScores");
            MoneyScores = this._content.Load<Texture2D>("Money/MoneyScores/MoneyScores");



            // Screen = this._content.Load<Texture2D>("Screen/Screen2");
            Screen = this._content.Load<Texture2D>("SecurityWay/SecurityWay2");
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
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/1"), 1)},
            };
            var wall2 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/2"), 1)},
            };
            var wall3 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/3"), 1)},
            };
            var wall4 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/4"), 1)},
            };
            var wall5 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/5"), 1)},
            };
            var wall6 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/6"), 1)},
            };
            var wall7 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/7"), 1)},
            };
            var wall8 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/8"), 1)},
            };

            var wall9 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/9"), 1)},
            };
            var wall10 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/10"), 1)},
            };
            var wall11 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/11"), 1)},
            };
            var wall12 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/12"), 1)},
            };
            var wall16 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/16"), 1)},
            };
            var wall17 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState2/17"), 1)},
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
                    Position = new Vector2(347,175),
                    Input = new Input()
                    {
                    },
                },
                 new Sprite(wall2)
                 {
                     chacktype = "wall",
                     Position = new Vector2(399, 172),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall3)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1637, 219),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall4)
                 {
                     chacktype = "wall",
                     Position = new Vector2(502, 807),
                     Input = new Input()
                     {
                     },
                 },
                new Sprite(wall5)
                {
                    chacktype = "wall",
                    Position = new Vector2(498, 1000),
                    Input = new Input()
                    {
                    },
                },
                new Sprite(wall6)
                {
                    chacktype = "wall",
                    Position = new Vector2(399, 398),
                    Input = new Input()
                    {
                    },
                },
            new Sprite(wall7)
            {
                chacktype = "wall",
                Position = new Vector2(665,398),
                Input = new Input()
                {
                },
            },
                 new Sprite(wall8)
                 {
                     chacktype = "wall",
                     Position = new Vector2(706,215),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall9)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1174, 218),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall10)
                 {
                     chacktype = "wall",
                     Position = new Vector2(916, 580),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall11)
                 {
                     chacktype = "wall",
                     Position = new Vector2(812, 357),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall12)
                 {
                     chacktype = "wall",
                     Position = new Vector2(400, 217),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall16)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1125, 540),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall17)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1227, 534),
                     Input = new Input()
                     {
                     },
                 },
                 //
                new Sprite(animetion)
                {
                Position = new Vector2(420,900),
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

            securityGuard = new List<SecurityGuard>()
            {
                new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(475, 500),
                Speed = 0.2f,
                chack = 1,
                Farest = 850,
                Smallest = 470,

                },
            };
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
                foreach (var securityGuards in securityGuard)
                securityGuards.Draw(spriteBatch);

            }
            
            if (MyGlobals.Over == "Over")
            {
                //add backgroud
                _currentState.Draw(GameTime, spriteBatch);
            }
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
                foreach(var securityGuards  in securityGuard)
                securityGuards.Update(game, _sprites);


            }

  
            if (MyGlobals.Over == "Over")
            {
                _currentState.Update(game);
                foreach (var sprite in _sprites)
                {
                    sprite.isRemoved = true;

                }
            }
            PostUpdate(game);
        }
    }
}
