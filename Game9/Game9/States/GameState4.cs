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
    class GameState4 : State
    {
        public List<Sprite> _sprites;
        private List<Component> _component;

        public List<SecurityGuard> securityGuard;
        public List<Wall> _wall;
        public List<Dog> _dog;

        public Texture2D Screen;
        public Texture2D MoneyScores;

        public Vector2 screenPosition = new Vector2(-35, 0);
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


        public GameState4(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _font = this._content.Load<SpriteFont>("Fonts/FontScores");
            MoneyScores = this._content.Load<Texture2D>("Money/MoneyScores/MoneyScores");

            _currentState = new StateOver(_game, _graphicsDevice, _content);
           Screen = this._content.Load<Texture2D>("SecurityWay/SecurityWay4");
            // Screen = this._content.Load<Texture2D>("Screen/ScreenState4");
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
            var wall = this._content.Load<Texture2D>("Screen/ScreenState4/1");
            var wall2 = this._content.Load<Texture2D>("Screen/ScreenState4/2");
            var wall3 = this._content.Load<Texture2D>("Screen/ScreenState4/3");
            var wall4 = this._content.Load<Texture2D>("Screen/ScreenState4/4");
            var wall6 = this._content.Load<Texture2D>("Screen/ScreenState4/6");
            var wall5 = this._content.Load<Texture2D>("Screen/ScreenState4/5");
            var wall7 = this._content.Load<Texture2D>("Screen/ScreenState4/7");
            var wall8 = this._content.Load<Texture2D>("Screen/ScreenState4/8");
            var wall9 = this._content.Load<Texture2D>("Screen/ScreenState4/9");
            var wall92 = this._content.Load<Texture2D>("Screen/ScreenState4/9-2");
            var wall10 = this._content.Load<Texture2D>("Screen/ScreenState4/10");
            var wall11 = this._content.Load<Texture2D>("Screen/ScreenState4/11");
            var wall12 = this._content.Load<Texture2D>("Screen/ScreenState4/12");
            var wall13 = this._content.Load<Texture2D>("Screen/ScreenState4/13");
            var wall14 = this._content.Load<Texture2D>("Screen/ScreenState4/14");
            var wall15 = this._content.Load<Texture2D>("Screen/ScreenState4/15");
            var wall16 = this._content.Load<Texture2D>("Screen/ScreenState4/16");
            var wall17 = this._content.Load<Texture2D>("Screen/ScreenState4/17");
            var wall18 = this._content.Load<Texture2D>("Screen/ScreenState4/18");
            var wall19 = this._content.Load<Texture2D>("Screen/ScreenState4/19");
            var wall20 = this._content.Load<Texture2D>("Screen/ScreenState4/20");
            var wall21 = this._content.Load<Texture2D>("Screen/ScreenState4/21");
            var wall22 = this._content.Load<Texture2D>("Screen/ScreenState4/22");
            var wall23 = this._content.Load<Texture2D>("Screen/ScreenState4/23");
            var wall24 = this._content.Load<Texture2D>("Screen/ScreenState4/24");
            var wall25 = this._content.Load<Texture2D>("Screen/ScreenState4/25");
            var wall252 = this._content.Load<Texture2D>("Screen/ScreenState4/25-2");
            var wall26 = this._content.Load<Texture2D>("Screen/ScreenState4/26");
            var wall27 = this._content.Load<Texture2D>("Screen/ScreenState4/27");
            var wall28 = this._content.Load<Texture2D>("Screen/ScreenState4/28");
            var wall29 = this._content.Load<Texture2D>("Screen/ScreenState4/29");
            var wall30 = this._content.Load<Texture2D>("Screen/ScreenState4/30");
            var wall31 = this._content.Load<Texture2D>("Screen/ScreenState4/31");
            var wall32 = this._content.Load<Texture2D>("Screen/ScreenState4/32");
            var wall33 = this._content.Load<Texture2D>("Screen/ScreenState4/33");
            var wall34 = this._content.Load<Texture2D>("Screen/ScreenState4/34");
            var wall35 = this._content.Load<Texture2D>("Screen/ScreenState4/35");
            var wall36 = this._content.Load<Texture2D>("Screen/ScreenState4/36");
            var wall37 = this._content.Load<Texture2D>("Screen/ScreenState4/37");

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
                Position = new Vector2(825,925),
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
                    Position = new Vector2(108,683),

                },
                 new Wall(wall2)
                 {
                     Position = new Vector2(55, 691),
                 },
                 new Wall(wall3)
                 {
                     Position = new Vector2(106, 953),
                 },
                 new Wall(wall4)
                 {
                     Position = new Vector2(472, 688),
                 },
                new Wall(wall5)
                {
                    Position = new Vector2(366, 681),
                },
                new Wall(wall7)
                {
                    Position = new Vector2(108, 867),

                },
                 new Wall(wall8)
                {
                Position = new Vector2(263,815),
                },
                 new Wall(wall9)
                 {

                     Position = new Vector2(5,548),
                 },
                 new Wall(wall10)
                 {

                     Position = new Vector2(517, 679),

                 },
                 new Wall(wall11)
                 {
                     Position = new Vector2(731, 726),

                 },
                 new Wall(wall12)
                 {
                     Position = new Vector2(370, 408),
                 },
                 new Wall(wall12)
                 {
                     Position = new Vector2(60, 408),
                 },
                 new Wall(wall13)
                 {
                     Position = new Vector2(55,128),

                 },
                 new Wall(wall13)
                 {
                     Position = new Vector2(470,128),

                 },
                 new Wall(wall14)
                 {
                     Position = new Vector2(105, 127),

                 },
                 new Wall(wall15)
                 {
                     Position = new Vector2(163, 363),

                 },

                 new Wall(wall16)
                 {

                     Position = new Vector2(217, 265),

                 },
                  new Wall(wall17)
                 {
                     Position = new Vector2(217, 233),

                 },
                  new Wall(wall18)
                 {

                     Position = new Vector2(524, 361),

                 },
                 new Wall(wall19)
                 {
                     Position = new Vector2(680,405),

                 },
                 new Wall(wall19)
                 {
                     Position = new Vector2(990,405),

                 },
                 new Wall(wall20)
                 {
                     Position = new Vector2(676, 126),

                 },
                  new Wall(wall20)
                 {
                     Position = new Vector2(1088, 126),

                 },

                 new Wall(wall21)
                 {

                     Position = new Vector2(725, 128),

                 },
                 new Wall(wall22)
                 {

                     Position = new Vector2(1247, 128),

                 },
                 new Wall(wall22)
                 {

                     Position = new Vector2(1661, 128),

                 },
                 new Wall(wall23)
                 {

                     Position = new Vector2(1294, 126),

                 },
                 new Wall(wall24)
                 {

                     Position = new Vector2(731, 186),

                 },
                 new Wall(wall24)
                 {

                     Position = new Vector2(1041, 186),

                 },
                  new Wall(wall24)
                 {

                     Position = new Vector2(886, 186),

                 },
                  new Wall(wall24)
                 {

                     Position = new Vector2(886, 186),

                 },
                   new Wall(wall25)
                 {

                     Position = new Vector2(770, 366),

                 },
                    new Wall(wall26)
                 {

                     Position = new Vector2(1557, 317),

                 },
                      new Wall(wall27)
                 {

                     Position = new Vector2(1716, 361),

                 },
                       new Wall(wall27)
                 {

                     Position = new Vector2(1146, 362),

                 },
                      new Wall(wall28)
                 {
                     Position = new Vector2(960,541),

                 },
                          new Wall(wall28)
                 {
                     Position = new Vector2(75,541),

                 },
                      new Wall(wall30)
                 {
                     Position = new Vector2(-33,541),

                 },
                           new Wall(wall31)
                 {
                     Position = new Vector2(1250,680),

                 },
                           new Wall(wall32)
                 {
                     Position = new Vector2(1042,685),

                 },
                    new Wall(wall33)
                 {
                     Position = new Vector2(1092,955),

                 },
                       new Wall(wall34)
                 {
                     Position = new Vector2(1940,725),

                 },
                       new Wall(wall35)
                 {
                     Position = new Vector2(1148,774),

                 },
                        new Wall(wall36)
                 {
                     Position = new Vector2(1160,869),

                 },
                         new Wall(wall36)
                 {
                     Position = new Vector2(1780,869),

                 },
                              new Wall(wall36)
                 {
                     Position = new Vector2(1680,915),

                 },
                     new Wall(wall36)
                 {
                     Position = new Vector2(1263,915),

                 },
                      new Wall(wall37)
                 {
                     Position = new Vector2(1365,864),

                 },
                      new Wall(wall37)
                 {
                     Position = new Vector2(1520,864),

                 },
                       new Wall(wall92)
                 {
                     Position = new Vector2(1832,432),

                 },
                         new Wall(wall252)
                 {

                     Position = new Vector2(1008, 366),

                 },
                 //
            };
           
            securityGuard = new List<SecurityGuard>()
            {
                new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(80, 590),
                Speed = 2f,
                chack = 1,
                Farest = 430,
                Smallest = 70,

                },
                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(800, 650),
                Speed = 2f,
                chack = 1,
                Farest = 970,
                Smallest = 790,

                },
                 new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(950, 830),
                Speed = 2f,
                chack = 1,
                Farest = 970,
                Smallest = 790,

                },
                  new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(1095, 450),
                Speed = 2f,
                chack = 1,
                Farest = 1100,
                Smallest = 590,

                },
                    new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(200, 420),
                Speed = 2f,
                chack = 1,
                Farest = 530,
                Smallest = 50,
                },
               
                  new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(1080, 600),
                Speed = 2f,
                chack = 2,
                Farest = 880,
                Smallest = 590,

                },
                        new SecurityGuard(animetionGuard)
                {
                Position = new Vector2(500, 30),
                Speed = 2f,
                chack = 1,
                Farest = 1900,
                Smallest = 50,
                },
               
            };
            _dog = new List<Dog>()
            {
                new Dog(dog,dog2)
                {
                    Position = new Vector2(600, 570),

                },
                 new Dog(dog,dog2)
                {
                    Position = new Vector2(1380, 250),

                },
                  new Dog(dog,dog2)
                {
                    Position = new Vector2(1820, 150),

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
            _game.ChangeState(new MenuToFront2(_game, _graphicsDevice, _content));

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
            foreach (var wall in _wall)
                    wall.Draw(spriteBatch);
            spriteBatch.Draw(MoneyScores, MoneyScoresPosition, Color.White);
            foreach (var sprite in _sprites)
            {
                spriteBatch.DrawString(_font, "         " + Convert.ToString(sprite.Scores), positionScores, Color.Green);
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
            MyGlobals.retry = 4;

            
            foreach (var component in _component)
                component.Update(game);

            foreach (var sprite in _sprites)
            {
                foreach (var wall in _wall)
                wall.Update(game, _sprites);
                sprite.Update(game, _sprites, _wall);
                foreach (var securityGuards in securityGuard)
                     securityGuards.Update(game, _sprites);
                 foreach (var dogs in _dog)
                     dogs.Update(game, _sprites);
                

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