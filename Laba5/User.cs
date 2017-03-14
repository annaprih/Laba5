using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    delegate void Fun(int a);

    class User
    {
        Fun[] review = new Fun[5];
        Fun[] zip = new Fun[5];
        private int Count = 0;
        private int Count_1 = 0;

        public event Fun ReviewEvent
        {
            add
            {
                if (Count < 5)
                {
                    review[Count++] = value;
                }
            }

            remove
            {
                for (int i = 0; i < Count; i++)
                {
                    review[i] = null;
                }
            }
        }

        public event Fun ZipEvent
        {
            add
            {
                if (Count_1 < 5)
                {
                    zip[Count_1++] = value;
                }
            }

            remove
            {
                for (int i = 0; i < Count_1; i++)
                {
                    zip[i] = null;
                }
            }
        }

        public void Review(int a)
        {
            for (int i = 0; i < Count_1; i++)
            {
                review[i].Invoke(a);
            }
        }

        public void Zip(int a)
        {
            for (int i = 0; i < Count; i++)
            {
                zip[i].Invoke(a);
            }
        }
    }
}