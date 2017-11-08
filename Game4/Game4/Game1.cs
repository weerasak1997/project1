using System;
using System.Collections.Generic;
using Game4.Model;
using Game4.Object;
using Game4.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game4
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Screen;
        Texture2D ScreenState1;
        Texture2D walking;
        SpriteFont _font;

        Vector2 positionScores = new Vector2(0, 0);
        Vector2 screenPosition = new Vector2(0,0);

        int chackStates = 0;

        public SecurityGruad security;
        //Button
        private State _currentState;
        private State _currentState1;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }
        //

        public GameState game;

        public List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1000;
            Window.AllowUserResizing = true;
            graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Screen = this.Content.Load<Texture2D>("Screen/Screen1");
            walking = this.Content.Load<Texture2D>("Player/walkingup");
            _font = this.Content.Load<SpriteFont>("Fonts/FontScores");
            ScreenState1 = this.Content.Load<Texture2D>("Screen/ScreenState1");


            var animetion = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Player/WalkingUp"), 3)},
                { "WalkDown", new Animation(Content.Load<Texture2D>("Player/WalkingDown"), 3) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/WalkingLeft"), 3)},
                { "WalkRight", new Animation(Content.Load<Texture2D>("Player/WalkingRight"), 3)},
            };
            // wall
            var wall = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/1"), 1)},
            };
            var wall2 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/2"), 1)},
            };
            var wall3 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/3"), 1)},
            };
             var wall4 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/4"), 1)},
            };
            var wall6 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/6"), 1)},
            };
            var wall7 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/7"), 1)},
            };
            var wall8 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/8"), 1)},
            };

            var wall9 = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Screen/ScreenState1/9"), 1)},
            };

            //
            _sprites = new List<Object.Sprite>()
            {
                //wall

                new Object.Sprite(wall9)
                {
                    chacktype = "wall",
                    Position = new Vector2(991, 425),
                    Input = new Input()
                    {
                    },
                },
                 new Object.Sprite(wall8)
                 {
                     chacktype = "wall",
                     Position = new Vector2(991, 502),
                     Input = new Input()
                     {
                     },
                 },
                 new Object.Sprite(wall7)
                 {
                     chacktype = "wall",
                     Position = new Vector2(310, 850),
                     Input = new Input()
                     {
                     },
                 },
                 new Object.Sprite(wall6)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1210, 600),
                     Input = new Input()
                     {
                     },
                 },
                new Object.Sprite(wall4)
                {
                    chacktype = "wall",
                    Position = new Vector2(473, 300),
                    Input = new Input()
                    {
                    },
                },
                new Object.Sprite(wall3)
                {
                    chacktype = "wall",
                    Position = new Vector2(425, 100),
                    Input = new Input()
                    {
                    },
                }, 
            new Object.Sprite(wall)
            {
                chacktype = "wall",
                Position = new Vector2(260, 92),
                Input = new Input()
                {
                },
            },
                 new Object.Sprite(wall)
                 {
                     chacktype = "wall",
                     Position = new Vector2(1610, 92),
                     Input = new Input()
                     {
                     },
                 },
                 new Object.Sprite(wall2)
                 {
                     chacktype = "money",
                     Position = new Vector2(306, 95),
                     Input = new Input()
                     {
                     },
                 },
            
                
                  
                 //item
                  /* new Object.Sprite(wall)
                {
                chacktype ="money",
                Position = new Vector2(500,500),
                Input = new Input()
            },*/
                   //
                new Object.Sprite(animetion)
                {
                Position = new Vector2(800,500),
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

            //protect
            security = new SecurityGruad(animetion)
            {
                Position = new Vector2(500, 500),
                Speed = 1,
                chack = 1,
                Farest = 900,
                Smallest = 400,

            };
        }

        
        protected override void UnloadContent()
        {
        }

        
        protected override void Update(GameTime gameTime)
        {
            //button
            if (IsActive)
            {
                if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
                chackStates = 1;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            //button
            if (chackStates == 1)
            {
                foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
               security.Update(gameTime, _sprites);


                }
                base.Update(gameTime);
            }
           

           
           
           
            

           
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //screen begin
            
            if (chackStates == 0)
            {
                spriteBatch.Draw(Screen, screenPosition);
                _currentState.Draw(gameTime, spriteBatch);
            }
             //

            
           
            
            if(chackStates == 1)
            {
            foreach (var sprite in _sprites) { 
                    if(sprite is Sprite)
                spriteBatch.Draw(ScreenState1, screenPosition); 
                sprite.Draw(spriteBatch);
               spriteBatch.DrawString(_font,"Money "+ Convert.ToString(sprite.Scores), positionScores , Color.Green);
               security.Draw(spriteBatch);
                } 
            }
           
            if(security.over == "Over")
            {
                spriteBatch.Draw(Screen, screenPosition);
                
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    chackStates = 0;
                    _currentState1.Draw(gameTime, spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
