using FluentAssertions;

namespace HackerRank
{
    public class Kangaroo
    {
        [Fact]
        public void Test()
        {
            //Exec(0, 3, 4, 2).Should().Be(default);
            //Exec(0, 3, 0, 3).Should().Be(default);
            //Exec(0, 8, 0, 4).Should().Be(default);
            //Exec(0, 8, 0, 5).Should().Be(default);
            //Exec(0, 8, 0, 6).Should().Be(default);
            //Exec(0, 8, 0, 7).Should().Be(default);
            //Exec(0, 3, 5, 3).Should().Be(default);
            //Exec(0, 2, 5, 3).Should().Be(default);
            //Exec(43, 2, 70, 2).Should().Be(default);
        }

        public string Exec(int x1, int v1, int x2, int v2)
        {
            // hýzlarý ve baþlangýç lokasyonlarý ayný ise:
            if (x1 == x2 && v1 == v2)
                return "YES";

            // hýzlarý eþit ve biri diðerinden geride baþlamýþ, asla birbirlerini yakalayamayacaklar
            if (v1 == v2 && x1 < x2)
                return "NO";

            // hýzlarý eþit ve biri diðerinden geride baþlamýþ, asla birbirlerini yakalayamayacaklar
            if (v1 == v2 && x2 < x1)
                return "NO";

            while (true)
            {
                // her ikisine de bir adým arttýr
                x1 = x1 + v1;
                x2 = x2 + v2;

                // ayný lokasyondalar mý?
                if (x1 == x2)
                {
                    return "YES";
                }

                // x2, x1 in önüne geçmiþ ve x2'nin sürati x1 den büyük, dolayýsýyla x1 asla x2 yi yakalayamayacak.
                // YA DA
                // x1, x2 nin önüne geçmiþ ve x1'in sürati x2 den büyük, dolayýsýyla x2 asla x1 i yakalayamayacak.
                if (v1 < v2 && x2 > x1 || v2 < v1 && x1 > x2)
                {
                    return "NO";
                }
            }

            // Bu sorunun özü
            // Birbirine eþit hýzda olmayan iki kangurunun sadece belirli bir noktaya kadar ayný lokasyonda bulunma fýrsatlarý var.
            // Bu fýrsat aralýðý da hýzlý olanýn yavaþ olaný geçtiði noktaya kadardýr. 
            // O noktadan sonra artýk birbirleriyle ayný lokasyonda olamazlar.

            // Birisinin hem hýzý yüksek hem de diðerini geçmiþ ise, diðeri artýk onu asla yakalayamaz.
        }
    }
}