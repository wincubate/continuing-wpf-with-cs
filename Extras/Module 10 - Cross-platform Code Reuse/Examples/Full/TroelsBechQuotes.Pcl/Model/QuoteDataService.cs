using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TroelsBechQuotes.Pcl.Model
{
   class QuoteDataService : IQuoteDataService
   {
      List<Quote> _quotes;

      public QuoteDataService()
      {
         _quotes = new List<Quote>
         {
            new Quote
            {
               Text = "\"Målsætningen handler om at forbedre placeringen fra år til år, og hvis jeg bliver længe nok, må det da for fanden ende med guld til sidst.\"",
               Caption = "Ved tiltrædelsen i OB i 2000"
            },
            new Quote
            {
               Text = "\"Lige meget, hvor mange kopper med 50 grader varmt vand, du hælder sammen, så får du det ikke til at koge.\"",
               Caption = "Om landsholdets mangel på topspillere. Tipsbladet 16. november 2007"
            },
            new Quote
            {
               Text = "\"For to uger siden hed det sig, at vi havde det dårligste landshold i 30 år. Nu vandt det i Portugal, og så kunne man jo spørge sig selv, om vi har den dårligste danske sportspresse i 30 år.\"",
               Caption = "Jyllands-Posten. 25. september 2008"
            },
            new Quote
            {
               Text = "\"Det lignede længe en 0-0 kamp, fordi vi var impotente og havde en metroseksuel boldmassage, som var kønsløs hen over midten.\"",
               Caption = "Til DR Sporten efter et 4-0-nederlag 14. november 2010"
            },
            new Quote
            {
               Text = "\"Historien om AC Horsens er en fantastisk historie. Det er historien om en grim ælling, der er på vej til at blive... en grim svane, alt efter temperament.\"",
               Caption = "Kanal Sport, 29. oktober 2011"
            },
            new Quote
            {
               Text = "\"Kan du huske, at Peter Plys sagde, at det bedste her i livet er at spise honning, hvorefter han lige rettede sig og sagde \"nej nej, det er lige inden, man skal spise honning.\"? Det bedste for mig som træner er, når jeg kan mærke, at nu er det lige ved forløse sig, nu er vi tæt på at lykkes. Det tror jeg vi kan komme med OB.\"",
               Caption = "Interview med Kanal Sport efter sin tiltrædelse i OB, 5. juni 2012"
            },
            new Quote
            {
               Text = "\"Det er et skridt fremad på størrelse med det, man kan foretage sig, når man sidder på toilettet med bukserne nede om hælene.\"",
               Caption = "Troels Bech er i sin aktive karriere på talerstolen til DBU's årsmøde som repræsentant for Spillerforeningen, og han er utilfreds med et netop vedtaget forslag"
            },
            new Quote
            {
               Text = "\"I bund og grund er jeg træt af at stå her og beklage mig over baneforholdene igen, for det lyder lidt tøset. Men når vi står her, kan vi ikke komme uden om, at banerne er meget dårlige. Der findes rigtig mange efterskoler med klart bedre træningsbaner end dem her, og der findes landmænd, der får braklægsningsstøtte for græsmarker, der er som den her.\"",
               Caption = "Om dårlige træningsforhold i Silkeborg. mja.dk 20. april 2011"
            },
            new Quote
            {
               Text = "\"Indtil i dag var vi det eneste hold i ligaen, som der ikke var scoret mod det sidste kvarter. Hvordan takserer man så et mål i 97. minut? Er det i begyndelsen af næste kamp eller hvad? Det er godt nok længe at vente. Det er dejligt at se, at den unge dommer er blevet gammel nok til at være ude så længe, at vi kan spille så lang tid.\"",
               Caption = "Efter 1-1 mod FC Midtjylland 21. oktober 2012, hvor FC Midtjylland udlignede i det 97. minut"
            },
            new Quote
            {
               Text = "\"Og her har vi et glimrende eksempel på, at Dennis Rommedahls førsteberøringer oftest bliver den sidste.\"",
               Caption = "Som medkommentator til landskamp i Parken"
            }
         };
      }

      #region IQuoteDataService Members

      public Quote GetRandomQuote()
      {
         Random random = new Random();
         int index = random.Next( _quotes.Count );

         return _quotes[ index ];
      }

      #endregion
   }
}
