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
            // h�zlar� ve ba�lang�� lokasyonlar� ayn� ise:
            if (x1 == x2 && v1 == v2)
                return "YES";

            // h�zlar� e�it ve biri di�erinden geride ba�lam��, asla birbirlerini yakalayamayacaklar
            if (v1 == v2 && x1 < x2)
                return "NO";

            // h�zlar� e�it ve biri di�erinden geride ba�lam��, asla birbirlerini yakalayamayacaklar
            if (v1 == v2 && x2 < x1)
                return "NO";

            while (true)
            {
                // her ikisine de bir ad�m artt�r
                x1 = x1 + v1;
                x2 = x2 + v2;

                // ayn� lokasyondalar m�?
                if (x1 == x2)
                {
                    return "YES";
                }

                // x2, x1 in �n�ne ge�mi� ve x2'nin s�rati x1 den b�y�k, dolay�s�yla x1 asla x2 yi yakalayamayacak.
                // YA DA
                // x1, x2 nin �n�ne ge�mi� ve x1'in s�rati x2 den b�y�k, dolay�s�yla x2 asla x1 i yakalayamayacak.
                if (v1 < v2 && x2 > x1 || v2 < v1 && x1 > x2)
                {
                    return "NO";
                }
            }

            // Bu sorunun �z�
            // Birbirine e�it h�zda olmayan iki kangurunun sadece belirli bir noktaya kadar ayn� lokasyonda bulunma f�rsatlar� var.
            // Bu f�rsat aral��� da h�zl� olan�n yava� olan� ge�ti�i noktaya kadard�r. 
            // O noktadan sonra art�k birbirleriyle ayn� lokasyonda olamazlar.

            // Birisinin hem h�z� y�ksek hem de di�erini ge�mi� ise, di�eri art�k onu asla yakalayamaz.
        }
    }
}