using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ScreenBrighnessClassNET;

namespace AppleWirelessKeyboard
{
    class BrightnessManager
    {
        private readonly double max_value = 16;
        private readonly double min_value = 0;

        private void SetBrightness(double value)
        {
            if (value > max_value)
                value = max_value;
            if (value < min_value)
                value = min_value;
            double new_value = value * (100 / max_value);
            new ScreenBrightness().SetBrightness(Convert.ToByte(new_value));
        }

        public double GetBrightness()
        {
            int sb = new ScreenBrightness().GetBrightness();
            double normalised_sb = sb / (100 / max_value);
            return normalised_sb;
            
        }

        public void UpBrightness()
        {
            double sb = GetBrightness();
            SetBrightness(sb + 1);
        }

        public void LowerBrightness()
        {
            double sb = GetBrightness();
            SetBrightness(sb - 1);
        }
    }
}
