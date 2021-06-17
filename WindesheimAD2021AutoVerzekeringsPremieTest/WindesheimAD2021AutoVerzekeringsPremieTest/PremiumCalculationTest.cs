using System;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Moq;
using Xunit;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
    public class PremiumCalculationTest
    {
            /*
             * hiermee wordt getest of er een dubbele premie berekend wordt wanneer de insuranceCoverage ALL_RISK is
             */

        [Fact]
        public void AllRiskIsDoublePrice()
        {
            // Arrange 
            var FakeVehicle = new Vehicle(7000, 30000, 1994);
            var FakePolicyHolder = new PolicyHolder(27, "01-06-2016", 1093, 5);

            // Act
            var doubleCalculation = new PremiumCalculation(FakeVehicle, FakePolicyHolder, InsuranceCoverage.ALL_RISK);

            // Assert
            Assert.Equal(1741.16, doubleCalculation.PremiumPaymentAmount(PremiumCalculation.PaymentPeriod.YEAR));
        }

        /*
             * kijken of er de juiste percentages toegepast worden wanneer de postcode rangeverandert:
             * - Postcodes 10xx - 35xx: 5% risico opslag
             * - Postcodes 36xx - 44xx: 2% risico opslag
             * en hetzelfde geldt voor de leeftijd range:
             * Een leeftijd van onder 23 jaar OF korter dan 5j rijbewijs is premie-opslag van 15%
             */
        [Theory]
        [InlineData(1096, 18, 121.45)]
        [InlineData(1096, 24, 105.61)]
        [InlineData(3678, 18, 117.98)]
        [InlineData(3678, 24, 102.6)]
        public void postalCodeAgeDiffertentTest(int postalCode, int age, double expected)
        {
            // Arrange
            var FakeVehicle = new Vehicle(193, 120000, 2016);
            var FakePolicyHolder = new PolicyHolder(age, "17-05-2014", postalCode, 1);//.

            // Act
            var doubleCalculation = new PremiumCalculation(FakeVehicle, FakePolicyHolder, InsuranceCoverage.WA);

            // Assert
            Assert.Equal(expected, doubleCalculation.PremiumPaymentAmount(PremiumCalculation.PaymentPeriod.MONTH));
        }
    }
}
