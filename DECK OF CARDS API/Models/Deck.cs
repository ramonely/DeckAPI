using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DECK_OF_CARDS_API.Models
{
    public class Deck
    {
        public Cards NewDeck()
        {

            string url = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();

            Cards d = JsonConvert.DeserializeObject<Cards>(result);

            return d;
        }

        public Drawing DrawCard(Cards d, int draw)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{d.deck_id}/draw/?count={draw}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();

            Drawing drawing = JsonConvert.DeserializeObject<Drawing>(result);

            return drawing;

        }
    }
}
