
using System.Diagnostics;
using System.Xml.Linq;

namespace DO;


    /// <summary>
    /// Structure for ...
    /// </summary>
    public struct Enums
    {
        public enum Category { guitar, violin, flute, piano, musicBrochures }
        public enum Names  // les noms sont trop complique et je pense qu,il faut faire 5 enum Names :Names_guitar ,Names_flute... ne pas oubliet de maitre en anglais
        {
            YamahaF310, CordobaC3M, TanglewoodCrossroads,
            VilacAcousitic, IbanezICLS6NT, GrandSonata,
            StanzaStrauss600, NorvegianFiddle, MaestroResonant,
            MastaElectric_Acoustic
        }
        public enum CustomerName // il n'y a pas que des garcon qui joue de la musique lol
        {
            Eliaou, Yona, Ouriel, Netanel, ELie, Yossef, Salomon, David, Jeremy, Inoun, BarYohai,
            Raphael, Haim, Daniel, Mickael, Avi, Ruben, Arie, Isaac, Jonas, Dorone
        }
        public enum CustomerAdress
        {
            Jerusalem, Efrat, Raanana, KarneiShomron, Hertslia, BatYam, Ashdod, BneBrak, Haifa, GuivatZeev, Rishonle_Zion, Lod, NeveIlan, RamatGan, Tel_Aviv, Givataim,
            Holon, Ariel, Ashkelon
        }
    }



///// <summary>
///// Unique ID of ...
///// </summary>
//public int ID { get; set; }
//public string Name { get; set; }
//public Category Category { get; set; }
//public int Price { get; set; }
//public int InStock { get; set; }
//public override string ToString() => $@"
//        Product ID={ID}: {Name}, 
//        category - {Category}
//    	Price: {Price}
//    	Amount in stock: {InStock}
//";