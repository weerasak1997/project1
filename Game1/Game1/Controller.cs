using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Controller
    {
        protected ArrayList mList;

        public Controller()
        {

            mList = new ArrayList();
        }

        public void AddModel(Model m)
        {

            mList.Add(m);
        }
        public virtual void ActionPerformed(int action)
        {
            throw new NotImplementedException();
        }
    }
}
