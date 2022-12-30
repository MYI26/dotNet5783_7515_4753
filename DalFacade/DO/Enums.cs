//
using System.Diagnostics;
using System.Xml.Linq;

namespace DO;


    /// <summary>
    /// Structure for all the enumerations that we coould need
    /// </summary>
    public struct Enums
    {
        public enum Category { guitar = 1, violin, flute, piano, musicBrochures }
        public enum Names       //changer les noms en des noms plus simples
        {
            YamahaF310, CordobaC3M, TanglewoodCrossroads,
            VilacAcousitic, IbanezICLS6NT, GrandSonata,
            StanzaStrauss600, NorvegianFiddle, MaestroResonant,
            MastaElectric_Acoustic
        }
        public enum CustomerName 
        {
            Eliaou, Yona, Ouriel, Netanel, ELie, Yossef, Salomon, David, Jeremy, Inoun, BarYohai,
            Raphael, Haim_Hai, Daniel, Mickael, Avi, Ruben, Arie, Isaac, Jonas, Dorone
        }
        public enum CustomerAdress      //mettre une adresse plus précise que la ville
        {
            Jerusalem, Efrat, Raanana, KarneiShomron, Hertslia, BatYam, Ashdod, BneBrak, Haifa, GuivatZeev, Rishonle_Zion, Lod, NeveIlan, RamatGan, Tel_Aviv, Givataim,
            Holon, Ariel, Ashkelon
        }
    }