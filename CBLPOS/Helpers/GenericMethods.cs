using System;
namespace CBLPOS.Helpers
{
    public static class GenericMethods
    {
        public static int CartCount()
        {
            return Calculate();
        }

        public static int Calculate()
        {
            int count = 0;

            if (Settings.ItemStatus1)
                count = count + 1;


            return count;
        }
    }
}