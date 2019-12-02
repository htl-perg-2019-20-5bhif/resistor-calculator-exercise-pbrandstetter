using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResistorCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValuesToColor : ContentPage
    {
        public ValuesToColor()
        {
            Lists = new BandColors();
            InitializeComponent();
            BindingContext = this;
        }

        public BandColors Lists { get; set; }

        private long ValueValue = 0;
        public long Value
        {
            get => ValueValue;
            set
            {
                ValueValue = value;
                OnPropertyChanged(nameof(Value));
                this.GetColors();
            }
        }

        private BandColor FirstColorValue;

        public BandColor FirstColor
        {
            get => FirstColorValue;
            set
            {
                this.FirstColorValue = value;
                OnPropertyChanged(nameof(FirstColor));
            }
        }

        private BandColor SecondColorValue;

        public BandColor SecondColor
        {
            get => SecondColorValue;
            set
            {
                this.SecondColorValue = value;
                OnPropertyChanged(nameof(SecondColor));
            }
        }

        private BandColor ThirdColorValue;

        public BandColor ThirdColor
        {
            get => ThirdColorValue;
            set
            {
                this.ThirdColorValue = value;
                OnPropertyChanged(nameof(ThirdColor));
            }
        }


        private BandColor FourthColorValue;
        public BandColor FourthColor
        {
            get => FourthColorValue;
            set
            {
                FourthColorValue = value;
                OnPropertyChanged(nameof(FourthColor));
                GetColors();
            }
        }

        private string DisplayValueValue = "No action executed until now!\n";

        public string DisplayValue
        {
            get => DisplayValueValue;
            set
            {
                this.DisplayValueValue = value;
                OnPropertyChanged(nameof(DisplayValue));
            }
        }

        private void GetColors()
        {
            long curValue = Value;
            int count = 0;
            if (curValue == 0 || FourthColor == null)
            {
                return;
            }
            //Count how many zeros are in our Value
            while (curValue % 10 == 0)
            {
                count++;
                curValue /= 10;
            }

            long secondVal = curValue % 10;
            long firstVal = curValue / 10;

            if (curValue < 10)
            {
                firstVal = secondVal;
                secondVal = 0;
                count--;
            }

            if (Lists.FirstBandList.Count > firstVal - 1 && firstVal >= 0)
            {
                FirstColor = Lists.FirstBandList[(int)firstVal - 1];
            }
            else
            {
                FirstColor = null;
            }

            if (Lists.SecondBandList.Count > secondVal && secondVal >= 0)
            {
                SecondColor = Lists.SecondBandList[(int)secondVal];
            }
            else
            {
                SecondColor = null;
            }

            if (Lists.ThirdBandList.Count > count && count >= 0)
            {
                ThirdColor = Lists.ThirdBandList[count];
            }
            else
            {
                ThirdColor = null;
            }

            if (FirstColor == null || SecondColor == null || ThirdColor == null)
            {
                DisplayValue = "Unable to find correct colors!\n";
                FirstColor = null;
                SecondColor = null;
                ThirdColor = null;
            }
            else
            {
                DisplayValue = "Color 1: " + FirstColor.Color + "\n" +
                    "Color 2: " + SecondColor.Color + "\n" +
                    "Color 3: " + ThirdColor.Color + "\n" +
                    "Color 4:" + FourthColor.Color + "\n";
            }
        }
    }
}