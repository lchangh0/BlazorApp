using System;
using System.IO;
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
                        //paint.Color = SKColors.White;
                        paint.Color = new SKColor(0x11, 0x22, 0x33);

                        canv.DrawRect(0, 0, bitmap.Width, bitmap.Height, paint);
                    }
                }

                IntPtr data = bitmap.GetPixels();

                unsafe
                {
                    byte* ptr = (byte*)data.ToPointer();
                    
                    int iRowBytes = bitmap.RowBytes;
                    int iBytesPerPixel = bitmap.BytesPerPixel;

                    Console.WriteLine($"RowBytes={iRowBytes}, BytesPerPixel={iBytesPerPixel}");

                    for(int y = 0; y < bitmap.Height; y++)
                    {
                        for(int x = 0; x < bitmap.Width; x++)
                        {
                            int iOffset = y * iRowBytes + x * iBytesPerPixel;
                            byte b1 = ptr[iOffset];     // blue
                            byte b2 = ptr[iOffset+1];   // green
                            byte b3 = ptr[iOffset+2];   // red
                            byte b4 = ptr[iOffset+3];   // alpha

                            Console.Write($"{b1:X2}{b2:X2}{b3:X2}{b4:X2} ");
                        }
                        Console.WriteLine("");
                    }
                }

                /// Save to File

                string strFilePath = Path.Combine("/home/user", "a.png");
                using(SKFileWStream fs = new SKFileWStream(strFilePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }

            }

        }
    
    }
}