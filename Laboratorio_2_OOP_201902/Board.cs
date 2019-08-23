using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos

        private Dictionary<string, List<Card>> [] playerCards;

        private List<SpecialCard> weatherCards;

        //Propiedades
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }

        public Dictionary<string, List<Card>>[] PlayerCards
        {
            get
            {
                return this.playerCards;
            }
        }

        //Constructor
        public Board()
        {
            this.weatherCards = new List<SpecialCard>();
            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS]; // Inicializa el arreglo de diccionarios.
            this.playerCards[0] = new Dictionary<string, List<Card>>(); //Inicializa los diccionarios.
            this.playerCards[1] = new Dictionary<string, List<Card>>(); //Inicializa los diccionarios
        }



        //Metodos

        public void AddCard(Card card, int playerId = -1, string buffType= null)
        {
            // Revisar si la carta recibida en el parmetro es Combat o Special
            if (card.GetType().Name == nameof(CombatCard))
            {
                if (playerId == 0 || playerId == 1)
                {

                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        if (playerCards[playerId].ContainsKey(card.Type))
                        {
                            playerCards[playerId][card.Type].Add(card);
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type, new List<Card>() { card });
                        }
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else
            {
                if (card.GetType().Name == "captain")
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (playerCards[playerId].ContainsKey(card.Type))
                        {
                            throw new IndexOutOfRangeException("Player already has a captain.");
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type, new List<Card>() { card });
                        }
                    }
                }
                if (buffType != null)
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (playerCards[playerId].ContainsKey(card.Type))
                        {
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type, new List<Card>() { card });
                        }
                    }
                }
                if (card.GetType().Name == "weather")
                {
                    weatherCards.Add(card)
                }
            }
        }


        public void DestroyCards()
        {
            List<Card>[] captainCards = new List<Card>[DEFAULT_NUMBER_OF_PLAYERS]
            {
                new List <Card >( playerCards [0]["captain"]),
                new List <Card >( playerCards [1]["captain"])
            }
        }
        public void DestroyCombatCards()
        {
            this.meleeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.rangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.longRangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
        };
        public void DestroySpecialCards()
        {
            this.specialMeleeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialLongRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.weatherCards = new List<SpecialCard>();
        }
        public int[] GetMeleeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                foreach (CombatCard meleeCard in meleeCards[i])
                {
                    totalAttack[i] += meleeCard.AttackPoints;
                }
            }
            return totalAttack;
            
        }
        public int[] GetRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard rangeCard in rangeCards[i])
                {
                    totalAttack[i] += rangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
        public int[] GetLongRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard longRangeCard in longRangeCards[i])
                {
                    totalAttack[i] += longRangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
    }
}
