using System;
using System.Collections.Generic;
using JumpingJump.Classi;
using Microsoft.Xna.Framework;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
    public struct VariabiliTemp
    {
        /// <summary>
        /// Posizione della parte inferiore dello sfondo
        /// </summary>
        public static Vector2 posizioneSfondo1;
        /// <summary>
        /// Lista dei nemici
        /// </summary>
        public static List<Nemico> nemici;
        /// <summary>
        /// Lista delle posizioni dei blocchi
        /// </summary>
        public static List<Posizione> posizioni;
        /// <summary>
        /// Lista dei livelli dei blocchi
        /// </summary>
        public static List<Livello> livelli;
        /// <summary>
        /// Posizione del giocatore
        /// </summary>
        public static Vector2 posizionePlayer;
        /// <summary>
        /// Indica se la funzione è nella fase seno
        /// </summary>
        public static bool isSin;
        /// <summary>
        /// Angolo in gradi
        /// </summary>
        public static float deg;
        /// <summary>
        /// Angolo in radianti
        /// </summary>
        public static double rad;
        /// <summary>
        /// Seno di rad
        /// </summary>
        public static double cos;
        /// <summary>
        /// Incremento nella seconda parte della funzione
        /// </summary>
        public static float inc;
        /// <summary>
        /// Indica se il personaggio si sta muovendo verso destra
        /// </summary>
        public static bool isRight;
        /// <summary>
        /// Variabile temporanea per il corretto funzionamento della classifica
        /// </summary>
        public static bool classificaTemp;
        /// <summary>
        /// Variabile temporanea per l'aggiornamento del record nel gameover
        /// </summary>
        public static bool gameOverTemp;
        /// <summary>
        /// Altezza dell'ultimo salto
        /// </summary>
        public static float JumpHeight;
        /// <summary>
        /// Indica se il giocatore stà salendo o lo sfondo scendendo
        /// </summary>
        public static bool isJumping;
        /// <summary>
        /// Lista degli elementi della classifica
        /// </summary>
        public static List<ElementoClassifica> _classifica;
        /// <summary>
        /// Numero totale dei salti fatti
        /// </summary>
        public static int totalJump;
        /// <summary>
        /// Numero totale di partite fatte
        /// </summary>
        public static int totalGame;
        /// <summary>
        /// Punteggio totale di tutte le partite
        /// </summary>
        public static int totalScore;
        /// <summary>
        /// Numero di salti della partita precedente
        /// </summary>
        public static int lastJump;
        /// <summary>
        /// Punteggio dell'ultima partita fatta
        /// </summary>
        public static int lastScore;
        /// <summary>
        /// Numero medio di salti fatti
        /// </summary>
        public static float avarangeJump;
        /// <summary>
        /// Punteggio medio delle partite
        /// </summary>
        public static float avarangeScore;
        /// <summary>
        /// Rappresenta il tempo giocato
        /// </summary>
        public static TimeSpan totalGameTime;
        /// <summary>
        /// Variabile temporanea per il corretto funzionamento del menu statistiche
        /// </summary>
        public static bool statisticheTemp;
        /// <summary>
        /// Posizione del player all'interno del menu
        /// </summary>
        public static Vector2 posizionePlayerMenu;
        /// <summary>
        /// Bonus corrente. Se non ci sono bonus attivi il valore è null
        /// </summary>
        public static Bonus currBonus;
        public static Bonus currBonusCaduta;
    }
}