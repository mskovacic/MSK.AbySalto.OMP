using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSK.AbySalto.OMP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeded_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { -3L, "Vesh White Gel deterdžent za pranje rublja\r\nVesh koncentrirani deterdžent za pranje rublja nudi 67% koncentriraniju formulu, što omogućuje manje doze i bolje rezultate. S 2× jačom formulom štedite na količini utrošenog deterdženta, a on učinkovito uklanja mrlje čak i na 20 °C. Idealan je za dugoročno očuvanje svježine i boja vaše odjeće, uz smanjenje troškova i uštedu energije. Vesh White Power Gel uklanja do 99% svakodnevnih mrlja sa snažnim enzimima, koji pružaju izvrsnu učinkovitost i njegu tkanine. Posebne čestice Anti-greying sprječavaju povratak prljavštine, dok prepoznatljivi miris osigurava dugotrajnu svježinu. Bez dodavanja agresivnih izbjeljivača. ", "", "Violeta Vesh White Gel deterdžent za pranje rublja, 3 l", 749 },
                    { -2L, "AgfaPhoto Reusable Camera 35mm spaja retro eleganciju s autentičnim osjećajem stvaranja klasičnih analognih fotografija. Kompaktno kućište i mala težina od samo 119g čine ovaj fotoaparat idealnim suputnikom za svakodnevna fotografska putovanja – od jutarnjih šetnji do spontanih urbanih avantura.\r\n\r\nFotoaparat ima ugrađeni blic i fiksni objektiv 31mm f/9, koji omogućuju pouzdanu kvalitetu snimaka pri dnevnom svjetlu i u slabijim svjetlosnim uvjetima, bez kompliciranih postavki. Jednostavno optičko tražilo i brzina zatvarača 1/120 s omogućuju trenutno fotografiranje, što ga čini savršenim izborom za početnike i sve koji cijene jednostavnost analogne fotografije.\r\n\r\nKamera koristi 35mm film (u boji ili crno-bijeli), kompatibilan s ISO 200–800, što pruža slobodu eksperimentiranja s različitim stilovima i estetikom. U pakiranju se nalaze traka za nošenje i torbica, dok se baterija (1×AAA) i film prodaju zasebno.\r\n\r\nAko tražiš analogni fotoaparat na film s izraženim vintage karakterom i bez nepotrebnih kompromisa, AgfaPhoto Reusable Camera odličan je izbor.", "2.webp", "Agfaphoto Analogna kamera na film mint (AGFA121949)", 4490 },
                    { -1L, "Emos RS8471 termometar sa sondom\r\n\r\nŽičani termometar sa sondom\r\nVanjska temperatura: –40 °C do +70 °C, rezolucija 0,1 °C\r\nUnutarnja temperatura: –10 °C do +50 °C, rezolucija 0,1 °C\r\nUnutarnja vlažnost: 20 % do 99 % RH, 1 % rezolucija\r\nMogućnost postavljanja jedinice temperature: °C/°F: °C/°F\r\nMinimalna i maksimalna temperatura\r\nUpozorenje na temperaturu\r\nTemperaturni indeks\r\nŽičana sonda za senzor: 2 m", "1.webp", "EMOS RS8471 termometar sa sondom", 1599 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1L);
        }
    }
}
