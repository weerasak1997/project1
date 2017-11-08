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
    class GameState1: State
    {
        public List<Sprite> _sprites;
        private List<Component> _component;
        public Texture2D Screen;
        public Texture2D MoneyScores;

        public List<SecurityGuard> securityGuard;

        public Vector2 screenPosition = new Vector2(200,300);
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

        public GameState1(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {


            _font = this._content.Load<SpriteFont>("Fonts/FontScores");
            MoneyScores = this._content.Load<Texture2D>("Money/MoneyScores/MoneyScores");


            _currentState = new StateOver(_game, _graphicsDevice, _content);
            Screen = this._content.Load<Texture2D>("Screen/ScreenState1");
            //Screen = this._content.Load<Texture2D>("SecurityWay/SecurityWay1");
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
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/1"), 1)},
            };
            var wall2 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/2"), 1)},
            };
            var wall3 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/3"), 1)},
            };
            var wall4 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/4"), 1)},
            };
            var wall6 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/6"), 1)},
            };
            var wall7 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/7"), 1)},
            };
            var wall8 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/8"), 1)},
            };

            var wall9 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(_content.Load<Texture2D>("Screen/ScreenState1/9"), 1)},
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
                new Sprite(Money)
                {
                    chacktype = "money",
                    Position = new Vector2(310, 140),
                    Input = new Input()
                    {
                    },
                },
                //
                //wall

                new Sprite(wall9)
                {
                    chacktype = "wall",
                    Position = new Vector2(991, 425),
                    Input = new Input()
                    {
                    },
                },
                 new Sprite(wall8)
                 {
                     chacktype = "wall",
                     Position = new Vector2(991, 502),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall7)
                 {
                     chacktype = "wall",
                     Position = new Vector2(310, 850),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall6)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1210, 600),
                     Input = new Input()
                     {
                     },
                 },
                new Sprite(wall4)
                {
                    chacktype = "wall",
                    Position = new Vector2(473, 300),
                    Input = new Input()
                    {
                    },
                },
                new Sprite(wall3)
                {
                    chacktype = "wall",
                    Position = new Vector2(425, 100),
                    Input = new Input()
                    {
                    },
                },
            new Sprite(wall)
            {
                chacktype = "wall",
                Position = new Vector2(260, 92),
                Input = new Input()
                {
                },
            },
                 new Sprite(wall)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1610, 92),
                     Input = new Input()
                     {
                     },
                 },
                 new Sprite(wall2)
                 {
                     chacktype = "wall",
                     Position = new Vector2(306, 95),
                     Input = new Input()
                     {
                     },
                 },
                 //
                new Sprite(animetion)
                {
                Position = new Vector2(1500,800),
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
                spriteBatch.DrawString(_font, "         "+Convert.ToString(sprite.Scores), positionScores, Color.Green);
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
            MyGlobals.retry = 1;
            

            foreach (var sprite in _sprites)
            {
                sprite.Update(game, _sprites);
                foreach (var securityGuards in securityGuard)
                    securityGuards.Update(game, _sprites);


            }
                

            if(MyGlobals.Over == "Over")
            {
                _currentState.Update(game);
                foreach (var sprite in _sprites)
                {
                    sprite.isRemoved = true;
                    
                }
            }
            foreach (var component in _component)
                component.Update(game);
            PostUpdate(game);
        }

    }
}
