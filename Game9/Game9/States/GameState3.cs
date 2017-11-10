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
        public List<Wall> _wall;
        public List<Dog> _dog;

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

            _currentState = new StateOver(_game, _graphicsDevice, _content);
            //Screen = this._content.Load<Texture2D>("SecurityWay/SecurityWay3");
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
            var dog = this._content.Load<Texture2D>("Dog/Dog");
            var dog2 = this._content.Load<Texture2D>("Dog/dogNomal");


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
            var wall = this._content.Load<Texture2D>("Screen/ScreenState3/1");
            var wall2 = this._content.Load<Texture2D>("Screen/ScreenState3/2");
            var wall3 = this._content.Load<Texture2D>("Screen/ScreenState3/3");
            var wall4 = this._content.Load<Texture2D>("Screen/ScreenState3/4");
            var wall6 = this._content.Load<Texture2D>("Screen/ScreenState3/6");
            var wall5 = this._content.Load<Texture2D>("Screen/ScreenState3/5");
            var wall7 = this._content.Load<Texture2D>("Screen/ScreenState3/7");
            var wall8 = this._content.Load<Texture2D>("Screen/ScreenState3/8");
            var wall9 = this._content.Load<Texture2D>("Screen/ScreenState3/9");
            var wall10 = this._content.Load<Texture2D>("Screen/ScreenState3/10");
            var wall13 = this._content.Load<Texture2D>("Screen/ScreenState3/13");
            var wall14 = this._content.Load<Texture2D>("Screen/ScreenState3/14");
            var wall15 = this._content.Load<Texture2D>("Screen/ScreenState3/15");
            var wall16 = this._content.Load<Texture2D>("Screen/ScreenState3/16");
            var wall17 = this._content.Load<Texture2D>("Screen/ScreenState3/17");
            var wall18 = this._content.Load<Texture2D>("Screen/ScreenState3/18");
            var wall19 = this._content.Load<Texture2D>("Screen/ScreenState3/19");

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
            _wall = new List<Wall>()
            {
                //wall
                
                new Wall(wall)
                {
                    Position = new Vector2(0,450),

                },
                 new Wall(wall2)
                 {
                     Position = new Vector2(242, 137),
                 },
                 new Wall(wall3)
                 {
                     Position = new Vector2(396, 138),
                 },
                 new Wall(wall4)
                 {
                     Position = new Vector2(502, 807),
                 },
                new Wall(wall5)
                {
                    Position = new Vector2(452, 138),
                },
                new Wall(wall6)
                {
                    Position = new Vector2(553, 185),

                },
            new Wall(wall7)
            {
                Position = new Vector2(606,273),
            },
                 new Wall(wall8)
                 {
                     
                     Position = new Vector2(706,170),
                 },
                 new Wall(wall9)
                 {
                     
                     Position = new Vector2(1225, 230),

                 },
                 new Wall(wall10)
                 {
                     Position = new Vector2(1281, 365),

                 },
                 new Wall(wall13)
                 {
                     Position = new Vector2(1696, 225),
                 },
                 new Wall(wall14)
                 {
                     Position = new Vector2(236,770),

                 },
                 new Wall(wall15)
                 {
                     Position = new Vector2(0, 718),

                 },
                 new Wall(wall16)
                 {
                     Position = new Vector2(964, 453),

                 },

                 new Wall(wall17)
                 {

                     Position = new Vector2(1022, 541),

                 },
                  new Wall(wall18)
                 {
                     Position = new Vector2(1018, 590),

                 },
                  new Wall(wall19)
                 {

                     Position = new Vector2(1381, 590),

                 },
                 //
            };

            securityGuard = new List<SecurityGuard>()
            {
                new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(240, 550),
                Speed = 2f,
                chack = 2,
                Farest = 650,
                Smallest = 510,

                },
                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(630, 550),
                Speed = 2f,
                chack = 2,
                Farest = 700,
                Smallest = 510,

                },
                  new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(960, 250),
                Speed = 2f,
                chack = 2,
                Farest = 380,
                Smallest = 240,

                },
                   new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(1150, 400),
                Speed = 2f,
                chack = 2,
                Farest = 460,
                Smallest = 240,

                },
                   new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(700, 430),
                Speed = 2f,
                chack = 1,
                Farest = 900,
                Smallest = 690,

                },
            };
            _dog = new List<Dog>()
            {
                new Dog(dog,dog2)
                {
                    Position = new Vector2(830, 650),

                },
                 new Dog(dog,dog2)
                {
                    Position = new Vector2(460, 310),

                },
                  new Dog(dog,dog2)
                {
                    Position = new Vector2(1560, 600),

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
                spriteBatch.DrawString(_font, "         " + Convert.ToString(MyGlobals.Scores), positionScores, Color.Green);
                sprite.Draw(spriteBatch);
                foreach (var securityGuards in securityGuard)
                securityGuards.Draw(spriteBatch);
                foreach (var dogs in _dog)
                dogs.Draw(spriteBatch);

            }
            
            if (MyGlobals.Over == "Over")
            {

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
            MyGlobals.retry = 3;
            
            foreach (var component in _component)
                component.Update(game);
            
            foreach (var sprite in _sprites)
            {
                sprite.Update(game, _sprites,_wall);
                foreach (var securityGuards in securityGuard)
                   securityGuards.Update(game, _sprites);
                foreach (var dogs in _dog)
                    dogs.Update(game,_sprites);

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