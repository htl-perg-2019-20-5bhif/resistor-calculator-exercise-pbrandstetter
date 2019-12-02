using System;
using System.Collections.Generic;
using System.Linq;

namespace ResistorCalculator
{
    public class BandColors
    {
        public List<BandColor> SecondBandList { get; } = new List<BandColor>() {
            new BandColor { Color="Black", Value=0 },
            new BandColor { Color="Brown", Value=1 },
            new BandColor { Color="Red", Value=2 },
            new BandColor { Color="Orange", Value=3 },
            new BandColor { Color="Yellow", Value=4 },
            new BandColor { Color="Green", Value=5 },
            new BandColor { Color="Blue", Value=6},
            new BandColor { Color="Purple", Value=7 },
            new BandColor { Color="Gray", Value=8 },
            new BandColor { Color="White", Value=9 }
        };

        public List<BandColor> FirstBandList { get; }

        public List<BandColor> ThirdBandList { get; }

        public List<BandColor> FourthBandList { get; } = new List<BandColor>() {
            new BandColor { Color="Brown", Value=1 },
            new BandColor { Color="Red", Value=2 },
            new BandColor { Color="Gold", Value=5 },
            new BandColor { Color="Silver", Value=10 }
        };

        public BandColors()
        {
            FirstBandList = SecondBandList.GetRange(1, SecondBandList.Count() - 1);
            ThirdBandList = SecondBandList.Select(e => new BandColor() { Color = e.Color, Value = (int)Math.Pow(10, e.Value) }).ToList();
        }
    }
}
