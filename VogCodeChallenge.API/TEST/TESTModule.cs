using System;
namespace VogCodeChallenge.API
{
    public static class TESTModule
    {

        // Because I am not sure what result this function is expected to realize,
        // I cannot make the judgement at this point.
        // however, I found some issues as following:
        // 1.If input is string, such as "2", should it return string "2" or int 4?
        //   if it should return int 4, this function should do some conversion.
        // 2.In some cases, only specific input get specific output, so this is no need
        //   to use local function.

        public static object Module(object testObject)
        {
            switch (testObject)
            {

                case 1:
                    //I don't have information about the function expected to realize,
                    //so I can't decide input number is 1 should retrun 1 or doubler(1).
                    //in my opinion, I think it should return 1. so I add return statement.
                    return 1;
                case 2:

                    //if just case 2 return doubler(2),in my opinion,it should return 4 directly
                    return doubler((int)testObject);

                case int value when value >= 3:
                    return tripler(value);
                case float floatValue when floatValue == 1.0f:
                    return leveler(floatValue);
                default:
                    return testObject;
            }

            //if the input number is always 2, this local function is not needed
            int doubler(int amount) => amount * 2;

            //thie return type should be 'long', in case the input int number too large
            long tripler(int amount) => (long)amount * 3;

            //I'm not sure what this local function does, it looks like 'amout - 1.0f'
            //since amount alwalys should be 1.0f, in my opinion,it should return 0.0 directly 
            double leveler(double amount) => amount - 0.1f * 10f;
        }
    }

}
