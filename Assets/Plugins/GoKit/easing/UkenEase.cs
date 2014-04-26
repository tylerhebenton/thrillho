using System;
using UnityEngine;

public class UkenEase {

  public static float BounceIn( float t, float b, float c, float d ) {
   if( t == 0 )
   {
     return b;
   }
   //Normalize Time based on distance
   t /= d;
   if(t >= 1)
   {
     return b + c;
   }

   //Magic based on http://www.wolframalpha.com/input/?i=cubic+fit%7B%280%2C0%29%2C%28.75%2C1%29%2C%28.87%2C.87%29%2C%281%2C.9%29%7D
   float timeVal = (float)((8.03419*Math.Pow(t,3) - 15.7932*Math.Pow(t,2) + 8.65897*t) / 0.9);

   return (timeVal * (c - b)) + b;
 }

}

