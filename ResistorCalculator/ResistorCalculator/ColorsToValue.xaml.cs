using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResistorCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorsToValue : ContentPage
    {
        private int firstBandTapCount = 0;
        private int secondBandTapCount = 0;
        private int thirdBandTapCount = 0;
        private int fourthBandTapCount = 0;

        private BandColor FirstColorValue = new BandColor { Color = "Beige" };

        public BandColor FirstColor
        {
            get => FirstColorValue;
            set
            {
                this.FirstColorValue = value;
                OnPropertyChanged(nameof(FirstColor));
                this.CalculateOhm();
            }
        }

        private BandColor SecondColorValue = new BandColor { Color = "Beige" };

        public BandColor SecondColor
        {
            get => SecondColorValue;
            set
            {
                this.SecondColorValue = value;
                OnPropertyChanged(nameof(SecondColor));
                this.CalculateOhm();
            }
        }

        private BandColor ThirdColorValue = new BandColor { Color = "Beige" };

        public BandColor ThirdColor
        {
            get => ThirdColorValue;
            set
            {
                this.ThirdColorValue = value;
                OnPropertyChanged(nameof(ThirdColor));
                this.CalculateOhm();
            }
        }

        private BandColor FourthColorValue = new BandColor { Color = "Beige" };

        public BandColor FourthColor
        {
            get => FourthColorValue;
            set
            {
                this.FourthColorValue = value;
                OnPropertyChanged(nameof(FourthColor));
                this.CalculateOhm();
            }
        }

        private long ValueValue = 0;
        public long Value
        {
            get => ValueValue;
            set
            {
                ValueValue = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public BandColors Lists { get; set; }

        private void CalculateOhm()
        {
            if (FirstColor != null && SecondColor != null && ThirdColor != null && FourthColor != null)
            {
                Value = (FirstColor.Value * 10 + SecondColor.Value) * ThirdColor.Value;
            }
        }

        public ColorsToValue()
        {
            Lists = new BandColors();
            InitializeComponent();
            BindingContext = this;
        }

        private void FirstBand_Tapped(object sender, EventArgs e)
        {
            firstBandTapCount++;
            FirstColor = Lists.FirstBandList[firstBandTapCount % Lists.FirstBandList.Count];
        }

        private void SecondBand_Tapped(object sender, EventArgs e)
        {
            secondBandTapCount++;
            SecondColor = Lists.SecondBandList[secondBandTapCount % Lists.SecondBandList.Count];
        }

        private void ThirdBand_Tapped(object sender, EventArgs e)
        {
            thirdBandTapCount++;
            ThirdColor = Lists.ThirdBandList[thirdBandTapCount % Lists.ThirdBandList.Count];
        }

        private void FourthBand_Tapped(object sender, EventArgs e)
        {
            fourthBandTapCount++;
            FourthColor = Lists.FourthBandList[fourthBandTapCount % Lists.FourthBandList.Count];
        }
    }
}