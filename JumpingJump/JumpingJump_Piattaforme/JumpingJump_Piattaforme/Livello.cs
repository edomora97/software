using System.Collections.Generic;

namespace JumpingJump.Piattaforme
{
    /// <summary>
    /// Classe che contiene un livello. Una lista di posizioni
    /// </summary>
    public class Livello
    {
        /// <summary>
        /// Costruttore vuoto. La difficoltà è 0
        /// </summary>
        public Livello()
        {
            _difficoltà = 0;
            _posizioni = new List<Posizione>();
        }
        /// <summary>
        /// Costruttore, copia la lista da posizioni. La difficoltà è 0.
        /// </summary>
        /// <param name="posizioni">Posizioni da copiare</param>
        public Livello(List<Posizione> posizioni)
        {
            this._posizioni = posizioni;
        }
        /// <summary>
        /// Costruttore completo.
        /// </summary>
        /// <param name="posizioni">Posizioni da copiare</param>
        /// <param name="difficoltà">Difficoltà del livello</param>
        public Livello(List<Posizione> posizioni, int difficoltà)
        {
            _posizioni = posizioni;
            _difficoltà = difficoltà;
        }

        private List<Posizione> _posizioni;
        private int _difficoltà;

        /// <summary>
        /// Posizioni all'interno del livello
        /// </summary>
        public List<Posizione> Posizioni
        {
            get { return _posizioni; }
            set { _posizioni = value; }
        }
        /// <summary>
        /// Difficoltà del livello
        /// </summary>
        public int Difficoltà
        {
            get { return _difficoltà; }
            set { _difficoltà = value; }
        }
    }
}
