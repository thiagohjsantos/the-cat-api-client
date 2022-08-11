using System;
using System.Collections.Generic;
using System.Text;

namespace CatAsService
{
    public class ComboBoxItem
    {
        string displayValue;
        string hiddenValue;
        string imageId;

        public ComboBoxItem(string d, string h, string i)
        {
            displayValue = d;
            hiddenValue = h;
            imageId = i;
        }

        public ComboBoxItem(string d, string h)
        {
            displayValue = d;
            hiddenValue = h;     
        }

        public string HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        public string ImageId
        {
            get
            {
                return imageId;
            }
        }

        public override string ToString()
        {
            return displayValue;
        }
    }
}
