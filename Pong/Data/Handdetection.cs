using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Pong.Data {
    public static class Handdetection
    {
        /// <summary>
        /// Binarize a given bitmap based on the given threshold value.
        /// First the bitmap is converted to a grayscale, then there is a binarization based on the threshold value
        /// and finally there is an optional mirror filter.
        /// </summary>
        /// <param name="bmp">Bitmap to binarize</param>
        /// <param name="treshold">Threshold value (0 - 255)</param>
        /// <param name="mirrorChecked">If true, the image will be mirrored</param>
        /// <returns>Binarized with threshold value bitmap</returns>
        public static Bitmap imageBinarization(Bitmap bmp, int threshold, bool mirrorChecked)
        {
            // Create bitmap with grayScale pixelformat
            Bitmap bitmap = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Create grayscale filter (BT709) and apply filter
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            bitmap = filter.Apply(bmp);

            // Create Threshold (binarization) filter and apply
            Threshold filter1 = new Threshold(threshold);
            filter1.ApplyInPlace(bitmap);

            // Create mirror filter if checkbox was checked
            if (mirrorChecked == true)
            {
                Mirror filter2 = new Mirror(false, true);
                filter2.ApplyInPlace(bitmap);
            }

            // Return binarized bitmap
            return bitmap;
        }

        /// <summary>
        /// Performs hand detection calculations
        /// </summary>
        /// <param name="bmp">The camera frame to be processed</param>
        /// <returns>A bitmap representation of the detected hands</returns>
        public static Bitmap Findhands(Bitmap bmp)
        {
            Bitmap test = new Bitmap(bmp.Width, bmp.Height);
            Graphics g = Graphics.FromImage(test);
            for (int j = 0; j < 2; j++)
            {
                Bitmap partial = bmp.Clone(new System.Drawing.Rectangle(j * bmp.Width / 2, 0, bmp.Width / 2, bmp.Height), bmp.PixelFormat);
                HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(partial);
                VerticalIntensityStatistics vis = new VerticalIntensityStatistics(partial);
                Histogram gray = his.Gray;
                Histogram GrayY = vis.Gray;

                double meanX;
                double meanY;

                int[] hisValues = (int[])his.Gray.Values.Clone();
                int[] visValues = (int[])vis.Gray.Values.Clone();

                List<int> lX = new List<int>();
                List<int> lY = new List<int>();

                for (int i = 0; i < hisValues.Length; i++)
                {
                    if (hisValues[i] != 0)
                    {
                        hisValues[i] = (hisValues[i] / hisValues.Max()) * 255;
                    }


                    if (hisValues[i] == 0)
                    {
                        lX.Add(i + (j * test.Width / 2));
                    }
                }
                for (int i = 0; i < visValues.Length; i++)
                {
                    if (visValues[i] != 0)
                    {
                        visValues[i] = (visValues[i] / visValues.Max()) * 255;
                    }


                    if (visValues[i] == 0)
                    {
                        lY.Add(i);
                    }
                }

                if (lX.Count != 0)
                {
                    meanX = lX.Average();
                }
                else
                {
                    meanX = 0;
                }
                if (lY.Count != 0)
                {
                    meanY = lY.Average();
                }
                else
                {
                    meanY = 0;
                }
                Rectangle r = new Rectangle((int)meanX, (int)meanY, 10, 10);
                g.DrawRectangle(new Pen(Color.Aqua), r);
            }
            return test;
        }

        /// <summary>
        /// Performs hand detection calculations within the given areas
        /// </summary>
        /// <param name="bmp">The camera frame to be processed</param>
        /// <param name="areas">A list of rectangles in which the hand detection is to be calculated</param>
        /// <returns>A bitmap representation of the detected hands</returns>
        public static Bitmap Findhands(Bitmap bmp, List<Rectangle> areas) {
            Bitmap test = new Bitmap(bmp.Width, bmp.Height);
            Graphics g = Graphics.FromImage(test);
            foreach (Rectangle rect in areas) {
                Bitmap partial = bmp.Clone(rect, bmp.PixelFormat);
                HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(partial);
                VerticalIntensityStatistics vis = new VerticalIntensityStatistics(partial);
                Histogram gray = his.Gray;
                Histogram GrayY = vis.Gray;

                double meanX;
                double meanY;

                int[] hisValues = (int[])his.Gray.Values.Clone();
                int[] visValues = (int[])vis.Gray.Values.Clone();

                List<int> lX = new List<int>();
                List<int> lY = new List<int>();

                for (int i = 0; i < hisValues.Length; i++) {
                    if (hisValues[i] != 0) {
                        hisValues[i] = (hisValues[i] / hisValues.Max()) * 255;
                    }

                    if (hisValues[i] == 0) {
                        lX.Add(i + rect.X);
                    }
                }
                for (int i = 0; i < visValues.Length; i++) {
                    if (visValues[i] != 0) {
                        visValues[i] = (visValues[i] / visValues.Max()) * 255;
                    }


                    if (visValues[i] == 0) {
                        lY.Add(i + rect.Y);
                    }
                }

                if (lX.Count != 0) {
                    meanX = lX.Average();
                }
                else {
                    meanX = 0;
                }
                if (lY.Count != 0) {
                    meanY = lY.Average();
                }
                else {
                    meanY = 0;
                }
                Rectangle r = new Rectangle((int)meanX, (int)meanY, 10, 10);
                g.DrawRectangle(new Pen(Color.Red), r);
            }
            return test;
        }

        /// <summary>
        /// Performs hand detection calculations within the given areas. 
        /// </summary>
        /// <param name="bmp">The camera frame to be processed</param>
        /// <param name="areas">A list of rectangles in which the hand detection is to be calculated</param>
        /// <returns>A list of coordinates representing the location of each hand</returns>
        public static List<Point> GetHandLocations(Bitmap bmp, List<Rectangle> areas) {
            List<Point> hands = new List<Point>();
            foreach (Rectangle rect in areas) {
                Bitmap partial = bmp.Clone(rect, bmp.PixelFormat);
                HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(partial);
                VerticalIntensityStatistics vis = new VerticalIntensityStatistics(partial);
                Histogram gray = his.Gray;
                Histogram GrayY = vis.Gray;

                double meanX;
                double meanY;

                int[] hisValues = (int[])his.Gray.Values.Clone();
                int[] visValues = (int[])vis.Gray.Values.Clone();

                List<int> lX = new List<int>();
                List<int> lY = new List<int>();

                for (int i = 0; i < hisValues.Length; i++) {
                    if (hisValues[i] != 0) {
                        hisValues[i] = (hisValues[i] / hisValues.Max()) * 255;
                    }
                    if (hisValues[i] == 0) {
                        lX.Add(i + rect.X);
                    }
                }
                for (int i = 0; i < visValues.Length; i++) {
                    if (visValues[i] != 0) {
                        visValues[i] = (visValues[i] / visValues.Max()) * 255;
                    }


                    if (visValues[i] == 0) {
                        lY.Add(i + rect.Y);
                    }
                }

                if (lX.Count != 0) {
                    meanX = lX.Average();
                }
                else {
                    meanX = 0;
                }
                if (lY.Count != 0) {
                    meanY = lY.Average();
                }
                else {
                    meanY = 0;
                }
                hands.Add(new Point((int)meanX, (int)meanY));
            }
            return hands;
        }
    }
}
