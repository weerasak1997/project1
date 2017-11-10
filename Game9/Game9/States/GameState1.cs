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
        public List<Wall> _wall;

        public Vector2 screenPosition = new Vector2(0,0);
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
            var wall = this._content.Load<Texture2D>("Screen/ScreenState1/1");
            var wall2 = this._content.Load<Texture2D>("Screen/ScreenState1/2");
            var wall3 = this._content.Load<Texture2D>("Screen/ScreenState1/3");
            var wall4 = this._content.Load<Texture2D>("Screen/ScreenState1/4");
            var wall5 = this._content.Load<Texture2D>("Screen/ScreenState1/5");
            var wall6 = this._content.Load<Texture2D>("Screen/ScreenState1/6");
            var wall7 = this._content.Load<Texture2D>("Screen/ScreenState1/7");
            var wall8 = this._content.Load<Texture2D>("Screen/ScreenState1/8");
            var wall9 = this._content.Load<Texture2D>("Screen/ScreenState1/9");
            var wall10 = this._content.Load<Texture2D>("Screen/ScreenState1/10");
            var wall11 = this._content.Load<Texture2D>("Screen/ScreenState1/11");
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
                    Position = new Vector2(310, 250),
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

            _wall = new List<Wall>()
            {
                new Wall(wall2)
                {
                    Position = new Vector2(1430, 855),
                },
                  new Wall(wall3)
                 {
                     Position = new Vector2(240,852),
                 },
                new Wall(wall4)
                 {
                     Position = new Vector2(239, 217),
                 },
                 new Wall(wall5)
                 {
                     Position = new Vector2(239, 212),
                 },
                new Wall(wall6)
                {
                    Position = new Vector2(1695, 217),
                },
                new Wall(wall7)
                {
                    Position = new Vector2(1381, 670),
                },
            new Wall(wall8)
            {
                Position = new Vector2(1120, 535),
            },
                new Wall(wall9)
                 {
                     Position = new Vector2(1170, 534),
                 },
                 new Wall(wall10)
                 {
                     Position = new Vector2(500, 395),
                 },
                 new Wall(wall11)
                 {
                     Position = new Vector2(449, 246),
                 },
            };

            securityGuard = new List<SecurityGuard>()
            {
                new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(680, 600),
                Speed = 2f,
                chack = 1,
                Farest = 1030,
                Smallest = 490,

                },

                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(1200, 370),
                Speed = 2f,
                chack = 1,
                Farest = 1630,
                Smallest = 1030,

                },

                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(1300, 250),
                Speed = 2f,
                chack = 2,
                Farest = 470,
                Smallest = 230,

                },
                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(440, 620),
                Speed = 2f,
                chack = 2,
                Farest = 770,
                Smallest = 610,

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
            foreach (var wall in _wall)
                wall.Draw(spriteBatch);
            foreach (var sprite in _sprites)
            {
               
                spriteBatch.DrawString(_font, "         "+Convert.ToString(MyGlobals.Scores), positionScores, Color.Green);
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
                sprite.Update(game, _sprites,_wall);
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
