using System;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
   
    public class VehicleTest
    {
        /*
             * test om na te gaan of de leeftijd van de auto wel klopt
             */
        [Fact]
        public void GetVehicleRightAge()
        {
            var car = new Vehicle(7000, 30000, 1994);
            Assert.Equal(27, car.Age);
        }
    }
}
