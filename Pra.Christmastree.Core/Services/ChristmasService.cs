using System;
using System.Collections.Generic;
using System.Text;
using Pra.Christmastree.Core.Entities;
using Pra.Christmastree.Core.Entities.Base;
using Pra.Christmastree.Core.Interfaces;
namespace Pra.Christmastree.Core.Services
{
    public class ChristmasService
    {
        private static Random rnd = new Random();
        private int numberOffBadBoys;
        private int numberOffCats;
        private int numberOffChristmasBaubles;
        private int numberOffChristmasCookies;
        private int numberOffStringOfLights;

        private List<ChristmasDecoration> christmasDecorations;
        public List<ChristmasDecoration> ChristmasDecorations
        {
            get { return christmasDecorations; }
        }
        public bool IsChristmasDone { get; private set; }


        public ChristmasService()
        {
            SetupChristmas();
        }
        private void SetupChristmas()
        {
            christmasDecorations = new List<ChristmasDecoration>();
            numberOffBadBoys = rnd.Next(1, 3);
            numberOffCats = rnd.Next(1, 3);
            numberOffChristmasBaubles = rnd.Next(20, 51);
            numberOffChristmasCookies = rnd.Next(20, 31);
            numberOffStringOfLights = rnd.Next(1, 4);
            for (int r = 1; r <= numberOffChristmasBaubles; r++)
            {
                christmasDecorations.Add(new ChristmasBauble());
            }
            for (int r = 1; r <= numberOffChristmasCookies; r++)
            {
                christmasDecorations.Add(new ChristmasCookie());
            }
            for (int r = 1; r <= numberOffStringOfLights; r++)
            {
                christmasDecorations.Add(new ChristmasLights());
            }
            IsChristmasDone = false;
        }
        public void ReleaseHavoc()
        {
            for (int b = 1; b <= numberOffBadBoys; b++)
            {
                foreach (ChristmasDecoration christmasDecoration in christmasDecorations)
                {
                    if (christmasDecoration is IBreakable)
                    {
                        IBreakable breakable = (IBreakable)christmasDecoration;
                        breakable.TryToBreak();
                    }
                    if (christmasDecoration is IEatable)
                    {
                        IEatable eatable = (IEatable)christmasDecoration;
                        eatable.TryToEat();
                    }
                }
            }
            for (int c = 1; c <= numberOffCats; c++)
            {
                foreach (ChristmasDecoration christmasDecoration in christmasDecorations)
                {
                    if (christmasDecoration is ChristmasBauble)
                    {
                        ChristmasBauble christmasBauble = (ChristmasBauble)christmasDecoration;
                        christmasBauble.TryToBreak();
                    }
                    if (christmasDecoration is ChristmasCookie)
                    {
                        ChristmasCookie christmasCookie = (ChristmasCookie)christmasDecoration;
                        christmasCookie.TryToEat();
                    }
                }
            }
        }

        public List<ChristmasDecoration> GetChristmasBaubles()
        {
            List<ChristmasDecoration> christmasBaubles = new List<ChristmasDecoration>();
            foreach(ChristmasDecoration christmasDecoration in christmasDecorations)
            {
                if (christmasDecoration is ChristmasBauble)
                    christmasBaubles.Add(christmasDecoration);
            }
            return christmasBaubles;
        }
        public List<ChristmasDecoration> GetChristmasCookies()
        {
            List<ChristmasDecoration> christmasCoukies = new List<ChristmasDecoration>();
            foreach (ChristmasDecoration christmasDecoration in christmasDecorations)
            {
                if (christmasDecoration is ChristmasCookie)
                    christmasCoukies.Add(christmasDecoration);
            }
            return christmasCoukies;
        }
        public List<ChristmasDecoration> GetChristmasLights()
        {
            List<ChristmasDecoration> christmasLights = new List<ChristmasDecoration>();
            foreach (ChristmasDecoration christmasDecoration in christmasDecorations)
            {
                if (christmasDecoration is ChristmasLights)
                    christmasLights.Add(christmasDecoration);
            }
            return christmasLights;
        }
        public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            int baubleUnbroken = 0;
            int baubleBroken = 0;
            int cookieEaten = 0;
            int cookieUneaten = 0;
            int lightsBroken = 0;
            int lightsUnbroken = 0;
            foreach(ChristmasDecoration christmasDecoration in christmasDecorations)
            {
                if(christmasDecoration.Health == 0)
                {
                    if (christmasDecoration is ChristmasBauble) baubleBroken++;
                    if (christmasDecoration is ChristmasCookie) cookieEaten++;
                    if (christmasDecoration is ChristmasLights) lightsBroken++;
                }
                else
                {
                    if (christmasDecoration is ChristmasBauble) baubleUnbroken++;
                    if (christmasDecoration is ChristmasCookie) cookieUneaten++;
                    if (christmasDecoration is ChristmasLights) lightsUnbroken++;
                }
            }
            sb.AppendLine("FYI : ");
            sb.AppendLine($"\t Number of bad boys in the house : {numberOffBadBoys}");
            sb.AppendLine($"\t Number of cats in the house : {numberOffCats}");
            sb.AppendLine("=============================");
            sb.AppendLine($"Total number of Christmasbaubles : {baubleBroken + baubleUnbroken} ");
            sb.AppendLine($"\t unbroken Christmasbaubles : {baubleUnbroken} ");
            sb.AppendLine($"\t broken Christmasbaubles : {baubleBroken} ");
            sb.AppendLine($"Total number of ChristmasCookies : {cookieEaten + cookieUneaten} ");
            sb.AppendLine($"\t uneaten ChristmasCookies : {cookieUneaten} ");
            sb.AppendLine($"\t eaten ChristmasCookies : {cookieEaten} ");
            sb.AppendLine($"Total number of Christmaslights : {lightsBroken + lightsUnbroken} ");
            sb.AppendLine($"\t unbroken Christmaslights : {lightsUnbroken} ");
            sb.AppendLine($"\t broken Christmaslights : {lightsBroken} ");
            sb.AppendLine("=============================");
            if(baubleUnbroken == 0 && cookieUneaten == 0 && lightsUnbroken == 0)
            {
                sb.AppendLine("CHRISTMAS IS OVER");
                IsChristmasDone = true;
            }
            else
            {
                sb.AppendLine("CHRISTMAS CAN GO ON");
            }
            return sb.ToString();
        }
    }
}
