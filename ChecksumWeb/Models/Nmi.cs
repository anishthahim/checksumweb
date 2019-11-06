using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChecksumWeb.Models
{
    public class Nmi
    {
        public string NmiValue { get; set; }
        public int? Checksum { get; set; }
        public bool IsNmiValid { get; set; }
        public bool IsChecksumCalculated { get; set; }
        public string Message { get; set; }

        public Nmi(string nmivalue)
        {
            NmiValue = nmivalue == null ? "0" : nmivalue.ToUpper();
            CalculateChecksum();
        }

        public void CalculateChecksum()
        {
            try
            {
                IsValidNmi();

                if (IsNmiValid)
                {
                    // find checksum
                    var asciiValues = Encoding.ASCII.GetBytes(NmiValue);

                    var total = 0;
                    for (var i = 0; i < asciiValues.Length; i++)
                    {

                        int calcValue = (i % 2 > 0) ? asciiValues[i] * 2 : asciiValues[i];

                        // add digits in asciiValue
                        int sumOfChars = 0;
                        var digits = calcValue.ToString().Select(d => int.Parse(d.ToString())).ToArray();

                        for (var j = 0; j < digits.Length; j++)
                        {
                            sumOfChars += digits[j];
                        }

                        total += sumOfChars;
                    }

                    var result = 0;
                    if (total % 10 != 0)
                    {
                        result = 10 - (total % 10);
                    }

                    Checksum = result;
                    Message = "*** SUCCESS *** - Checksum calculated";
                    IsChecksumCalculated = true;
                }

            }
            catch (Exception ex)
            {
                IsChecksumCalculated = false;
                Message = "*** APPL ERROR ****" + ex.Message;
            }

        }

        private void IsValidNmi()
        {
            if (NmiValue == null)
            {
                SetValues(false, false, "*** INVALID NMI *** - NMI should be an AlpaNumeric value.");
            }
            else
            if (NmiValue.Length != 10)
            {
                SetValues(false, false, "*** INVALID NMI *** - NMI should contain 10 AlpaNumeric Characters");
            }
            else
            if (!IsAlphaNumeric(NmiValue))
            {
                SetValues(false, false, "*** INVALID NMI *** - NMI should be an Alphanumeric value");
            }
            else
            {
                SetValues(true, false, "NMI is valid");
            }
        }

        private bool IsAlphaNumeric(string value)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(value);
        }

        private void SetValues(bool isNmiValid, bool isChecksumCalculated, string message)
        {
            IsNmiValid = isNmiValid;
            IsChecksumCalculated = isChecksumCalculated;
            Message = message;
        }

    }
}