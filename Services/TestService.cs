using System;
using SkiaSharp;

namespace BlazorApp.Services
{
    class TestService
    {
        public void Func1()
        {
            Console.WriteLine("Hello");

            using(SKBitmap bitmap = new SKBitmap(100,100))
            {
                using(SKCanvas canv = new SKCanvas(bitmap))
                {
                    using(SKPaint paint = new SKPaint())
                    {
                        paint.Color = SKColors.White;
                        canv.DrawRect(0, 0, bitmap.Width, bitmap.Height, paint);
                    }
                }
            }

        }
    
    }
}